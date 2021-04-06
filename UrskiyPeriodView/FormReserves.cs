using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;
using System.Windows.Forms;

namespace UrskiyPeriodView
{
    public partial class FormReserves : Form
    {
        private readonly RouteLogic _routeLogic;

        private readonly ReportLogic _reportLogic;

        public FormReserves(RouteLogic routeLogic, ReportLogic reportLogic)
        {
            _routeLogic = routeLogic;
            _reportLogic = reportLogic;
            InitializeComponent();
        }

        private void FormReserves_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _routeLogic.Read(new RouteBindingModel { UserId = Program.User.Id });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToWord_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                List<RouteViewModel> routes = new List<RouteViewModel>();
                foreach (var row in dataGridView.SelectedRows)
                {
                    routes.Add(_routeLogic.Read(new RouteBindingModel
                    {
                        Id = Convert.ToInt32((row as DataGridViewRow).Cells[0].Value)
                    })?[0]);
                }
                if (routes.Count == 0)
                {
                    MessageBox.Show("Выберите хотя бы один маршрут", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {                        
                        _reportLogic.SaveRoutesToWordFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            Routes = routes
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                List<RouteViewModel> routes = new List<RouteViewModel>();
                foreach (var row in dataGridView.SelectedRows)
                {
                    routes.Add(_routeLogic.Read(new RouteBindingModel
                    {
                        Id = Convert.ToInt32((row as DataGridViewRow).Cells[0].Value)
                    })?[0]);
                }
                if (routes.Count == 0)
                {
                    MessageBox.Show("Выберите хотя бы один маршрут", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _reportLogic.SaveReservesToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            Routes = routes
                        });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
