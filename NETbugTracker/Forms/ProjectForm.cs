using NETbugTracker.Data;
using NETbugTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETbugTracker.Forms
{
    public partial class ProjectForm : Form
    {
        private AppDbContext _context;
        private Project _editingProject;
        private User _currentUser;

        // Конструктор для создания нового проекта
        public ProjectForm(User currentUser)
        {
            InitializeComponent();
            _context = new AppDbContext();
            _currentUser = currentUser;
            _editingProject = null;
            this.Text = "Новый проект";
        }

        // Конструктор для редактирования существующего проекта
        public ProjectForm(User currentUser, Project project) : this(currentUser)
        {
            _editingProject = project;
            this.Text = "Редактирование проекта";

            // Заполняем поля
            txtName.Text = project.Name;
            txtDescription.Text = project.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка: название не пустое
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_editingProject == null)
            {
                // Создание нового проекта
                var project = new Project
                {
                    Name = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    CreatedDate = DateTime.Now,
                    OwnerUserId = _currentUser.UserId
                };
                _context.Projects.Add(project);
            }
            else
            {
                // Редактирование существующего
                _editingProject.Name = txtName.Text.Trim();
                _editingProject.Description = txtDescription.Text.Trim();
                _context.Projects.Update(_editingProject);
            }

            _context.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
