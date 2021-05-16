using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodView
{   
    public partial class FormPay : Form
    {
        private readonly RouteLogic _routeLogic;

        private readonly ReserveLogic _reserveLogic;

        private readonly PaymentLogic _paymentLogic;

        List<ReserveViewModel> Reserves = new List<ReserveViewModel>();

        public FormPay(RouteLogic routeLogic, PaymentLogic paymentLogic, ReserveLogic reserveLogic)
        {
            _routeLogic = routeLogic;
            _paymentLogic = paymentLogic;
            _reserveLogic = reserveLogic;
            InitializeComponent();
        }

        private void FormPay_Load(object sender, EventArgs e)
        {
            LoadData();
            labelSum.Text = "";
        }

        private void LoadData()
        {
            try
            {
                var list = _routeLogic.Read(new RouteBindingModel { UserId = Program.User.Id });
                if (list != null)
                {
                    foreach (var route in list)
                    {
                        comboBoxRoute.DisplayMember = "Name";
                        comboBoxRoute.ValueMember = "Id";
                        comboBoxRoute.DataSource = list;
                        comboBoxRoute.SelectedItem = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxRoute_SelectedIndexChanged(object sender, EventArgs e)
        {
            var route = _routeLogic.Read(new RouteBindingModel { Id = Convert.ToInt32(comboBoxRoute.SelectedValue) })?[0];
            if (route == null)
                return;
            List<ReserveViewModel> reserves = new List<ReserveViewModel>();
            foreach (var res in route.RouteReverces)
            {
                var reserve = _reserveLogic.Read(new ReserveBindingModel { Id = res.Key })?[0];
                reserves.Add(reserve);
                if (!Reserves.Select(x => x.Name).Contains(reserve.Name))
                    Reserves.Add(reserve);
            }

            comboBoxReserve.DataSource = null;
            foreach (var res in reserves)
            {
                comboBoxReserve.DisplayMember = "Name";
                comboBoxRoute.ValueMember = "Id";
                comboBoxReserve.DataSource = reserves;
                comboBoxReserve.SelectedItem = null;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int sum;
            if (string.IsNullOrEmpty(comboBoxRoute.Text))
            {
                MessageBox.Show("Выберите маршрут", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(comboBoxReserve.Text))
            {
                MessageBox.Show("Выберите заповедник", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Введите сумму", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(textBoxSum.Text, out sum)) 
            {
                MessageBox.Show("Внесённая сумма должна быть целым числом", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sum <= 0)
            {
                MessageBox.Show("Внесённая сумма должна быть больше нуля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sum > Convert.ToDecimal(labelSum.Text))
            {
                MessageBox.Show("Внесённая сумма не должна быть больше суммы к оплате", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _paymentLogic.CreateOrUpdate(new PaymentBindingModel
                {
                    Sum = sum,
                    ReserveId = Convert.ToInt32(comboBoxRoute.SelectedValue),
                    UserId = Program.User.Id
                });
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex?.InnerException.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxReserve_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var t = comboBoxReserve.SelectedItem;
            comboBoxReserve.SelectedItem = null;
            comboBoxReserve.SelectedItem = t;
            var res = Reserves.FirstOrDefault(x => x.Name == comboBoxReserve.Text);
            labelSum.Text = res?.Price.ToString();
        }
    }
}
