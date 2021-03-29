using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrskiyPeriodView
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            string[] s = new string[] { "Заповедник_1", "Заповедник_2", "Заповедник_3" };

            dataGridView.Rows.Add(new object[] { "Маршрут_1", 3, s[0], 180, 1500 });

            (dataGridView.Columns[2] as DataGridViewComboBoxColumn).DataSource = s;
        }
    }
}
