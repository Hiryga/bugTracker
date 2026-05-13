using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NETbugTracker.Data;
using NETbugTracker.Entities;

namespace NETbugTracker.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            this.Text = "Отчёты по багам";
            LoadProjectsFilter();
            cmbReportType.Items.AddRange(new object[]
            {
                "По статусам",
                "По приоритетам",
                "По исполнителям",
                "По проектам"
            });
            cmbReportType.SelectedIndex = 0;
            BuildReport();
        }

        private void LoadProjectsFilter()
        {
            using var db = new AppDbContext();
            var projects = db.Projects.OrderBy(p => p.Name).ToList();
            projects.Insert(0, new Project { ProjectId = 0, Name = "Все проекты" });
            cmbProject.DataSource = projects;
            cmbProject.DisplayMember = "Name";
            cmbProject.ValueMember = "ProjectId";
            cmbProject.SelectedIndex = 0;
        }

        private void btnBuild_Click(object sender, EventArgs e) => BuildReport();

        private void BuildReport()
        {
            int reportType = cmbReportType.SelectedIndex;
            int projectId = 0;
            if (cmbProject.SelectedValue is int v) projectId = v;

            using var db = new AppDbContext();
            IQueryable<Bug> bugsQuery = db.Bugs.AsNoTracking();
            if (projectId > 0)
                bugsQuery = bugsQuery.Where(b => b.ProjectId == projectId);

            List<ReportRow> rows;
            string groupHeader;

            switch (reportType)
            {
                case 0: // По статусам
                    groupHeader = "Статус";
                    rows = bugsQuery
                        .Include(b => b.Status)
                        .GroupBy(b => b.Status != null ? b.Status.StatusName : "—")
                        .Select(g => new ReportRow { Group = g.Key, Count = g.Count() })
                        .OrderByDescending(r => r.Count)
                        .ToList();
                    break;
                case 1: // По приоритетам
                    groupHeader = "Приоритет";
                    rows = bugsQuery
                        .Include(b => b.Priority)
                        .GroupBy(b => b.Priority != null ? b.Priority.PriorityName : "—")
                        .Select(g => new ReportRow { Group = g.Key, Count = g.Count() })
                        .OrderByDescending(r => r.Count)
                        .ToList();
                    break;
                case 2: // По исполнителям
                    groupHeader = "Исполнитель";
                    rows = bugsQuery
                        .Include(b => b.AssignedUser)
                        .GroupBy(b => b.AssignedUser != null ? b.AssignedUser.FullName : "—")
                        .Select(g => new ReportRow { Group = g.Key, Count = g.Count() })
                        .OrderByDescending(r => r.Count)
                        .ToList();
                    break;
                case 3: // По проектам
                    groupHeader = "Проект";
                    rows = bugsQuery
                        .Include(b => b.Project)
                        .GroupBy(b => b.Project != null ? b.Project.Name : "—")
                        .Select(g => new ReportRow { Group = g.Key, Count = g.Count() })
                        .OrderByDescending(r => r.Count)
                        .ToList();
                    break;
                default:
                    groupHeader = "Группа";
                    rows = new List<ReportRow>();
                    break;
            }

            int total = rows.Sum(r => r.Count);
            foreach (var row in rows)
            {
                row.Percent = total == 0 ? 0 : Math.Round((double)row.Count * 100 / total, 1);
            }

            dgvReport.DataSource = null;
            dgvReport.DataSource = rows;

            if (dgvReport.Columns["Group"] != null)
            {
                dgvReport.Columns["Group"].HeaderText = groupHeader;
                dgvReport.Columns["Group"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvReport.Columns["Count"] != null)
            {
                dgvReport.Columns["Count"].HeaderText = "Количество";
<<<<<<< HEAD
                dgvReport.Columns["Count"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
=======
                dgvReport.Columns["Count"].Width = 120;
>>>>>>> b8f2ddb196baeb74a2016175cdee6b5ef8f9368c
            }
            if (dgvReport.Columns["Percent"] != null)
            {
                dgvReport.Columns["Percent"].HeaderText = "Доля, %";
<<<<<<< HEAD
                dgvReport.Columns["Percent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
=======
                dgvReport.Columns["Percent"].Width = 100;
>>>>>>> b8f2ddb196baeb74a2016175cdee6b5ef8f9368c
            }

            lblTotal.Text = $"Всего багов: {total}";
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private class ReportRow
        {
            public string Group { get; set; } = string.Empty;
            public int Count { get; set; }
            public double Percent { get; set; }
        }
    }
}
