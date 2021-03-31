
namespace UrskiyPeriodView
{
    partial class FormRoute
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRouteData = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewReserves = new System.Windows.Forms.DataGridView();
            this.dataGridViewPicked = new System.Windows.Forms.DataGridView();
            this.buttonTake = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.RId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPicked)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRouteData
            // 
            this.labelRouteData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRouteData.Location = new System.Drawing.Point(168, 9);
            this.labelRouteData.Name = "labelRouteData";
            this.labelRouteData.Size = new System.Drawing.Size(341, 75);
            this.labelRouteData.TabIndex = 0;
            this.labelRouteData.Text = "Данные по маршруту";
            this.labelRouteData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSave.Location = new System.Drawing.Point(376, 326);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCancel.Location = new System.Drawing.Point(485, 326);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewReserves
            // 
            this.dataGridViewReserves.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewReserves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReserves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RId,
            this.RName,
            this.RPrice});
            this.dataGridViewReserves.Location = new System.Drawing.Point(376, 87);
            this.dataGridViewReserves.Name = "dataGridViewReserves";
            this.dataGridViewReserves.Size = new System.Drawing.Size(294, 214);
            this.dataGridViewReserves.TabIndex = 7;
            // 
            // dataGridViewPicked
            // 
            this.dataGridViewPicked.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewPicked.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPicked.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameRoute,
            this.Price});
            this.dataGridViewPicked.Location = new System.Drawing.Point(23, 87);
            this.dataGridViewPicked.Name = "dataGridViewPicked";
            this.dataGridViewPicked.Size = new System.Drawing.Size(294, 214);
            this.dataGridViewPicked.TabIndex = 8;
            // 
            // buttonTake
            // 
            this.buttonTake.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonTake.Location = new System.Drawing.Point(326, 134);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(34, 23);
            this.buttonTake.TabIndex = 9;
            this.buttonTake.Text = "<<";
            this.buttonTake.UseVisualStyleBackColor = false;
            this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonReturn.Location = new System.Drawing.Point(326, 223);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(34, 23);
            this.buttonReturn.TabIndex = 10;
            this.buttonReturn.Text = ">>";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // RId
            // 
            this.RId.HeaderText = "Id";
            this.RId.Name = "RId";
            this.RId.Visible = false;
            // 
            // RName
            // 
            this.RName.HeaderText = "Название заповедника";
            this.RName.Name = "RName";
            this.RName.Width = 150;
            // 
            // RPrice
            // 
            this.RPrice.HeaderText = "Цена";
            this.RPrice.Name = "RPrice";
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // NameRoute
            // 
            this.NameRoute.HeaderText = "Название заповедника";
            this.NameRoute.Name = "NameRoute";
            this.NameRoute.Width = 150;
            // 
            // Price
            // 
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            // 
            // FormRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 382);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonTake);
            this.Controls.Add(this.dataGridViewPicked);
            this.Controls.Add(this.dataGridViewReserves);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelRouteData);
            this.Name = "FormRoute";
            this.Text = "Выбор заповедников";
            this.Load += new System.EventHandler(this.FormRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReserves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPicked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRouteData;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewReserves;
        private System.Windows.Forms.DataGridView dataGridViewPicked;
        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RId;
        private System.Windows.Forms.DataGridViewTextBoxColumn RName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}