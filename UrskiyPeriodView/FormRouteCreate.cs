using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Unity;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodView
{
    public partial class FormRouteCreate : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private int? id;

        private RouteLogic logic;

        public FormRouteCreate(RouteLogic routeLogic)
        {
            logic = routeLogic;
            InitializeComponent();
        }

        private void FormRouteCreate_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (id.HasValue)
            {
                var route = logic.Read(new RouteBindingModel { Id = id })?[0];
                if (route == null)
                {
                    return;
                }
                textBoxName.Text = route.Name;
                dateTimePicker.Value = route.DateVisit;
            }           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonReserves_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название маршрута", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTimePicker.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Выберите дату больше сегодняшней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormRoute>();
            form.RouteName = textBoxName.Text;
            form.Date = dateTimePicker.Value.Date;
            if (id.HasValue)
                form.RouteId = id.Value;
            Hide();
            if (form.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Show();
            }
        }
    }
}
