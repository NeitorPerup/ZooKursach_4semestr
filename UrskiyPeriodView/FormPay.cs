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

        private readonly PaymentLogic _paymentLogic;

        public FormPay(RouteLogic routeLogic, PaymentLogic paymentLogic)
        {
            _routeLogic = routeLogic;
            _paymentLogic = paymentLogic;
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
            labelSum.Text = route.Cost.ToString();
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
            if (sum > Convert.ToInt32(textBoxSum.Text))
            {
                MessageBox.Show("Внесённая сумма не должна быть больше суммы к оплате", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _paymentLogic.CreateOrUpdate(new PaymentBindingModel
                {
                    PaymentDate = DateTime.Now,
                    Sum = sum,
                    RouteId = Convert.ToInt32(comboBoxRoute.SelectedValue)
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
    }
}
