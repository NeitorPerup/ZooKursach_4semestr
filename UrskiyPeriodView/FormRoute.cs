using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodView
{
    public partial class FormRoute : Form
    {
        private readonly RouteLogic _routeLogic;

        private readonly ReserveLogic _reserveLogic;

        private List<ReserveViewModel> picked;

        private List<ReserveViewModel> reserves;

        public string RouteName { get; set; }

        public DateTime Date { get; set; }

        public FormRoute(RouteLogic routeLogic, ReserveLogic reserveLogic)
        {
            _routeLogic = routeLogic;
            _reserveLogic = reserveLogic;
            picked = new List<ReserveViewModel>();
            reserves = _reserveLogic.Read(null);           
            InitializeComponent();
        }

        private void FormRoute_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            labelRouteData.Text = $"Название маршрута: {RouteName}\nДата посещения: {Date.ToString("d")}";            
            if (reserves != null)
            {
                dataGridViewReserves.Rows.Clear();
                foreach (var reserve in reserves)
                {
                    dataGridViewReserves.Rows.Add(new object[] { reserve.Id, reserve.Name, reserve.Price });
                }             
            }
            if (picked != null)
            {
                dataGridViewPicked.Rows.Clear();
                foreach (var reserve in picked)
                {
                    dataGridViewPicked.Rows.Add(new object[] { reserve.Id, reserve.Name, reserve.Price });
                }
            }
        }

        // Добавляем заповедник к маршруту
        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (dataGridViewReserves.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewReserves.SelectedRows[0].Cells[0].Value);
                ReserveViewModel model = reserves.FirstOrDefault(x => x.Id == id);
                if (model == null){ return; }
                picked.Add(model);
                reserves.Remove(model);
                LoadData();
            }
        }

        // Удаляем заповедник из маршрута
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (dataGridViewPicked.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewPicked.SelectedRows[0].Cells[0].Value);
                ReserveViewModel model = picked.FirstOrDefault(x => x.Id == id);
                if (model == null) { return; }
                reserves.Add(model);
                picked.Remove(model);
                LoadData();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<int, string> routeUsers = new Dictionary<int, string>();
                routeUsers.Add(Program.User.Id, Program.User.Email);
                _routeLogic.CreateOrUpdate(new RouteBindingModel
                {
                    Name = RouteName,
                    Cost = picked.Sum(x => x.Price),
                    DateVisit = Date,
                    Count = picked.Count,
                    RouteUsers = routeUsers
                });
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
