namespace NETbugTracker.Forms
{
    partial class ActivityLogForm
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
            dgvLog = new DataGridView();
            btnRefresh = new Button();
            btnClose = new Button();
            lblTotal = new Label();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvLog).BeginInit();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(15, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 28);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F);
            lblTotal.Location = new Point(150, 22);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(120, 15);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Записей: 0";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(865, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 28);
            btnClose.TabIndex = 2;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Click += btnClose_Click;
            // 
            // dgvLog
            // 
            dgvLog.AllowUserToAddRows = false;
            dgvLog.AllowUserToDeleteRows = false;
            dgvLog.AllowUserToResizeRows = false;
            dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLog.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 245, 245)
            };
            dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLog.Location = new Point(15, 55);
            dgvLog.MultiSelect = false;
            dgvLog.Name = "dgvLog";
            dgvLog.ReadOnly = true;
            dgvLog.RowHeadersVisible = false;
            dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLog.Size = new Size(970, 475);
            dgvLog.TabIndex = 3;
            dgvLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // ActivityLogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 545);
            MinimumSize = new Size(800, 400);
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(btnRefresh);
            Controls.Add(lblTotal);
            Controls.Add(btnClose);
            Controls.Add(dgvLog);
            Name = "ActivityLogForm";
            Text = "Журнал действий";
            ((System.ComponentModel.ISupportInitialize)dgvLog).EndInit();
            ResumeLayout(false);
            PerformLayout();

            toolTip1.SetToolTip(btnRefresh, "Перезагрузить журнал");
            toolTip1.SetToolTip(btnClose, "Закрыть окно");
        }

        #endregion

        private DataGridView dgvLog;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblTotal;
        private ToolTip toolTip1;
    }
}
