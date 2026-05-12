using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NETbugTracker.Data;
using NETbugTracker.Entities;
using NETbugTracker.Services;

namespace NETbugTracker.Forms
{
    public partial class MainForm : Form
    {
        private bool IsAdmin => _currentUser.RoleId == 1;
        private bool IsDeveloper => _currentUser.RoleId == 2;
        private bool IsTester => _currentUser.RoleId == 3;

        // Когда true, Program.cs снова покажет LoginForm после закрытия MainForm.
        public bool LogoutRequested { get; private set; }

        private readonly User _currentUser;
        private List<Project> _projectsList = new List<Project>();
        private List<Bug> _bugsList = new List<Bug>();

        public MainForm(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            ConfigureMenuByRole();
            LoadProjects();
            LoadFilterComboBoxes();
            UpdateStats();
        }

        private void ConfigureMenuByRole()
        {
            if (IsAdmin)
                this.Text = $"BugTracker - {_currentUser.FullName} (Администратор)";
            else if (IsDeveloper)
                this.Text = $"BugTracker - {_currentUser.FullName} (Разработчик)";
            else
                this.Text = $"BugTracker - {_currentUser.FullName} (Тестировщик)";

            if (btnDeleteProject != null)
                btnDeleteProject.Visible = !IsTester;
            if (btnDeleteBug != null)
                btnDeleteBug.Visible = !IsTester;
            if (btnAddProject != null)
                btnAddProject.Visible = !IsTester;
            if (btnEditProject != null)
                btnEditProject.Visible = !IsTester;

            // Пункты меню, доступные только администратору
            if (пользователиToolStripMenuItem != null)
                пользователиToolStripMenuItem.Visible = IsAdmin;
            if (журналДействийToolStripMenuItem != null)
                журналДействийToolStripMenuItem.Visible = IsAdmin;
        }

        private void LoadProjects()
        {
            using var db = new AppDbContext();
            _projectsList = db.Projects
                .Include(p => p.OwnerUser)
                .OrderBy(p => p.ProjectId)
                .ToList();

            dgvProjects.DataSource = null;
            dgvProjects.DataSource = _projectsList;

            if (dgvProjects.Columns["ProjectId"] != null)
                dgvProjects.Columns["ProjectId"].HeaderText = "ID";
            if (dgvProjects.Columns["Name"] != null)
                dgvProjects.Columns["Name"].HeaderText = "Название";
            if (dgvProjects.Columns["Description"] != null)
                dgvProjects.Columns["Description"].HeaderText = "Описание";
            if (dgvProjects.Columns["CreatedDate"] != null)
                dgvProjects.Columns["CreatedDate"].HeaderText = "Дата создания";

            if (dgvProjects.Columns["OwnerUserId"] != null)
                dgvProjects.Columns["OwnerUserId"].Visible = false;
            if (dgvProjects.Columns["OwnerUser"] != null)
                dgvProjects.Columns["OwnerUser"].Visible = false;
            if (dgvProjects.Columns["Bugs"] != null)
                dgvProjects.Columns["Bugs"].Visible = false;

            // Если есть проекты — подгружаем баги для первого
            if (_projectsList.Count > 0)
            {
                dgvProjects.ClearSelection();
                dgvProjects.Rows[0].Selected = true;
                LoadBugs(_projectsList[0].ProjectId);
            }
            else
            {
                _bugsList.Clear();
                dgvBugs.DataSource = null;
                UpdateStats();
            }
        }

        private void LoadBugs(int projectId, int? statusId = null, int? priorityId = null,
            int? assignedUserId = null, string searchTitle = "")
        {
            using var db = new AppDbContext();
            var query = db.Bugs
                .Include(b => b.Status)
                .Include(b => b.Priority)
                .Include(b => b.AssignedUser)
                .Where(b => b.ProjectId == projectId);

            if (statusId.HasValue && statusId.Value > 0)
                query = query.Where(b => b.StatusId == statusId.Value);

            if (priorityId.HasValue && priorityId.Value > 0)
                query = query.Where(b => b.PriorityId == priorityId.Value);

            if (assignedUserId.HasValue && assignedUserId.Value > 0)
                query = query.Where(b => b.AssignedUserId == assignedUserId.Value);

            if (!string.IsNullOrWhiteSpace(searchTitle))
                query = query.Where(b => b.Title.Contains(searchTitle));

            _bugsList = query.OrderBy(b => b.BugId).ToList();

            dgvBugs.DataSource = null;
            dgvBugs.DataSource = _bugsList;

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

            var hiddenColumns = new[]
            {
                "Description", "StepsToReproduce", "ProjectId",
                "AuthorUserId", "AuthorUser", "Project", "CreatedDate", "DueDate",
                "StatusId", "PriorityId", "AssignedUserId", "Comments"
            };
            foreach (var col in hiddenColumns)
            {
                if (dgvBugs.Columns[col] != null)
                    dgvBugs.Columns[col].Visible = false;
            }

            UpdateStats();
        }

