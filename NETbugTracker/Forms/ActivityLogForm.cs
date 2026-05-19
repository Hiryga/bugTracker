using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using NETbugTracker.Data;

namespace NETbugTracker.Forms
{
    public partial class ActivityLogForm : Form
    {
        private const int MaxRows = 500;

        public ActivityLogForm()
        {
            InitializeComponent();
            this.Text = "Журнал действий";
            LoadLog();
        }

        private void LoadLog()
        {
            using var db = new AppDbContext();
            var logs = db.ActivityLogs
                .AsNoTracking()
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedDate)
                .Take(MaxRows)
                .ToList();

            var view = logs.Select(a => new
            {
                a.LogId,
                Дата = a.CreatedDate.ToString("g"),
                Пользователь = a.User != null ? a.User.Login : $"#{a.UserId}",
                Действие = a.ActionType,
                Объект = a.EntityType,
                ID_объекта = a.EntityId,
                Описание = a.Description
            }).ToList();

            dgvLog.DataSource = null;
            dgvLog.DataSource = view;

            if (dgvLog.Columns["LogId"] != null)
            {
                dgvLog.Columns["LogId"].HeaderText = "ID";
                dgvLog.Columns["LogId"].FillWeight = 40;
            }
            if (dgvLog.Columns["Дата"] != null) dgvLog.Columns["Дата"].FillWeight = 100;
            if (dgvLog.Columns["Пользователь"] != null) dgvLog.Columns["Пользователь"].FillWeight = 100;
            if (dgvLog.Columns["Действие"] != null) dgvLog.Columns["Действие"].FillWeight = 80;
            if (dgvLog.Columns["Объект"] != null) dgvLog.Columns["Объект"].FillWeight = 80;
            if (dgvLog.Columns["ID_объекта"] != null)
            {
                dgvLog.Columns["ID_объекта"].HeaderText = "ID объекта";
                dgvLog.Columns["ID_объекта"].FillWeight = 60;
            }
            if (dgvLog.Columns["Описание"] != null)
                dgvLog.Columns["Описание"].FillWeight = 240;

            lblTotal.Text = $"Записей показано: {view.Count} (максимум {MaxRows})";
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadLog();
        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
