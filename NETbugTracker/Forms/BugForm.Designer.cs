namespace NETbugTracker.Forms
{
    partial class BugForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            txtStepsToReproduce = new TextBox();
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 26);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "\"Заголовок\"";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(37, 44);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 23);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 80);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "\"Описание\"";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(37, 108);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 60);
            txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 187);
            label3.Name = "label3";
            label3.Size = new Size(145, 15);
            label3.TabIndex = 4;
            label3.Text = "\"Шаги воспроизведения\"";
            // 
            // txtStepsToReproduce
            // 
            txtStepsToReproduce.Location = new Point(37, 216);
            txtStepsToReproduce.Multiline = true;
            txtStepsToReproduce.Name = "txtStepsToReproduce";
            txtStepsToReproduce.Size = new Size(200, 60);
            txtStepsToReproduce.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 294);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 6;
            label4.Text = "\"Исполнитель\"";
            // 
            // cmbAssignedUser
            // 
            cmbAssignedUser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAssignedUser.FormattingEnabled = true;
            cmbAssignedUser.Location = new Point(40, 321);
            cmbAssignedUser.Name = "cmbAssignedUser";
            cmbAssignedUser.Size = new Size(200, 23);
            cmbAssignedUser.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 359);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 8;
            label5.Text = "\"Приоритет\"";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Location = new Point(40, 388);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(200, 23);
            cmbPriority.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 428);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 10;
            label6.Text = "\"Статус\"";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(37, 457);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(200, 23);
            cmbStatus.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 495);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 12;
            label7.Text = "\"Дедлайн\"";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(37, 526);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(200, 23);
            dtpDueDate.TabIndex = 13;
            // 
            // chkNoDueDate
            // 
            chkNoDueDate.AutoSize = true;
            chkNoDueDate.Location = new Point(37, 565);
            chkNoDueDate.Name = "chkNoDueDate";
            chkNoDueDate.Size = new Size(111, 19);
            chkNoDueDate.TabIndex = 14;
            chkNoDueDate.Text = " \"Без дедлайна\"";
            chkNoDueDate.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(37, 603);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 15;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(148, 603);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // BugForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 685);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(chkNoDueDate);
            Controls.Add(dtpDueDate);
            Controls.Add(label7);
            Controls.Add(cmbStatus);
            Controls.Add(label6);
            Controls.Add(cmbPriority);
            Controls.Add(label5);
            Controls.Add(cmbAssignedUser);
            Controls.Add(label4);
            Controls.Add(txtStepsToReproduce);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "BugForm";
            Text = "BugForm";
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