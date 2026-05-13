namespace NETbugTracker.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            сменитьПарольToolStripMenuItem = new ToolStripMenuItem();
            выйтиToolStripMenuItem = new ToolStripMenuItem();
            администрированиеToolStripMenuItem = new ToolStripMenuItem();
            пользователиToolStripMenuItem = new ToolStripMenuItem();
            журналДействийToolStripMenuItem = new ToolStripMenuItem();
            отчётыToolStripMenuItem = new ToolStripMenuItem();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();

            groupProjects = new GroupBox();
            dgvProjects = new DataGridView();
            btnAddProject = new Button();
            btnEditProject = new Button();
            btnDeleteProject = new Button();

            groupFilter = new GroupBox();
            label1 = new Label();
            cmbFilterStatus = new ComboBox();
            label2 = new Label();
            cmbFilterPriority = new ComboBox();
            label3 = new Label();
            cmbFilterAssigned = new ComboBox();
            label4 = new Label();
            txtSearchTitle = new TextBox();
            btnApplyFilter = new Button();
            btnResetFilter = new Button();

            groupBox1 = new GroupBox();
            dgvBugs = new DataGridView();
            btnAddBug = new Button();
            btnEditBug = new Button();
            btnDeleteBug = new Button();
            btnComments = new Button();

            statusStrip1 = new StatusStrip();
            lblStats = new ToolStripStatusLabel();

            toolTip1 = new ToolTip(components);

            menuStrip1.SuspendLayout();
            groupProjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            groupFilter.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBugs).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                файлToolStripMenuItem,
                администрированиеToolStripMenuItem,
                отчётыToolStripMenuItem,
                справкаToolStripMenuItem
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1280, 24);
            menuStrip1.TabIndex = 0;
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                сменитьПарольToolStripMenuItem,
                выйтиToolStripMenuItem
            });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // сменитьПарольToolStripMenuItem
            // 
            сменитьПарольToolStripMenuItem.Name = "сменитьПарольToolStripMenuItem";
            сменитьПарольToolStripMenuItem.Size = new Size(180, 22);
            сменитьПарольToolStripMenuItem.Text = "Сменить пароль";
            сменитьПарольToolStripMenuItem.Click += сменитьПарольToolStripMenuItem_Click;
            // 
            // выйтиToolStripMenuItem
            // 
            выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            выйтиToolStripMenuItem.Size = new Size(180, 22);
            выйтиToolStripMenuItem.Text = "Выход";
            выйтиToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // администрированиеToolStripMenuItem
            // 
            администрированиеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                пользователиToolStripMenuItem,
                журналДействийToolStripMenuItem
            });
            администрированиеToolStripMenuItem.Name = "администрированиеToolStripMenuItem";
            администрированиеToolStripMenuItem.Size = new Size(130, 20);
            администрированиеToolStripMenuItem.Text = "Администрирование";
            // 
            // пользователиToolStripMenuItem
            // 
            пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            пользователиToolStripMenuItem.Size = new Size(220, 22);
            пользователиToolStripMenuItem.Text = "Пользователи";
            пользователиToolStripMenuItem.Click += пользователиToolStripMenuItem_Click;
            // 
            // журналДействийToolStripMenuItem
            // 
            журналДействийToolStripMenuItem.Name = "журналДействийToolStripMenuItem";
            журналДействийToolStripMenuItem.Size = new Size(220, 22);
            журналДействийToolStripMenuItem.Text = "Журнал действий";
            журналДействийToolStripMenuItem.Click += журналДействийToolStripMenuItem_Click;
            // 
            // отчётыToolStripMenuItem
            // 
            отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            отчётыToolStripMenuItem.Size = new Size(63, 20);
            отчётыToolStripMenuItem.Text = "Отчёты";
            отчётыToolStripMenuItem.Click += отчётыToolStripMenuItem_Click;
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                оПрограммеToolStripMenuItem
            });
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(65, 20);
            справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(180, 22);
            оПрограммеToolStripMenuItem.Text = "О программе";
            оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;

            // 
            // groupProjects
            // 
            groupProjects.Controls.Add(btnAddProject);
            groupProjects.Controls.Add(btnEditProject);
            groupProjects.Controls.Add(btnDeleteProject);
            groupProjects.Controls.Add(dgvProjects);
            groupProjects.Location = new Point(12, 34);
            groupProjects.Name = "groupProjects";
            groupProjects.Size = new Size(380, 615);
            groupProjects.TabIndex = 1;
            groupProjects.TabStop = false;
            groupProjects.Text = "Проекты";
            groupProjects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // btnAddProject
            // 
            btnAddProject.Location = new Point(12, 26);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(115, 30);
            btnAddProject.TabIndex = 0;
            btnAddProject.Text = "Создать";
            btnAddProject.UseVisualStyleBackColor = true;
            btnAddProject.Click += btnAddProject_Click;
            // 
            // btnEditProject
            // 
            btnEditProject.Location = new Point(132, 26);
            btnEditProject.Name = "btnEditProject";
            btnEditProject.Size = new Size(115, 30);
            btnEditProject.TabIndex = 1;
            btnEditProject.Text = "Редактировать";
            btnEditProject.UseVisualStyleBackColor = true;
            btnEditProject.Click += btnEditProject_Click;
            // 
            // btnDeleteProject
            // 
            btnDeleteProject.Location = new Point(252, 26);
            btnDeleteProject.Name = "btnDeleteProject";
            btnDeleteProject.Size = new Size(115, 30);
            btnDeleteProject.TabIndex = 2;
            btnDeleteProject.Text = "Удалить";
            btnDeleteProject.UseVisualStyleBackColor = true;
            btnDeleteProject.Click += btnDeleteProject_Click;
            // 
            // dgvProjects
            // 
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.AllowUserToResizeRows = false;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 245, 245)
            };
            dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProjects.Location = new Point(12, 65);
            dgvProjects.MultiSelect = false;
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.RowHeadersVisible = false;
            dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjects.Size = new Size(355, 538);
            dgvProjects.TabIndex = 3;
            dgvProjects.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProjects.SelectionChanged += dgvProjects_SelectionChanged;

            // 
            // groupFilter
            // 
            groupFilter.Controls.Add(label1);
            groupFilter.Controls.Add(cmbFilterStatus);
            groupFilter.Controls.Add(label2);
            groupFilter.Controls.Add(cmbFilterPriority);
            groupFilter.Controls.Add(label3);
            groupFilter.Controls.Add(cmbFilterAssigned);
            groupFilter.Controls.Add(label4);
            groupFilter.Controls.Add(txtSearchTitle);
            groupFilter.Controls.Add(btnApplyFilter);
            groupFilter.Controls.Add(btnResetFilter);
            groupFilter.Location = new Point(400, 34);
            groupFilter.Name = "groupFilter";
            groupFilter.Size = new Size(868, 90);
            groupFilter.TabIndex = 2;
            groupFilter.TabStop = false;
            groupFilter.Text = "Фильтрация багов";
            groupFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(70, 18);
            label1.Text = "Статус:";
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Location = new Point(12, 43);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(140, 23);
            cmbFilterStatus.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new Point(160, 22);
            label2.Name = "label2";
            label2.Size = new Size(80, 18);
            label2.Text = "Приоритет:";
            // 
            // cmbFilterPriority
            // 
            cmbFilterPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPriority.FormattingEnabled = true;
            cmbFilterPriority.Location = new Point(160, 43);
            cmbFilterPriority.Name = "cmbFilterPriority";
            cmbFilterPriority.Size = new Size(140, 23);
            cmbFilterPriority.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = false;
            label3.Location = new Point(308, 22);
            label3.Name = "label3";
            label3.Size = new Size(90, 18);
            label3.Text = "Исполнитель:";
            // 
            // cmbFilterAssigned
            // 
            cmbFilterAssigned.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterAssigned.FormattingEnabled = true;
            cmbFilterAssigned.Location = new Point(308, 43);
            cmbFilterAssigned.Name = "cmbFilterAssigned";
            cmbFilterAssigned.Size = new Size(160, 23);
            cmbFilterAssigned.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = false;
            label4.Location = new Point(476, 22);
            label4.Name = "label4";
            label4.Size = new Size(140, 18);
            label4.Text = "Поиск по заголовку:";
            // 
            // txtSearchTitle
            // 
            txtSearchTitle.Location = new Point(476, 43);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(150, 23);
            txtSearchTitle.TabIndex = 3;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(636, 42);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(110, 26);
            btnApplyFilter.TabIndex = 4;
            btnApplyFilter.Text = "Применить";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(750, 42);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(110, 26);
            btnResetFilter.TabIndex = 5;
            btnResetFilter.Text = "Сбросить";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;

            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddBug);
            groupBox1.Controls.Add(btnEditBug);
            groupBox1.Controls.Add(btnDeleteBug);
            groupBox1.Controls.Add(btnComments);
            groupBox1.Controls.Add(dgvBugs);
            groupBox1.Location = new Point(400, 130);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(868, 519);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Баги";
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnAddBug
            // 
            btnAddBug.Location = new Point(12, 26);
            btnAddBug.Name = "btnAddBug";
            btnAddBug.Size = new Size(115, 30);
            btnAddBug.TabIndex = 0;
            btnAddBug.Text = "Создать";
            btnAddBug.UseVisualStyleBackColor = true;
            btnAddBug.Click += btnAddBug_Click;
            // 
            // btnEditBug
            // 
            btnEditBug.Location = new Point(132, 26);
            btnEditBug.Name = "btnEditBug";
            btnEditBug.Size = new Size(115, 30);
            btnEditBug.TabIndex = 1;
            btnEditBug.Text = "Редактировать";
            btnEditBug.UseVisualStyleBackColor = true;
            btnEditBug.Click += btnEditBug_Click;
            // 
            // btnDeleteBug
            // 
            btnDeleteBug.Location = new Point(252, 26);
            btnDeleteBug.Name = "btnDeleteBug";
            btnDeleteBug.Size = new Size(115, 30);
            btnDeleteBug.TabIndex = 2;
            btnDeleteBug.Text = "Удалить";
            btnDeleteBug.UseVisualStyleBackColor = true;
            btnDeleteBug.Click += btnDeleteBug_Click;
            // 
            // btnComments
            // 
            btnComments.Location = new Point(372, 26);
            btnComments.Name = "btnComments";
            btnComments.Size = new Size(140, 30);
            btnComments.TabIndex = 3;
            btnComments.Text = "Комментарии";
            btnComments.UseVisualStyleBackColor = true;
            btnComments.Click += btnComments_Click;
            // 
            // dgvBugs
            // 
            dgvBugs.AllowUserToAddRows = false;
            dgvBugs.AllowUserToDeleteRows = false;
            dgvBugs.AllowUserToResizeRows = false;
            dgvBugs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBugs.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 245, 245)
            };
            dgvBugs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBugs.Location = new Point(12, 65);
            dgvBugs.MultiSelect = false;
            dgvBugs.Name = "dgvBugs";
            dgvBugs.ReadOnly = true;
            dgvBugs.RowHeadersVisible = false;
            dgvBugs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBugs.Size = new Size(843, 442);
            dgvBugs.TabIndex = 4;
            dgvBugs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStats });
            statusStrip1.Location = new Point(0, 659);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1280, 22);
            statusStrip1.TabIndex = 4;
            // 
            // lblStats
            // 
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(120, 17);
            lblStats.Text = "Готово";

            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 681);
            MinimumSize = new Size(1100, 600);
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(groupProjects);
            Controls.Add(groupFilter);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "BugTracker";

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupProjects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            groupFilter.ResumeLayout(false);
            groupFilter.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBugs).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

            toolTip1.SetToolTip(btnAddProject, "Создать новый проект");
            toolTip1.SetToolTip(btnEditProject, "Редактировать выбранный проект");
            toolTip1.SetToolTip(btnDeleteProject, "Удалить выбранный проект (вместе с багами и комментариями)");
            toolTip1.SetToolTip(btnAddBug, "Создать новый баг в текущем проекте");
            toolTip1.SetToolTip(btnEditBug, "Редактировать выбранный баг");
            toolTip1.SetToolTip(btnDeleteBug, "Удалить выбранный баг");
            toolTip1.SetToolTip(btnComments, "Просмотреть комментарии к выбранному багу");
            toolTip1.SetToolTip(btnApplyFilter, "Применить выбранные фильтры");
            toolTip1.SetToolTip(btnResetFilter, "Сбросить все фильтры");
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem сменитьПарольToolStripMenuItem;
        private ToolStripMenuItem выйтиToolStripMenuItem;
        private ToolStripMenuItem администрированиеToolStripMenuItem;
        private ToolStripMenuItem пользователиToolStripMenuItem;
        private ToolStripMenuItem журналДействийToolStripMenuItem;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem справкаToolStripMenuItem;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;

        private GroupBox groupProjects;
        private DataGridView dgvProjects;
        private Button btnAddProject;
        private Button btnEditProject;
        private Button btnDeleteProject;

        private GroupBox groupFilter;
        private Label label1;
        private ComboBox cmbFilterStatus;
        private Label label2;
        private ComboBox cmbFilterPriority;
        private Label label3;
        private ComboBox cmbFilterAssigned;
        private Label label4;
        private TextBox txtSearchTitle;
        private Button btnApplyFilter;
        private Button btnResetFilter;

        private GroupBox groupBox1;
        private DataGridView dgvBugs;
        private Button btnAddBug;
        private Button btnEditBug;
        private Button btnDeleteBug;
        private Button btnComments;

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStats;
        private ToolTip toolTip1;
    }
}
