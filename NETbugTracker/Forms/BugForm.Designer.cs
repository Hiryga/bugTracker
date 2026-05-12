namespace NETbugTracker.Forms
{
    partial class BugForm
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            txtStepsToReproduce = new TextBox();
            grpDetails = new GroupBox();
            label4 = new Label();
            cmbAssignedUser = new ComboBox();
            label5 = new Label();
            cmbPriority = new ComboBox();
            label6 = new Label();
            cmbStatus = new ComboBox();
            label7 = new Label();
            dtpDueDate = new DateTimePicker();
            chkNoDueDate = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = false;
            label1.Location = new Point(18, 14);
            label1.Name = "label1";
            label1.Size = new Size(130, 18);
            label1.Text = "Заголовок:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(18, 34);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(330, 23);
            txtTitle.TabIndex = 0;
            txtTitle.MaxLength = 200;
            // 
            // label2
            // 
            label2.AutoSize = false;
            label2.Location = new Point(18, 70);
            label2.Name = "label2";
            label2.Size = new Size(130, 18);
            label2.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(18, 90);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(330, 80);
            txtDescription.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = false;
            label3.Location = new Point(18, 184);
            label3.Name = "label3";
            label3.Size = new Size(160, 18);
            label3.Text = "Шаги воспроизведения:";
            // 
            // txtStepsToReproduce
            // 
            txtStepsToReproduce.Location = new Point(18, 204);
            txtStepsToReproduce.Multiline = true;
            txtStepsToReproduce.Name = "txtStepsToReproduce";
            txtStepsToReproduce.ScrollBars = ScrollBars.Vertical;
            txtStepsToReproduce.Size = new Size(330, 130);
            txtStepsToReproduce.TabIndex = 2;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(cmbAssignedUser);
            grpDetails.Controls.Add(label5);
            grpDetails.Controls.Add(cmbPriority);
            grpDetails.Controls.Add(label6);
            grpDetails.Controls.Add(cmbStatus);
            grpDetails.Controls.Add(label7);
            grpDetails.Controls.Add(dtpDueDate);
            grpDetails.Controls.Add(chkNoDueDate);
            grpDetails.Location = new Point(370, 14);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(230, 320);
            grpDetails.TabStop = false;
            grpDetails.Text = "Параметры";
            // 
            // label4
            // 
            label4.AutoSize = false;
            label4.Location = new Point(14, 26);
            label4.Name = "label4";
            label4.Size = new Size(150, 18);
            label4.Text = "Исполнитель:";
            // 
            // cmbAssignedUser
            // 
            cmbAssignedUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedUser.FormattingEnabled = true;
            cmbAssignedUser.Location = new Point(14, 46);
            cmbAssignedUser.Name = "cmbAssignedUser";
            cmbAssignedUser.Size = new Size(200, 23);
            cmbAssignedUser.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = false;
            label5.Location = new Point(14, 80);
            label5.Name = "label5";
            label5.Size = new Size(150, 18);
            label5.Text = "Приоритет:";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(14, 100);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(200, 23);
            cmbPriority.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = false;
            label6.Location = new Point(14, 134);
            label6.Name = "label6";
            label6.Size = new Size(150, 18);
            label6.Text = "Статус:";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(14, 154);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = false;
            label7.Location = new Point(14, 188);
            label7.Name = "label7";
            label7.Size = new Size(150, 18);
            label7.Text = "Дедлайн:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(14, 208);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(200, 23);
            dtpDueDate.TabIndex = 3;
            // 
            // chkNoDueDate
            // 
            chkNoDueDate.AutoSize = true;
            chkNoDueDate.Location = new Point(14, 238);
            chkNoDueDate.Name = "chkNoDueDate";
            chkNoDueDate.Size = new Size(120, 19);
            chkNoDueDate.TabIndex = 4;
            chkNoDueDate.Text = "Без дедлайна";
            chkNoDueDate.UseVisualStyleBackColor = true;
            chkNoDueDate.CheckedChanged += chkNoDueDate_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(380, 354);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(105, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(495, 354);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 400);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(label1);
            Controls.Add(txtTitle);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(txtStepsToReproduce);
            Controls.Add(grpDetails);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "BugForm";
            Text = "Баг";
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtDescription;
        private Label label3;
        private TextBox txtStepsToReproduce;
        private GroupBox grpDetails;
        private Label label4;
        private ComboBox cmbAssignedUser;
        private Label label5;
        private ComboBox cmbPriority;
        private Label label6;
        private ComboBox cmbStatus;
        private Label label7;
        private DateTimePicker dtpDueDate;
        private CheckBox chkNoDueDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
