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

        public FormMain(UserLogic userLogic)
        {
            _userLogic = userLogic;
            Program.User = _userLogic.Read(new UserBindingModel { Email = "user" })?[0];
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
    }
}
