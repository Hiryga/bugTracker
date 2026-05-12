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
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string steps = txtStepsToReproduce.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Введите заголовок бага", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (title.Length > 200)
            {
                MessageBox.Show("Заголовок бага не может быть длиннее 200 символов",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAssignedUser.SelectedValue == null)
            {
                MessageBox.Show("Выберите исполнителя", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPriority.SelectedValue == null)
            {
                MessageBox.Show("Выберите приоритет", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbStatus.SelectedValue == null)
            {
                MessageBox.Show("Выберите статус", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkNoDueDate.Checked && dtpDueDate.Value.Date < DateTime.Today)
            {
                var confirm = MessageBox.Show(
                    "Дедлайн установлен в прошлое. Продолжить?", "Внимание",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
            }

            int assignedId = (int)cmbAssignedUser.SelectedValue;
            int priorityId = (int)cmbPriority.SelectedValue;
            int statusId = (int)cmbStatus.SelectedValue;

            try
            {
                if (_editingBug == null)
                {
                    var bug = new Bug
                    {
                        Title = title,
                        Description = description,
                        StepsToReproduce = steps,
                        ProjectId = _projectId,
                        AuthorUserId = _currentUser.UserId,
                        AssignedUserId = assignedId,
                        StatusId = statusId,
                        PriorityId = priorityId,
                        CreatedDate = DateTime.Now,
                        DueDate = chkNoDueDate.Checked ? null : dtpDueDate.Value
                    };
                    _context.Bugs.Add(bug);
                }
                else
                {
                    var bugToUpdate = _context.Bugs.Find(_editingBug.BugId);
                    if (bugToUpdate == null)
                    {
                        MessageBox.Show("Баг уже удалён другим пользователем", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }

                    bugToUpdate.Title = title;
                    bugToUpdate.Description = description;
                    bugToUpdate.StepsToReproduce = steps;
                    bugToUpdate.AssignedUserId = assignedId;
                    bugToUpdate.StatusId = statusId;
                    bugToUpdate.PriorityId = priorityId;
                    bugToUpdate.DueDate = chkNoDueDate.Checked ? null : dtpDueDate.Value;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
