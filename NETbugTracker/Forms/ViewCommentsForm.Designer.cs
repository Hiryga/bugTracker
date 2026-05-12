namespace NETbugTracker.Forms
{
    partial class ViewCommentsForm
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
            lblBugTitle = new Label();
            dgvComments = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvComments).BeginInit();
            SuspendLayout();
            // 
            // lblBugTitle
            // 
            lblBugTitle.AutoSize = true;
            lblBugTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblBugTitle.Location = new Point(15, 15);
            lblBugTitle.Name = "lblBugTitle";
            lblBugTitle.Size = new Size(38, 19);
            lblBugTitle.TabIndex = 0;
            lblBugTitle.Text = "Баг:";
            // 
            // dgvComments
            // 
            dgvComments.AllowUserToAddRows = false;
            dgvComments.AllowUserToDeleteRows = false;
            dgvComments.AllowUserToResizeRows = false;
            dgvComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComments.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 245, 245)
            };
            dgvComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvComments.Location = new Point(15, 45);
            dgvComments.MultiSelect = false;
            dgvComments.Name = "dgvComments";
            dgvComments.ReadOnly = true;
            dgvComments.RowHeadersVisible = false;
            dgvComments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComments.Size = new Size(770, 385);
            dgvComments.TabIndex = 0;
            dgvComments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 445);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 30);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Добавить комментарий";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(180, 445);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(105, 30);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(680, 445);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(105, 30);
            btnClose.TabIndex = 3;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Click += btnClose_Click;
            // 
            // ViewCommentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            MinimumSize = new Size(700, 400);
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(lblBugTitle);
            Controls.Add(dgvComments);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnClose);
            Name = "ViewCommentsForm";
            Text = "Комментарии";
            ((System.ComponentModel.ISupportInitialize)dgvComments).EndInit();
            ResumeLayout(false);
            PerformLayout();

            toolTip1.SetToolTip(btnAdd, "Добавить новый комментарий к выбранному багу");
            toolTip1.SetToolTip(btnDelete, "Удалить выбранный комментарий");
            toolTip1.SetToolTip(btnClose, "Закрыть окно");
        }

        #endregion

        private Label lblBugTitle;
        private DataGridView dgvComments;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClose;
        private ToolTip toolTip1;
    }
}
