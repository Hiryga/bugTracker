namespace NETbugTracker.Forms
{
    partial class UserEditForm
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
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblPasswordHint = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblLogin
            //
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(20, 20);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(50, 15);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:";
            //
            // txtLogin
            //
            txtLogin.Location = new Point(20, 40);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(280, 23);
            txtLogin.TabIndex = 1;
            //
            // lblFullName
            //
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(20, 75);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(38, 15);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "ФИО:";
            //
            // txtFullName
            //
            txtFullName.Location = new Point(20, 95);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(280, 23);
            txtFullName.TabIndex = 3;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 130);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "E-mail:";
            //
            // txtEmail
            //
            txtEmail.Location = new Point(20, 150);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 23);
            txtEmail.TabIndex = 5;
            //
            // lblRole
            //
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 185);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(40, 15);
            lblRole.TabIndex = 6;
            lblRole.Text = "Роль:";
            //
            // cmbRole
            //
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(20, 205);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(280, 23);
            cmbRole.TabIndex = 7;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(20, 240);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(56, 15);
            lblPassword.TabIndex = 8;
            lblPassword.Text = "Пароль:";
            //
            // txtPassword
            //
            txtPassword.Location = new Point(20, 260);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(280, 23);
            txtPassword.TabIndex = 9;
            //
            // lblPasswordHint
            //
            lblPasswordHint.AutoSize = true;
            lblPasswordHint.ForeColor = SystemColors.GrayText;
            lblPasswordHint.Location = new Point(20, 285);
            lblPasswordHint.Name = "lblPasswordHint";
            lblPasswordHint.Size = new Size(150, 15);
            lblPasswordHint.TabIndex = 10;
            lblPasswordHint.Text = "Минимум 4 символа";
            //
            // btnSave
            //
            btnSave.Location = new Point(20, 320);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 11;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            //
            // btnCancel
            //
            btnCancel.Location = new Point(180, 320);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            //
            // UserEditForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 370);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblPasswordHint);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
            Controls.Add(txtLogin);
            Controls.Add(lblLogin);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Пользователь";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRole;
        private ComboBox cmbRole;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblPasswordHint;
        private Button btnSave;
        private Button btnCancel;
    }
}
