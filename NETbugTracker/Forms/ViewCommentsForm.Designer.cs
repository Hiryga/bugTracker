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
            lblBugTitle = new Label();
            dgvComments = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvComments).BeginInit();
            SuspendLayout();
            //
            // lblBugTitle
            //
            lblBugTitle.AutoSize = true;
            lblBugTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
            dgvComments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComments.Location = new Point(15, 50);
            dgvComments.MultiSelect = false;
            dgvComments.Name = "dgvComments";
            dgvComments.ReadOnly = true;
            dgvComments.RowHeadersWidth = 25;
            dgvComments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvComments.Size = new Size(770, 380);
            dgvComments.TabIndex = 1;
            //
            // btnAdd
            //
            btnAdd.Location = new Point(15, 445);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить комментарий";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            //
            // btnDelete
            //
            btnDelete.Location = new Point(185, 445);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 30);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            //
            // btnClose
            //
            btnClose.Location = new Point(645, 445);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 30);
            btnClose.TabIndex = 4;
            btnClose.Text = "Закрыть";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            //
            // ViewCommentsForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvComments);
            Controls.Add(lblBugTitle);
            MinimumSize = new Size(700, 400);
            Name = "ViewCommentsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Комментарии";
            ((System.ComponentModel.ISupportInitialize)dgvComments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBugTitle;
        private DataGridView dgvComments;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClose;
    }
}
