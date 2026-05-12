using NETbugTracker.Data;
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
using Microsoft.EntityFrameworkCore;

namespace NETbugTracker.Forms
{
    public partial class MainForm : Form
    {
        private bool IsAdmin => _currentUser.RoleId == 1;
        private bool IsDeveloper => _currentUser.RoleId == 2;
        private bool IsTester => _currentUser.RoleId == 3;

        private User _currentUser;
        private List<Project> _projectsList = new List<Project>();
        private List<Bug> _bugsList = new List<Bug>();
        public MainForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            ConfigureMenuByRole();
            LoadProjects();
            LoadFilterComboBoxes();
        }

        private void ConfigureMenuByRole()
        {
            // Название формы с именем и ролью
            if (IsAdmin)
                this.Text = $"BugTracker - {_currentUser.FullName} (Администратор)";
            else if (IsDeveloper)
                this.Text = $"BugTracker - {_currentUser.FullName} (Разработчик)";
            else
                this.Text = $"BugTracker - {_currentUser.FullName} (Тестировщик)";

            // Тестировщик не может удалять проекты и баги
            if (btnDeleteProject != null)
                btnDeleteProject.Visible = !IsTester;
            if (btnDeleteBug != null)
                btnDeleteBug.Visible = !IsTester;

            // Тестировщик не может создавать проекты (скрываем кнопку)
            if (btnAddProject != null)
                btnAddProject.Visible = !IsTester;
        }

        private void LoadProjects()
        {
            using (var db = new AppDbContext())
            {
                // Загружаем реальные объекты Project
                _projectsList = db.Projects
                    .Include(p => p.OwnerUser)
                    .ToList();

                // Привязываем к DataGridView
                dgvProjects.DataSource = null;
                dgvProjects.DataSource = _projectsList;

                // Настраиваем русские заголовки (работаем с колонками напрямую)
                if (dgvProjects.Columns["ProjectId"] != null)
                    dgvProjects.Columns["ProjectId"].HeaderText = "ID";
                if (dgvProjects.Columns["Name"] != null)
                    dgvProjects.Columns["Name"].HeaderText = "Название";
                if (dgvProjects.Columns["Description"] != null)
                    dgvProjects.Columns["Description"].HeaderText = "Описание";
                if (dgvProjects.Columns["CreatedDate"] != null)
                    dgvProjects.Columns["CreatedDate"].HeaderText = "Дата создания";

                // Скрываем колонку OwnerUserId (она не нужна визуально)
                if (dgvProjects.Columns["OwnerUserId"] != null)
                    dgvProjects.Columns["OwnerUserId"].Visible = false;
                if (dgvProjects.Columns["OwnerUser"] != null)
                    dgvProjects.Columns["OwnerUser"].Visible = false;
                if (dgvProjects.Columns["Bugs"] != null)
                    dgvProjects.Columns["Bugs"].Visible = false;
            }
        }
        private void LoadBugs(int projectId, int? statusId = null, int? priorityId = null, int? assignedUserId = null, string searchTitle = "")
        {
            using (var db = new AppDbContext())
            {
                var query = db.Bugs
                    .Include(b => b.Status)
                    .Include(b => b.Priority)
                    .Include(b => b.AssignedUser)
                    .Where(b => b.ProjectId == projectId);

                // Фильтр по статусу
                if (statusId.HasValue && statusId.Value > 0)
                    query = query.Where(b => b.StatusId == statusId.Value);

                // Фильтр по приоритету
                if (priorityId.HasValue && priorityId.Value > 0)
                    query = query.Where(b => b.PriorityId == priorityId.Value);

                // Фильтр по исполнителю
                if (assignedUserId.HasValue && assignedUserId.Value > 0)
                    query = query.Where(b => b.AssignedUserId == assignedUserId.Value);

                // Поиск по заголовку
                if (!string.IsNullOrWhiteSpace(searchTitle))
                    query = query.Where(b => b.Title.Contains(searchTitle));

                _bugsList = query.ToList();

                dgvBugs.DataSource = null;
                dgvBugs.DataSource = _bugsList;

                // Настройка колонок
                if (dgvBugs.Columns["BugId"] != null)
                    dgvBugs.Columns["BugId"].HeaderText = "ID";
                if (dgvBugs.Columns["Title"] != null)
                    dgvBugs.Columns["Title"].HeaderText = "Заголовок";
                if (dgvBugs.Columns["Status"] != null)
                    dgvBugs.Columns["Status"].HeaderText = "Статус";
                if (dgvBugs.Columns["Priority"] != null)
                    dgvBugs.Columns["Priority"].HeaderText = "Приоритет";
                if (dgvBugs.Columns["AssignedUser"] != null)
                    dgvBugs.Columns["AssignedUser"].HeaderText = "Исполнитель";

                // Скрыть ненужные колонки
                var hiddenColumns = new[] { "Description", "StepsToReproduce", "ProjectId",
            "AuthorUserId", "AuthorUser", "Project", "CreatedDate", "DueDate",
            "StatusId", "PriorityId", "AssignedUserId", "Comments" };
                foreach (var col in hiddenColumns)
                {
                    if (dgvBugs.Columns[col] != null)
                        dgvBugs.Columns[col].Visible = false;
                }
            }
        }
        private void LoadFilterComboBoxes()
        {
            using (var db = new AppDbContext())
            {
                // Загружаем статусы из БД
                var statuses = db.Statuses.ToList();
                statuses.Insert(0, new Status { StatusId = 0, StatusName = "Все" });
                cmbFilterStatus.DataSource = null;
                cmbFilterStatus.DisplayMember = "StatusName";
                cmbFilterStatus.ValueMember = "StatusId";
                cmbFilterStatus.DataSource = statuses;
                cmbFilterStatus.SelectedIndex = 0;  // выбрано "Все"

                // Загружаем приоритеты из БД
                var priorities = db.Priorities.ToList();
                priorities.Insert(0, new Priority { PriorityId = 0, PriorityName = "Все" });
                cmbFilterPriority.DataSource = null;
                cmbFilterPriority.DisplayMember = "PriorityName";
                cmbFilterPriority.ValueMember = "PriorityId";
                cmbFilterPriority.DataSource = priorities;
                cmbFilterPriority.SelectedIndex = 0;

                // Загружаем пользователей из БД
                var users = db.Users.ToList();
                users.Insert(0, new User { UserId = 0, FullName = "Все" });
                cmbFilterAssigned.DataSource = null;
                cmbFilterAssigned.DisplayMember = "FullName";
                cmbFilterAssigned.ValueMember = "UserId";
                cmbFilterAssigned.DataSource = users;
                cmbFilterAssigned.SelectedIndex = 0;
            }
        }

