namespace Assignment1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCurrentTemp = new TextBox();
            txtForecast = new TextBox();
            txtHeatIndex = new TextBox();
            txtStatistics = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtCurrentHum = new TextBox();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtCurrentTemp
            // 
            txtCurrentTemp.Location = new Point(222, 63);
            txtCurrentTemp.Name = "txtCurrentTemp";
            txtCurrentTemp.Size = new Size(125, 27);
            txtCurrentTemp.TabIndex = 0;
            // 
            // txtForecast
            // 
            txtForecast.Location = new Point(222, 126);
            txtForecast.Name = "txtForecast";
            txtForecast.Size = new Size(359, 27);
            txtForecast.TabIndex = 1;
            // 
            // txtHeatIndex
            // 
            txtHeatIndex.Location = new Point(222, 202);
            txtHeatIndex.Name = "txtHeatIndex";
            txtHeatIndex.Size = new Size(359, 27);
            txtHeatIndex.TabIndex = 2;
            // 
            // txtStatistics
            // 
            txtStatistics.Location = new Point(222, 281);
            txtStatistics.Name = "txtStatistics";
            txtStatistics.Size = new Size(359, 27);
            txtStatistics.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 63);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 4;
            label1.Text = "Current Condition";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 129);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 5;
            label2.Text = "Forecast";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 205);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 6;
            label3.Text = "Heat Index";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 288);
            label4.Name = "label4";
            label4.Size = new Size(67, 20);
            label4.TabIndex = 7;
            label4.Text = "Statistics";
            // 
            // txtCurrentHum
            // 
            txtCurrentHum.Location = new Point(432, 63);
            txtCurrentHum.Name = "txtCurrentHum";
            txtCurrentHum.Size = new Size(125, 27);
            txtCurrentHum.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(239, 31);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 9;
            label5.Text = "Temprature (F)";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(449, 31);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 10;
            label6.Text = "Humidity (%)";
            // 
            // button1
            // 
            button1.Location = new Point(338, 352);
            button1.Name = "button1";
            button1.Size = new Size(131, 61);
            button1.TabIndex = 11;
            button1.Text = "Show";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtCurrentHum);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStatistics);
            Controls.Add(txtHeatIndex);
            Controls.Add(txtForecast);
            Controls.Add(txtCurrentTemp);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCurrentTemp;
        private TextBox txtForecast;
        private TextBox txtHeatIndex;
        private TextBox txtStatistics;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCurrentHum;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}
