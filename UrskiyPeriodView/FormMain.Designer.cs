
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
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.buttonSignIn = new System.Windows.Forms.Button();
            this.buttonReserves = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.buttonRoute = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBoxMenu.Controls.Add(this.buttonSignUp);
            this.groupBoxMenu.Controls.Add(this.buttonSignIn);
            this.groupBoxMenu.Controls.Add(this.buttonReserves);
            this.groupBoxMenu.Controls.Add(this.buttonReport);
            this.groupBoxMenu.Controls.Add(this.buttonPay);
            this.groupBoxMenu.Controls.Add(this.buttonRoute);
            this.groupBoxMenu.Location = new System.Drawing.Point(2, 3);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(652, 30);
            this.groupBoxMenu.TabIndex = 1;
            this.groupBoxMenu.TabStop = false;
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(559, 1);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(84, 23);
            this.buttonSignUp.TabIndex = 6;
            this.buttonSignUp.Text = "Регистрация";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // buttonSignIn
            // 
            this.buttonSignIn.Location = new System.Drawing.Point(487, 1);
            this.buttonSignIn.Name = "buttonSignIn";
            this.buttonSignIn.Size = new System.Drawing.Size(55, 23);
            this.buttonSignIn.TabIndex = 5;
            this.buttonSignIn.Text = "Вход";
            this.buttonSignIn.UseVisualStyleBackColor = true;
            this.buttonSignIn.Click += new System.EventHandler(this.buttonSignIn_Click);
            // 
            // buttonReserves
            // 
            this.buttonReserves.Location = new System.Drawing.Point(207, 1);
            this.buttonReserves.Name = "buttonReserves";
            this.buttonReserves.Size = new System.Drawing.Size(87, 23);
            this.buttonReserves.TabIndex = 4;
            this.buttonReserves.Text = "Заповедники";
            this.buttonReserves.UseVisualStyleBackColor = true;
            this.buttonReserves.Click += new System.EventHandler(this.buttonReserves_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(311, 1);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(75, 23);
            this.buttonReport.TabIndex = 3;
            this.buttonReport.Text = "Отчёт";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(114, 1);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(75, 23);
            this.buttonPay.TabIndex = 2;
            this.buttonPay.Text = "Оплата";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // buttonRoute
            // 
            this.buttonRoute.Location = new System.Drawing.Point(22, 0);
            this.buttonRoute.Name = "buttonRoute";
            this.buttonRoute.Size = new System.Drawing.Size(75, 23);
            this.buttonRoute.TabIndex = 0;
            this.buttonRoute.Text = "Маршруты";
            this.buttonRoute.UseVisualStyleBackColor = true;
            this.buttonRoute.Click += new System.EventHandler(this.buttonRoute_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UrskiyPeriodView.Properties.Resources.zoo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(2, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(652, 330);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 364);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxMenu);
            this.Name = "FormMain";
            this.Text = "Основная форма";
            this.groupBoxMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonRoute;
        private System.Windows.Forms.Button buttonReserves;
        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Button buttonSignIn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}