        private void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProjects.CurrentRow != null && _projectsList.Count > 0)
            {
                var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];
                LoadBugs(selectedProject.ProjectId);
            }
        }

        // Обработчик выхода
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Обработчик "О программе"
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BugTracker\nВерсия 1.0\nДипломный проект", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            if (!IsAdmin && !IsDeveloper)
            {
                MessageBox.Show("Только администратор или разработчик могут создавать проекты",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new ProjectForm(_currentUser))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProjects();
                    MessageBox.Show("Проект создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.CurrentRow == null)
            {
                MessageBox.Show("Выберите проект для редактирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем реальный объект Project из списка
            var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];

            using (var form = new ProjectForm(_currentUser, selectedProject))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProjects(); // обновляем список
                    MessageBox.Show("Проект обновлён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Только администратор может удалять проекты",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProjects.CurrentRow == null)
            {
                MessageBox.Show("Выберите проект для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем реальный объект Project из списка
            var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];

            var result = MessageBox.Show($"Удалить проект \"{selectedProject.Name}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var db = new AppDbContext())
                {
                    // Находим проект в базе (на всякий случай свежий)
                    var project = db.Projects.Find(selectedProject.ProjectId);
                    if (project != null)
                    {
                        db.Projects.Remove(project);
                        db.SaveChanges();
                    }
                }
                LoadProjects();
                MessageBox.Show("Проект удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddBug_Click(object sender, EventArgs e)
        {
            if (!IsAdmin && !IsDeveloper)
            {
                MessageBox.Show("Только администратор или разработчик могут создавать баги",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvProjects.CurrentRow == null)
            {
                MessageBox.Show("Сначала выберите проект", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];

            using (var form = new BugForm(_currentUser, selectedProject.ProjectId, IsTester))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBugs(selectedProject.ProjectId);
                    MessageBox.Show("Баг создан", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEditBug_Click(object sender, EventArgs e)
        {
            if (dgvProjects.CurrentRow == null)
            {
                MessageBox.Show("Сначала выберите проект", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvBugs.CurrentRow == null)
            {
                MessageBox.Show("Выберите баг для редактирования", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedBug = _bugsList[dgvBugs.CurrentRow.Index];

            // Тестировщик может редактировать только свои баги
            if (IsTester && selectedBug.AuthorUserId != _currentUser.UserId)
            {
                MessageBox.Show("Вы можете редактировать только те баги, которые создали сами",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new BugForm(_currentUser, selectedBug, IsTester))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];
                    LoadBugs(selectedProject.ProjectId);
                    MessageBox.Show("Баг обновлён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteBug_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Только администратор может удалять баги",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvBugs.CurrentRow == null)
            {
                MessageBox.Show("Выберите баг для удаления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedBug = _bugsList[dgvBugs.CurrentRow.Index];

            var result = MessageBox.Show($"Удалить баг \"{selectedBug.Title}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (var db = new AppDbContext())
                {
                    var bug = db.Bugs.Find(selectedBug.BugId);
                    if (bug != null)
                    {
                        db.Bugs.Remove(bug);
                        db.SaveChanges();
                    }
                }

                var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];
                LoadBugs(selectedProject.ProjectId);
                MessageBox.Show("Баг удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (dgvProjects.CurrentRow == null)
            {
                MessageBox.Show("Сначала выберите проект", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];

            // Если выбран "Все" (StatusId = 0), то не фильтруем
            int? statusId = (int?)cmbFilterStatus.SelectedValue;
            if (statusId == 0) statusId = null;

            int? priorityId = (int?)cmbFilterPriority.SelectedValue;
            if (priorityId == 0) priorityId = null;

            int? assignedUserId = (int?)cmbFilterAssigned.SelectedValue;
            if (assignedUserId == 0) assignedUserId = null;

            string searchTitle = txtSearchTitle.Text.Trim();

            LoadBugs(selectedProject.ProjectId, statusId, priorityId, assignedUserId, searchTitle);
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            // Сбрасываем выбор на "Все"
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterPriority.SelectedIndex = 0;
            cmbFilterAssigned.SelectedIndex = 0;
            txtSearchTitle.Text = "";

            // Перезагружаем баги без фильтров
            if (dgvProjects.CurrentRow != null && _projectsList.Count > 0)
            {
                var selectedProject = _projectsList[dgvProjects.CurrentRow.Index];
                LoadBugs(selectedProject.ProjectId);
            }
        }
    }
}