        private void LoadFilterComboBoxes()
        {
            using var db = new AppDbContext();

            var statuses = db.Statuses.ToList();
            statuses.Insert(0, new Status { StatusId = 0, StatusName = "Все" });
            cmbFilterStatus.DataSource = null;
            cmbFilterStatus.DisplayMember = "StatusName";
            cmbFilterStatus.ValueMember = "StatusId";
            cmbFilterStatus.DataSource = statuses;
            cmbFilterStatus.SelectedIndex = 0;

            var priorities = db.Priorities.ToList();
            priorities.Insert(0, new Priority { PriorityId = 0, PriorityName = "Все" });
            cmbFilterPriority.DataSource = null;
            cmbFilterPriority.DisplayMember = "PriorityName";
            cmbFilterPriority.ValueMember = "PriorityId";
            cmbFilterPriority.DataSource = priorities;
            cmbFilterPriority.SelectedIndex = 0;

            var users = db.Users.ToList();
            users.Insert(0, new User { UserId = 0, FullName = "Все" });
            cmbFilterAssigned.DataSource = null;
            cmbFilterAssigned.DisplayMember = "FullName";
            cmbFilterAssigned.ValueMember = "UserId";
            cmbFilterAssigned.DataSource = users;
            cmbFilterAssigned.SelectedIndex = 0;
        }

        private void UpdateStats()
        {
            if (_projectsList.Count == 0)
            {
                lblStats.Text = "Проекты не созданы";
                return;
            }

            int total = _bugsList.Count;
            int newCount = _bugsList.Count(b => b.StatusId == 1);
            int inProgress = _bugsList.Count(b => b.StatusId == 2);
            int review = _bugsList.Count(b => b.StatusId == 3);
            int closed = _bugsList.Count(b => b.StatusId == 4);

            lblStats.Text = $"Всего багов: {total} | Новых: {newCount} | " +
                             $"В работе: {inProgress} | На проверке: {review} | Закрыто: {closed}";
        }

        private Project? GetSelectedProject()
        {
            if (dgvProjects.CurrentRow == null) return null;
            int index = dgvProjects.CurrentRow.Index;
            if (index < 0 || index >= _projectsList.Count) return null;
            return _projectsList[index];
        }

        private Bug? GetSelectedBug()
        {
            if (dgvBugs.CurrentRow == null) return null;
            int index = dgvBugs.CurrentRow.Index;
            if (index < 0 || index >= _bugsList.Count) return null;
            return _bugsList[index];
        }

        private void dgvProjects_SelectionChanged(object sender, EventArgs e)
        {
            var project = GetSelectedProject();
            if (project != null)
            {
                LoadBugs(project.ProjectId);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Выйти из аккаунта и вернуться на форму авторизации?",
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                ActivityLogger.Log(_currentUser.UserId, "Logout", "User", _currentUser.UserId);
            }
            catch { }

            LogoutRequested = true;
            this.Close();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "BugTracker\nВерсия 1.1\nДипломный проект\n\n" +
                "Система отслеживания ошибок и задач.\n" +
                "© 2026",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void сменитьПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new ChangePasswordForm(_currentUser);
            form.ShowDialog();
        }

        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Только администратор может управлять пользователями",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using var form = new UserManagementForm(_currentUser);
            form.ShowDialog();
            LoadFilterComboBoxes();
        }

