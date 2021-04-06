using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.Threading.Tasks;
using System.Windows.Forms;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodView
{
    public partial class FormReport : Form
    {
        private readonly ReportLogic logicReport;

        public FormReport(ReportLogic reportLogic)
        {
            logicReport = reportLogic;
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadData()
        {
            try
            {
                var routes = logicReport.GetRoutes(new ReportBindingModel
                {
                    UserId = Program.User.Id,
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });

                if (routes != null)
                {
                    dataGridView.Rows.Clear();
                    int i = 0;
                    foreach (var route in routes)
                    {
                        var reserves = route.Reserves;
                        dataGridView.Rows.Add(new object[] { route.Name, route.Count, reserves[0].Name, route.DateVisit.ToString("d"), route.Cost });
                        
                        if (dataGridView.Rows[i].Cells[2] is DataGridViewComboBoxCell cb)
                        {
                            cb.DataSource = reserves;
                            cb.ValueMember = "Name";
                            cb.DisplayMember = "Name";
                        }
                        ++i;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData();
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
