
namespace UrskiyPeriodView
{
    partial class FormReserves
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.buttonSaveToWord = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonCancel.Location = new System.Drawing.Point(308, 300);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSaveToExcel.Location = new System.Drawing.Point(227, 300);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToExcel.TabIndex = 2;
            this.buttonSaveToExcel.Text = "Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = false;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // buttonSaveToWord
            // 
            this.buttonSaveToWord.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSaveToWord.Location = new System.Drawing.Point(146, 300);
            this.buttonSaveToWord.Name = "buttonSaveToWord";
            this.buttonSaveToWord.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToWord.TabIndex = 3;
            this.buttonSaveToWord.Text = "Word";
            this.buttonSaveToWord.UseVisualStyleBackColor = false;
            this.buttonSaveToWord.Click += new System.EventHandler(this.buttonSaveToWord_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(449, 282);
            this.dataGridView.TabIndex = 4;
            // 
            // FormReserves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 335);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonSaveToWord);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.buttonCancel);
            this.Name = "FormReserves";
            this.Text = "Список Заповедников";
            this.Load += new System.EventHandler(this.FormReserves_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.Button buttonSaveToWord;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}