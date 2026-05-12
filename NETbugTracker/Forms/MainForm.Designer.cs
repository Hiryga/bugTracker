namespace NETbugTracker.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            dgvProjects = new DataGridView();
            btnAddProject = new Button();
            btnEditProject = new Button();
            btnDeleteProject = new Button();
            groupBox1 = new GroupBox();
            btnComments = new Button();
            btnDeleteBug = new Button();
            btnEditBug = new Button();
            btnAddBug = new Button();
            dgvBugs = new DataGridView();
            groupFilter = new GroupBox();
            btnResetFilter = new Button();
            btnApplyFilter = new Button();
            txtSearchTitle = new TextBox();
            label4 = new Label();
            cmbFilterAssigned = new ComboBox();
            label3 = new Label();
            cmbFilterPriority = new ComboBox();
            label2 = new Label();
            cmbFilterStatus = new ComboBox();
            label1 = new Label();
            statusStrip1 = new StatusStrip();
            lblStats = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBugs).BeginInit();
            groupFilter.SuspendLayout();
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
            menuStrip1.Size = new Size(1938, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
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
            выйтиToolStripMenuItem.Text = "Выйти";
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
            // dgvProjects
            //
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(21, 110);
            dgvProjects.MultiSelect = false;
            dgvProjects.Name = "dgvProjects";
            dgvProjects.ReadOnly = true;
            dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProjects.Size = new Size(466, 559);
            dgvProjects.TabIndex = 1;
            dgvProjects.SelectionChanged += dgvProjects_SelectionChanged;
            //
            // btnAddProject
            //
            btnAddProject.Location = new Point(21, 54);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(115, 30);
            btnAddProject.TabIndex = 2;
            btnAddProject.Text = "Создать проект";
            btnAddProject.UseVisualStyleBackColor = true;
            btnAddProject.Click += btnAddProject_Click;
            //
            // btnEditProject
            //
            btnEditProject.Location = new Point(142, 54);
            btnEditProject.Name = "btnEditProject";
            btnEditProject.Size = new Size(115, 30);
            btnEditProject.TabIndex = 3;
            btnEditProject.Text = "Редактировать";
            btnEditProject.UseVisualStyleBackColor = true;
            btnEditProject.Click += btnEditProject_Click;
            //
            // btnDeleteProject
            //
            btnDeleteProject.Location = new Point(263, 54);
            btnDeleteProject.Name = "btnDeleteProject";
            btnDeleteProject.Size = new Size(115, 30);
            btnDeleteProject.TabIndex = 4;
            btnDeleteProject.Text = "Удалить";
            btnDeleteProject.UseVisualStyleBackColor = true;
            btnDeleteProject.Click += btnDeleteProject_Click;
            //
            // groupBox1
            //
            groupBox1.Controls.Add(btnComments);
            groupBox1.Controls.Add(btnDeleteBug);
            groupBox1.Controls.Add(btnEditBug);
            groupBox1.Controls.Add(btnAddBug);
            groupBox1.Controls.Add(dgvBugs);
            groupBox1.Location = new Point(550, 123);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(772, 546);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Баги";
            //
            // btnComments
            //
            btnComments.Location = new Point(369, 21);
            btnComments.Name = "btnComments";
            btnComments.Size = new Size(140, 30);
            btnComments.TabIndex = 6;
            btnComments.Text = "Комментарии";
            btnComments.UseVisualStyleBackColor = true;
            btnComments.Click += btnComments_Click;
            //
            // btnDeleteBug
            //
            btnDeleteBug.Location = new Point(248, 21);
            btnDeleteBug.Name = "btnDeleteBug";
            btnDeleteBug.Size = new Size(115, 30);
            btnDeleteBug.TabIndex = 5;
            btnDeleteBug.Text = "Удалить";
            btnDeleteBug.UseVisualStyleBackColor = true;
            btnDeleteBug.Click += btnDeleteBug_Click;
            //
            // btnEditBug
            //
            btnEditBug.Location = new Point(127, 21);
            btnEditBug.Name = "btnEditBug";
            btnEditBug.Size = new Size(115, 30);
            btnEditBug.TabIndex = 4;
            btnEditBug.Text = "Редактировать";
            btnEditBug.UseVisualStyleBackColor = true;
            btnEditBug.Click += btnEditBug_Click;
            //
            // btnAddBug
            //
            btnAddBug.Location = new Point(6, 21);
            btnAddBug.Name = "btnAddBug";
            btnAddBug.Size = new Size(115, 30);
            btnAddBug.TabIndex = 3;
            btnAddBug.Text = "Создать баг";
            btnAddBug.UseVisualStyleBackColor = true;
            btnAddBug.Click += btnAddBug_Click;
            //
            // dgvBugs
            //
            dgvBugs.AllowUserToAddRows = false;
            dgvBugs.AllowUserToDeleteRows = false;
            dgvBugs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBugs.Location = new Point(6, 57);
            dgvBugs.MultiSelect = false;
            dgvBugs.Name = "dgvBugs";
            dgvBugs.ReadOnly = true;
            dgvBugs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBugs.Size = new Size(760, 480);
            dgvBugs.TabIndex = 0;
            //
            // groupFilter
            //
            groupFilter.Controls.Add(btnResetFilter);
            groupFilter.Controls.Add(btnApplyFilter);
            groupFilter.Controls.Add(txtSearchTitle);
            groupFilter.Controls.Add(label4);
            groupFilter.Controls.Add(cmbFilterAssigned);
            groupFilter.Controls.Add(label3);
            groupFilter.Controls.Add(cmbFilterPriority);
            groupFilter.Controls.Add(label2);
            groupFilter.Controls.Add(cmbFilterStatus);
            groupFilter.Controls.Add(label1);
            groupFilter.Location = new Point(550, 27);
            groupFilter.Name = "groupFilter";
            groupFilter.Size = new Size(772, 66);
            groupFilter.TabIndex = 6;
            groupFilter.TabStop = false;
            groupFilter.Text = "Фильтрация багов";
            //
            // btnResetFilter
            //
            btnResetFilter.Location = new Point(671, 16);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(96, 42);
            btnResetFilter.TabIndex = 9;
            btnResetFilter.Text = "Сбросить";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += btnResetFilter_Click;
            //
            // btnApplyFilter
            //
            btnApplyFilter.Location = new Point(569, 16);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(96, 42);
            btnApplyFilter.TabIndex = 8;
            btnApplyFilter.Text = "Применить фильтр";
            btnApplyFilter.UseVisualStyleBackColor = true;
            btnApplyFilter.Click += btnApplyFilter_Click;
            //
            // txtSearchTitle
            //
            txtSearchTitle.Location = new Point(420, 35);
            txtSearchTitle.Name = "txtSearchTitle";
            txtSearchTitle.Size = new Size(130, 23);
            txtSearchTitle.TabIndex = 7;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(420, 19);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 6;
            label4.Text = "Поиск по заголовку:";
            //
            // cmbFilterAssigned
            //
            cmbFilterAssigned.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterAssigned.FormattingEnabled = true;
            cmbFilterAssigned.Location = new Point(277, 35);
            cmbFilterAssigned.Name = "cmbFilterAssigned";
            cmbFilterAssigned.Size = new Size(121, 23);
            cmbFilterAssigned.TabIndex = 5;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(277, 19);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 4;
            label3.Text = "Исполнитель";
            //
            // cmbFilterPriority
            //
            cmbFilterPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterPriority.FormattingEnabled = true;
            cmbFilterPriority.Location = new Point(145, 37);
            cmbFilterPriority.Name = "cmbFilterPriority";
            cmbFilterPriority.Size = new Size(121, 23);
            cmbFilterPriority.TabIndex = 3;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(145, 19);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Приоритет";
            //
            // cmbFilterStatus
            //
            cmbFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Location = new Point(10, 39);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(121, 23);
            cmbFilterStatus.TabIndex = 1;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Статус";
            //
            // statusStrip1
            //
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStats });
            statusStrip1.Location = new Point(0, 689);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1938, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            //
            // lblStats
            //
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(120, 17);
            lblStats.Text = "Статистика по багам";
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1938, 711);
            Controls.Add(statusStrip1);
            Controls.Add(groupFilter);
            Controls.Add(groupBox1);
            Controls.Add(btnDeleteProject);
            Controls.Add(btnEditProject);
            Controls.Add(btnAddProject);
            Controls.Add(dgvProjects);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBugs).EndInit();
            groupFilter.ResumeLayout(false);
            groupFilter.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dgvProjects;
        private Button btnAddProject;
        private Button btnEditProject;
        private Button btnDeleteProject;
        private GroupBox groupBox1;
        private DataGridView dgvBugs;
        private Button btnAddBug;
        private Button btnDeleteBug;
        private Button btnEditBug;
        private Button btnComments;
        private GroupBox groupFilter;
        private Button btnResetFilter;
        private Button btnApplyFilter;
        private TextBox txtSearchTitle;
        private Label label4;
        private ComboBox cmbFilterAssigned;
        private Label label3;
        private ComboBox cmbFilterPriority;
        private Label label2;
        private ComboBox cmbFilterStatus;
        private Label label1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStats;
    }
}
