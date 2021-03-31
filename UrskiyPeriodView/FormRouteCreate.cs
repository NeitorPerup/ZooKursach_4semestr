using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Unity;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrskiyPeriodView
{
    public partial class FormRouteCreate : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormRouteCreate()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
