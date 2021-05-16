using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly UserLogic _userLogic;

        private ReserveLogic _reserveLogic;

        private RouteLogic _routeLogic;

        private CostItemLogic _costItemLogic;

        public FormMain(UserLogic userLogic, ReserveLogic reserveLogic, RouteLogic routeLogic, CostItemLogic costItemLogic)
        {
            _userLogic = userLogic;
            _reserveLogic = reserveLogic;
            _routeLogic = routeLogic;
            _costItemLogic = costItemLogic;
            Program.User = _userLogic.Read(new UserBindingModel { Email = "user" })?[0]; // загружаем пользователя, чтобы каждый раз не проходить авторизацию
            DatabaseHelper.Load(_reserveLogic, _routeLogic, _userLogic, _costItemLogic); // загружаем заповедники если их нет в бд
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRegister>();
            form.ShowDialog();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAutorization>();
            form.ShowDialog();
        }

        private void buttonRoute_Click(object sender, EventArgs e)
        {
            if (Program.User == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormRoutes>();
            form.ShowDialog();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (Program.User == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormPay>();
            form.ShowDialog();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (Program.User == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }

        private void buttonReserves_Click(object sender, EventArgs e)
        {
            if (Program.User == null)
            {
                MessageBox.Show("Необходимо авторизироваться", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = Container.Resolve<FormReserves>();
            form.ShowDialog();
        }
    }
}
