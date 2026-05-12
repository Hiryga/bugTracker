namespace NETbugTracker.Forms
{
    partial class ProjectForm
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new Point(20, 18);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.Text = "Название проекта:";
            // 
            // txtName
            // 
            txtName.Location = new Point(20, 40);
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 23);
            txtName.TabIndex = 0;
            txtName.MaxLength = 100;
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new Point(20, 80);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(20, 102);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(420, 140);
            txtDescription.TabIndex = 1;
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(220, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 30);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(335, 260);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Click += btnCancel_Click;
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 310);
            MinimumSize = new Size(460, 310);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "ProjectForm";
            Text = "Проект";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtDescription;
        private Button btnSave;
        private Button btnCancel;
    }
}
