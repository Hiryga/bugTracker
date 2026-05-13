namespace NETbugTracker.Forms
{
    partial class ReportForm
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
            grpFilter = new GroupBox();
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            lblProject = new Label();
            cmbProject = new ComboBox();
            btnBuild = new Button();
            dgvReport = new DataGridView();
            lblTotal = new Label();
            btnClose = new Button();
            toolTip1 = new ToolTip(components);
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(lblReportType);
            grpFilter.Controls.Add(cmbReportType);
            grpFilter.Controls.Add(lblProject);
            grpFilter.Controls.Add(cmbProject);
            grpFilter.Controls.Add(btnBuild);
            grpFilter.Location = new Point(15, 12);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(750, 75);
            grpFilter.TabStop = false;
            grpFilter.Text = "Параметры отчёта";
            grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = false;
            lblReportType.Location = new Point(12, 22);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(95, 18);
            lblReportType.Text = "Тип отчёта:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(12, 42);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(220, 23);
            cmbReportType.TabIndex = 0;
            // 
            // lblProject
            // 
            lblProject.AutoSize = false;
            lblProject.Location = new Point(245, 22);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(95, 18);
            lblProject.Text = "Проект:";
            // 
            // cmbProject
            // 
            cmbProject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProject.FormattingEnabled = true;
            cmbProject.Location = new Point(245, 42);
            cmbProject.Name = "cmbProject";
            cmbProject.Size = new Size(250, 23);
            cmbProject.TabIndex = 1;
            // 
            // btnBuild
            // 
            btnBuild.Location = new Point(620, 40);
            btnBuild.Name = "btnBuild";
            btnBuild.Size = new Size(120, 28);
            btnBuild.TabIndex = 2;
            btnBuild.Text = "Сформировать";
            btnBuild.UseVisualStyleBackColor = true;
            btnBuild.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuild.Click += btnBuild_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AllowUserToResizeRows = false;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 245, 245)
            };
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.Location = new Point(15, 100);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(750, 360);
            dgvReport.TabIndex = 3;
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(15, 470);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(110, 19);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Всего багов: 0";
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(645, 467);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 28);
            btnClose.TabIndex = 5;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Click += btnClose_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 510);
            MinimumSize = new Size(700, 400);
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(grpFilter);
            Controls.Add(dgvReport);
            Controls.Add(lblTotal);
            Controls.Add(btnClose);
            Name = "ReportForm";
            Text = "Отчёты";
            grpFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();

            toolTip1.SetToolTip(btnBuild, "Сформировать отчёт по выбранным параметрам");
            toolTip1.SetToolTip(btnClose, "Закрыть окно");
        }

        #endregion

        private GroupBox grpFilter;
        private Label lblReportType;
        private ComboBox cmbReportType;
        private Label lblProject;
        private ComboBox cmbProject;
        private Button btnBuild;
        private DataGridView dgvReport;
        private Label lblTotal;
        private Button btnClose;
        private ToolTip toolTip1;
    }
}
