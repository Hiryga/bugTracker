using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NETbugTracker.Entities;
using NETbugTracker.Data;

namespace NETbugTracker.Forms
{
    public partial class BugForm : Form
    {
        private AppDbContext _context;
        private Bug _editingBug;
        private User _currentUser;
        private int _projectId;
        private bool _isTester;

        // Конструктор для нового бага (с признаком роли)
        public BugForm(User currentUser, int projectId, bool isTester)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _currentUser = currentUser;
            _projectId = projectId;
            _isTester = isTester;
            _editingBug = null;
            this.Text = "Новый баг";
            LoadComboBoxes();
            chkNoDueDate.Checked = true;
            dtpDueDate.Enabled = false;
        }

        // Конструктор для редактирования (с признаком роли)
        public BugForm(User currentUser, Bug bug, bool isTester)
            : this(currentUser, bug.ProjectId, isTester)
        {
            _editingBug = bug;
            this.Text = "Редактирование бага";

            txtTitle.Text = bug.Title;
            txtDescription.Text = bug.Description;
            txtStepsToReproduce.Text = bug.StepsToReproduce;

            if (bug.DueDate.HasValue)
            {
                dtpDueDate.Value = bug.DueDate.Value;
                chkNoDueDate.Checked = false;
                dtpDueDate.Enabled = true;
            }

            LoadComboBoxes();

            // Выбираем значения в ComboBox
            cmbAssignedUser.SelectedValue = bug.AssignedUserId;
            cmbPriority.SelectedValue = bug.PriorityId;
            cmbStatus.SelectedValue = bug.StatusId;

            // ========== БЛОКИРОВКА ДЛЯ ТЕСТИРОВЩИКА (ЧУЖОЙ БАГ) ==========
            if (_isTester && _editingBug.AuthorUserId != _currentUser.UserId)
            {
                cmbStatus.Enabled = false;
                cmbPriority.Enabled = false;
                cmbAssignedUser.Enabled = false;
                txtTitle.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtStepsToReproduce.ReadOnly = true;
                chkNoDueDate.Enabled = false;
                dtpDueDate.Enabled = false;
                btnSave.Enabled = false;  // кнопка сохранить неактивна
                this.Text = "Просмотр бага (только чтение)";
                MessageBox.Show("Вы можете только просматривать этот баг", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadComboBoxes()
        {
            using (var db = new AppDbContext())
            {
                // Загружаем исполнителей
                cmbAssignedUser.DataSource = db.Users.ToList();
                cmbAssignedUser.DisplayMember = "FullName";
                cmbAssignedUser.ValueMember = "UserId";

                // Загружаем приоритеты
                cmbPriority.DataSource = db.Priorities.ToList();
                cmbPriority.DisplayMember = "PriorityName";
                cmbPriority.ValueMember = "PriorityId";

                // Загружаем статусы
                cmbStatus.DataSource = db.Statuses.ToList();
                cmbStatus.DisplayMember = "StatusName";
                cmbStatus.ValueMember = "StatusId";
            }
        }

        private void chkNoDueDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDueDate.Enabled = !chkNoDueDate.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите заголовок бага", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingBug == null)
            {
                // Новый баг
                var bug = new Bug
                {
                    Title = txtTitle.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    StepsToReproduce = txtStepsToReproduce.Text.Trim(),
                    ProjectId = _projectId,
                    AuthorUserId = _currentUser.UserId,
                    AssignedUserId = (int)cmbAssignedUser.SelectedValue,
                    StatusId = (int)cmbStatus.SelectedValue,
                    PriorityId = (int)cmbPriority.SelectedValue,
                    CreatedDate = DateTime.Now,
                    DueDate = chkNoDueDate.Checked ? null : dtpDueDate.Value
                };
                _context.Bugs.Add(bug);
            }
            else
            {
                // Редактирование бага (находим в текущем контексте)
                var bugToUpdate = _context.Bugs.Find(_editingBug.BugId);
                if (bugToUpdate != null)
                {
                    bugToUpdate.Title = txtTitle.Text.Trim();
                    bugToUpdate.Description = txtDescription.Text.Trim();
                    bugToUpdate.StepsToReproduce = txtStepsToReproduce.Text.Trim();
                    bugToUpdate.AssignedUserId = (int)cmbAssignedUser.SelectedValue;
                    bugToUpdate.StatusId = (int)cmbStatus.SelectedValue;
                    bugToUpdate.PriorityId = (int)cmbPriority.SelectedValue;
                    bugToUpdate.DueDate = chkNoDueDate.Checked ? null : dtpDueDate.Value;
                }
            }

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
