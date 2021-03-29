
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
            this.labelAvaliable = new System.Windows.Forms.Label();
            this.labelPicked = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRouteData
            // 
            this.labelRouteData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRouteData.Location = new System.Drawing.Point(12, 42);
            this.labelRouteData.Name = "labelRouteData";
            this.labelRouteData.Size = new System.Drawing.Size(141, 151);
            this.labelRouteData.TabIndex = 0;
            this.labelRouteData.Text = "Данные по маршруту";
            this.labelRouteData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAvaliable
            // 
            this.labelAvaliable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAvaliable.Location = new System.Drawing.Point(334, 42);
            this.labelAvaliable.Name = "labelAvaliable";
            this.labelAvaliable.Size = new System.Drawing.Size(100, 151);
            this.labelAvaliable.TabIndex = 1;
            this.labelAvaliable.Text = "Доступные для выбора заповедники";
            this.labelAvaliable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPicked
            // 
            this.labelPicked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPicked.Location = new System.Drawing.Point(168, 42);
            this.labelPicked.Name = "labelPicked";
            this.labelPicked.Size = new System.Drawing.Size(100, 151);
            this.labelPicked.TabIndex = 2;
            this.labelPicked.Text = "Выбранные заповедники";
            this.labelPicked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(284, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "<<";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(284, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = ">>";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(228, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(320, 216);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // FormRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPicked);
            this.Controls.Add(this.labelAvaliable);
            this.Controls.Add(this.labelRouteData);
            this.Name = "FormRoute";
            this.Text = "Выбор заповедников";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelRouteData;
        private System.Windows.Forms.Label labelAvaliable;
        private System.Windows.Forms.Label labelPicked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}