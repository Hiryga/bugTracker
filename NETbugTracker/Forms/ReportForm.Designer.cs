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
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            lblProject = new Label();
            cmbProject = new ComboBox();
            btnBuild = new Button();
            dgvReport = new DataGridView();
            lblTotal = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            //
            // lblReportType
            //
            lblReportType.AutoSize = true;
            lblReportType.Location = new Point(15, 18);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(85, 15);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Тип отчёта:";
            //
            // cmbReportType
            //
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(105, 15);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(200, 23);
            cmbReportType.TabIndex = 1;
            //
            // lblProject
            //
            lblProject.AutoSize = true;
            lblProject.Location = new Point(325, 18);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(55, 15);
            lblProject.TabIndex = 2;
            lblProject.Text = "Проект:";
            //
            // cmbProject
            //
            cmbProject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProject.FormattingEnabled = true;
            cmbProject.Location = new Point(385, 15);
            cmbProject.Name = "cmbProject";
            cmbProject.Size = new Size(220, 23);
            cmbProject.TabIndex = 3;
            //
            // btnBuild
            //
            btnBuild.Location = new Point(625, 13);
            btnBuild.Name = "btnBuild";
            btnBuild.Size = new Size(140, 28);
            btnBuild.TabIndex = 4;
            btnBuild.Text = "Сформировать";
            btnBuild.UseVisualStyleBackColor = true;
            btnBuild.Click += btnBuild_Click;
            //
            // dgvReport
            //
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(15, 55);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 25;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(750, 400);
            dgvReport.TabIndex = 5;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(15, 470);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(110, 19);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Всего багов: 0";
            //
            // btnClose
            //
            btnClose.Location = new Point(625, 465);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 28);
            btnClose.TabIndex = 7;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            //
            // ReportForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 510);
            Controls.Add(btnClose);
            Controls.Add(lblTotal);
            Controls.Add(dgvReport);
            Controls.Add(btnBuild);
            Controls.Add(cmbProject);
            Controls.Add(lblProject);
            Controls.Add(cmbReportType);
            Controls.Add(lblReportType);
            MinimumSize = new Size(700, 400);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Отчёты";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReportType;
        private ComboBox cmbReportType;
        private Label lblProject;
        private ComboBox cmbProject;
        private Button btnBuild;
        private DataGridView dgvReport;
        private Label lblTotal;
        private Button btnClose;
    }
}