        private void отчётыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new ReportForm();
            form.ShowDialog();
        }

        private void журналДействийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("Только администратор может просматривать журнал",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using var form = new ActivityLogForm();
            form.ShowDialog();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            if (!IsAdmin && !IsDeveloper)
            {
                MessageBox.Show("Только администратор или разработчик могут создавать проекты",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new ProjectForm(_currentUser);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ActivityLogger.Log(_currentUser.UserId, "Create", "Project", null,
                    "Создан проект");
                LoadProjects();
                MessageBox.Show("Проект создан", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            var project = GetSelectedProject();
            if (project == null)
            {
                MessageBox.Show("Выберите проект для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new ProjectForm(_currentUser, project);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ActivityLogger.Log(_currentUser.UserId, "Edit", "Project", project.ProjectId,
                    $"Отредактирован проект \"{project.Name}\"");
                LoadProjects();
                MessageBox.Show("Проект обновлён", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            var project = GetSelectedProject();
            if (project == null)
            {
                MessageBox.Show("Выберите проект для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Удалить проект \"{project.Name}\"? Все баги и комментарии " +
                "этого проекта также будут удалены.",
                "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            using (var db = new AppDbContext())
            {
                var entity = db.Projects.Find(project.ProjectId);
                if (entity != null)
                {
                    db.Projects.Remove(entity);
                    db.SaveChanges();
                }
            }

            ActivityLogger.Log(_currentUser.UserId, "Delete", "Project", project.ProjectId,
                $"Удалён проект \"{project.Name}\"");

            LoadProjects();
            MessageBox.Show("Проект удалён", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddBug_Click(object sender, EventArgs e)
        {
            // Все роли (Admin/Developer/Tester) могут создавать баги
            var project = GetSelectedProject();
            if (project == null)
            {
                MessageBox.Show("Сначала выберите проект", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new BugForm(_currentUser, project.ProjectId, IsTester);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ActivityLogger.Log(_currentUser.UserId, "Create", "Bug", null,
                    $"Создан баг в проекте \"{project.Name}\"");
                LoadBugs(project.ProjectId);
                MessageBox.Show("Баг создан", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditBug_Click(object sender, EventArgs e)
        {
            var project = GetSelectedProject();
            if (project == null)
            {
                MessageBox.Show("Сначала выберите проект", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bug = GetSelectedBug();
            if (bug == null)
            {
                MessageBox.Show("Выберите баг для редактирования", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsTester && bug.AuthorUserId != _currentUser.UserId)
            {
                MessageBox.Show("Вы можете редактировать только те баги, которые создали сами",
                    "Нет прав", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new BugForm(_currentUser, bug, IsTester);
            if (form.ShowDialog() == DialogResult.OK)
            {
                ActivityLogger.Log(_currentUser.UserId, "Edit", "Bug", bug.BugId,
                    $"Отредактирован баг \"{bug.Title}\"");
                LoadBugs(project.ProjectId);
                MessageBox.Show("Баг обновлён", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            var project = GetSelectedProject();
            if (project == null) return;

            var bug = GetSelectedBug();
            if (bug == null)
            {
                MessageBox.Show("Выберите баг для удаления", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Удалить баг \"{bug.Title}\"? Все комментарии будут удалены.",
                "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            using (var db = new AppDbContext())
            {
                var entity = db.Bugs.Find(bug.BugId);
                if (entity != null)
                {
                    db.Bugs.Remove(entity);
                    db.SaveChanges();
                }
            }

            ActivityLogger.Log(_currentUser.UserId, "Delete", "Bug", bug.BugId,
                $"Удалён баг \"{bug.Title}\"");

            LoadBugs(project.ProjectId);
            MessageBox.Show("Баг удалён", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            var bug = GetSelectedBug();
            if (bug == null)
            {
                MessageBox.Show("Выберите баг для просмотра комментариев", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new ViewCommentsForm(_currentUser, bug);
            form.ShowDialog();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            var project = GetSelectedProject();
            if (project == null)
            {
                MessageBox.Show("Сначала выберите проект", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? statusId = cmbFilterStatus.SelectedValue as int?;
            if (statusId == 0) statusId = null;

            int? priorityId = cmbFilterPriority.SelectedValue as int?;
            if (priorityId == 0) priorityId = null;

            int? assignedUserId = cmbFilterAssigned.SelectedValue as int?;
            if (assignedUserId == 0) assignedUserId = null;

            string searchTitle = txtSearchTitle.Text.Trim();

            LoadBugs(project.ProjectId, statusId, priorityId, assignedUserId, searchTitle);
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterPriority.SelectedIndex = 0;
            cmbFilterAssigned.SelectedIndex = 0;
            txtSearchTitle.Text = "";

            var project = GetSelectedProject();
            if (project != null)
            {
                LoadBugs(project.ProjectId);
            }
        }
    }
}
