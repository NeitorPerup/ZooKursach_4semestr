
namespace UrskiyPeriodView
{
    partial class FormMain
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
            this.labelLogo = new System.Windows.Forms.Label();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.buttonRoute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLogo
            // 
            this.labelLogo.Location = new System.Drawing.Point(176, 121);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(56, 23);
            this.labelLogo.TabIndex = 0;
            this.labelLogo.Text = "Логотип";
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxMenu.Controls.Add(this.button1);
            this.groupBoxMenu.Controls.Add(this.buttonReport);
            this.groupBoxMenu.Controls.Add(this.buttonPay);
            this.groupBoxMenu.Controls.Add(this.buttonRoute);
            this.groupBoxMenu.Location = new System.Drawing.Point(2, 3);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(578, 30);
            this.groupBoxMenu.TabIndex = 1;
            this.groupBoxMenu.TabStop = false;
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(300, 1);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(75, 23);
            this.buttonReport.TabIndex = 3;
            this.buttonReport.Text = "Отчёт";
            this.buttonReport.UseVisualStyleBackColor = true;
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(114, 1);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(75, 23);
            this.buttonPay.TabIndex = 2;
            this.buttonPay.Text = "Оплата";
            this.buttonPay.UseVisualStyleBackColor = true;
            // 
            // buttonRoute
            // 
            this.buttonRoute.Location = new System.Drawing.Point(22, 0);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(75, 23);
            this.buttonRoute.TabIndex = 0;
            this.buttonRoute.Text = "Маршруты";
            this.buttonRoute.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Заповедники";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 258);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.labelLogo);
            this.Name = "FormMain";
            this.Text = "Основная форма";
            this.groupBoxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonRoute;
        private System.Windows.Forms.Button button1;
    }
}