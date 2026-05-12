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
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (name.Length > 100)
            {
                MessageBox.Show("Название проекта не может быть длиннее 100 символов",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Уникальность имени проекта
            int editingProjectId = _editingProject?.ProjectId ?? -1;
            bool nameTaken = _context.Projects.Any(p =>
                p.Name == name && p.ProjectId != editingProjectId);
            if (nameTaken)
            {
                MessageBox.Show("Проект с таким названием уже существует",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_editingProject == null)
                {
                    var project = new Project
                    {
                        Name = name,
                        Description = description,
                        CreatedDate = DateTime.Now,
                        OwnerUserId = _currentUser.UserId
                    };
                    _context.Projects.Add(project);
                }
                else
                {
                    _editingProject.Name = name;
                    _editingProject.Description = description;
                    _context.Projects.Update(_editingProject);
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
