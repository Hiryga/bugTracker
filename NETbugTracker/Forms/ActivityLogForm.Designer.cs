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
            dgvLog = new DataGridView();
            btnRefresh = new Button();
            btnClose = new Button();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLog).BeginInit();
            SuspendLayout();
            //
            // dgvLog
            //
            dgvLog.AllowUserToAddRows = false;
            dgvLog.AllowUserToDeleteRows = false;
            dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLog.Location = new Point(15, 50);
            dgvLog.MultiSelect = false;
            dgvLog.Name = "dgvLog";
            dgvLog.ReadOnly = true;
            dgvLog.RowHeadersWidth = 25;
            dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLog.Size = new Size(970, 480);
            dgvLog.TabIndex = 0;
            //
            // btnRefresh
            //
            btnRefresh.Location = new Point(15, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 28);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            //
            // btnClose
            //
            btnClose.Location = new Point(845, 15);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 28);
            btnClose.TabIndex = 2;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            //
            // lblTotal
            //
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(170, 22);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(120, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Записей: 0";
            //
            // ActivityLogForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 545);
            Controls.Add(lblTotal);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(dgvLog);
            MinimumSize = new Size(800, 400);
            Name = "ActivityLogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Журнал действий";
            ((System.ComponentModel.ISupportInitialize)dgvLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLog;
        private Button btnRefresh;
        private Button btnClose;
        private Label lblTotal;
    }
}
