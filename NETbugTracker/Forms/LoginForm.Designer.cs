namespace NETbugTracker
{
    partial class LoginForm
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
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 32);
            lblTitle.Text = "BugTracker";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new Point(30, 70);
            label1.Name = "label1";
            label1.Size = new Size(90, 23);
            label1.Text = "Логин:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(130, 70);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(220, 23);
            txtLogin.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new Point(30, 110);
            label2.Name = "label2";
            label2.Size = new Size(90, 23);
            label2.Text = "Пароль:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(130, 110);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(220, 23);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(130, 165);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(105, 32);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(245, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 32);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.DialogResult = DialogResult.Cancel;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 220);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 9F);
            Controls.Add(lblTitle);
            Controls.Add(label1);
            Controls.Add(txtLogin);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnCancel);
            Name = "LoginForm";
            Text = "Вход в BugTracker";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private Label label2;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
    }
}
