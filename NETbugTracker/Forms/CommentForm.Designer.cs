namespace NETbugTracker.Forms
{
    partial class CommentForm
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
            lblText = new Label();
            txtComment = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblText
            //
            lblText.AutoSize = true;
            lblText.Location = new Point(15, 15);
            lblText.Name = "lblText";
            lblText.Size = new Size(150, 15);
            lblText.TabIndex = 0;
            lblText.Text = "Текст комментария:";
            //
            // txtComment
            //
            txtComment.AcceptsReturn = true;
            txtComment.Location = new Point(15, 35);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.ScrollBars = ScrollBars.Vertical;
            txtComment.Size = new Size(450, 180);
            txtComment.TabIndex = 1;
            //
            // btnSave
            //
            btnSave.Location = new Point(245, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 30);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.Location = new Point(360, 230);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            //
            // CommentForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 280);
            Font = new Font("Segoe UI", 9F);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtComment);
            Controls.Add(lblText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CommentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Комментарий";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblText;
        private TextBox txtComment;
        private Button btnSave;
        private Button btnCancel;
    }
}
