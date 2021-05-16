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
    public partial class FormRoutes : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly RouteLogic _routeLogic;

        public FormRoutes(RouteLogic routeLogic)
        {
            _routeLogic = routeLogic;
            InitializeComponent();
        }

        private void FormRoutes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _routeLogic.Read(new RouteBindingModel { UserId = Program.User.Id});
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[6].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                    
                }
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRouteCreate>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }           
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRouteCreate>();
            form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        var route = _routeLogic.Read(new RouteBindingModel { Id = id })?[0];
                        _routeLogic.Delete(new RouteBindingModel 
                        { 
                            Id = id,
                            Name = route.Name,
                            Cost = route.Cost,
                            Count = route.Count,
                            DateVisit = route.DateVisit,
                            RouteReverces = route.RouteReverces
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
