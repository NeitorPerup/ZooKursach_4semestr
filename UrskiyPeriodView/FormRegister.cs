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
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodView
{
    public partial class FormRegister : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly UserLogic _userLogic;

        public FormRegister(UserLogic userLogic)
        {
            _userLogic = userLogic;
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле логин", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните электронную почту", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле Пароль", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UserBindingModel model = new UserBindingModel
                {
                    Email = textBoxEmail.Text,
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text
                };
                _userLogic.CreateOrUpdate(model);
                Program.User = _userLogic.Read(model)?[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }
    }
}
