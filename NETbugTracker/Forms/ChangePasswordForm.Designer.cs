namespace NETbugTracker.Forms
{
    partial class ChangePasswordForm
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
            lblOld = new Label();
            txtOldPassword = new TextBox();
            lblNew = new Label();
            txtNewPassword = new TextBox();
            lblConfirm = new Label();
            txtConfirmPassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblOld
            //
            lblOld.AutoSize = true;
            lblOld.Location = new Point(20, 20);
            lblOld.Name = "lblOld";
            lblOld.Size = new Size(98, 15);
            lblOld.TabIndex = 0;
            lblOld.Text = "Старый пароль:";
            //
            // txtOldPassword
            //
            txtOldPassword.Location = new Point(20, 40);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PasswordChar = '*';
            txtOldPassword.Size = new Size(280, 23);
            txtOldPassword.TabIndex = 1;
            //
            // lblNew
            //
            lblNew.AutoSize = true;
            lblNew.Location = new Point(20, 75);
            lblNew.Name = "lblNew";
            lblNew.Size = new Size(95, 15);
            lblNew.TabIndex = 2;
            lblNew.Text = "Новый пароль:";
            //
            // txtNewPassword
            //
            txtNewPassword.Location = new Point(20, 95);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(280, 23);
            txtNewPassword.TabIndex = 3;
            //
            // lblConfirm
            //
            lblConfirm.AutoSize = true;
            lblConfirm.Location = new Point(20, 130);
            lblConfirm.Name = "lblConfirm";
            lblConfirm.Size = new Size(150, 15);
            lblConfirm.TabIndex = 4;
            lblConfirm.Text = "Подтверждение пароля:";
            //
            // txtConfirmPassword
            //
            txtConfirmPassword.Location = new Point(20, 150);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(280, 23);
            txtConfirmPassword.TabIndex = 5;
            //
            // btnSave
            //
            btnSave.Location = new Point(20, 195);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.Location = new Point(180, 195);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            //
            // ChangePasswordForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 245);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirm);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNew);
            Controls.Add(txtOldPassword);
            Controls.Add(lblOld);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Смена пароля";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOld;
        private TextBox txtOldPassword;
        private Label lblNew;
        private TextBox txtNewPassword;
        private Label lblConfirm;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnCancel;
    }
}
