namespace P7_Travel_Planner_Frontend.Forms
{
    partial class Weather
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
            label1 = new Label();
            label2 = new Label();
            lblDestination = new Label();
            label4 = new Label();
            lblPlace = new Label();
            grpCurrentWeather = new GroupBox();
            lblWind = new Label();
            lblHumidity = new Label();
            lblCondition = new Label();
            lblTemperature = new Label();
            dataGridViewForecast = new DataGridView();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            grpCurrentWeather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewForecast).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(638, 106);
            label1.Name = "label1";
            label1.Size = new Size(124, 20);
            label1.TabIndex = 0;
            label1.Text = "Weather Forecast";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(562, 184);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 1;
            label2.Text = "Destination";
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(766, 184);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(50, 20);
            lblDestination.TabIndex = 2;
            lblDestination.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(572, 233);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 3;
            label4.Text = "Place";
            // 
            // lblPlace
            // 
            lblPlace.AutoSize = true;
            lblPlace.Location = new Point(766, 233);
            lblPlace.Name = "lblPlace";
            lblPlace.Size = new Size(50, 20);
            lblPlace.TabIndex = 4;
            lblPlace.Text = "label5";
            // 
            // grpCurrentWeather
            // 
            grpCurrentWeather.Controls.Add(label13);
            grpCurrentWeather.Controls.Add(label12);
            grpCurrentWeather.Controls.Add(label11);
            grpCurrentWeather.Controls.Add(label10);
            grpCurrentWeather.Controls.Add(label9);
            grpCurrentWeather.Controls.Add(lblWind);
            grpCurrentWeather.Controls.Add(label8);
            grpCurrentWeather.Controls.Add(lblHumidity);
            grpCurrentWeather.Controls.Add(label7);
            grpCurrentWeather.Controls.Add(lblCondition);
            grpCurrentWeather.Controls.Add(label6);
            grpCurrentWeather.Controls.Add(lblTemperature);
            grpCurrentWeather.Location = new Point(355, 281);
            grpCurrentWeather.Name = "grpCurrentWeather";
            grpCurrentWeather.Size = new Size(739, 208);
            grpCurrentWeather.TabIndex = 5;
            grpCurrentWeather.TabStop = false;
            grpCurrentWeather.Text = "groupBox1";
            // 
            // lblWind
            // 
            lblWind.AutoSize = true;
            lblWind.Location = new Point(411, 173);
            lblWind.Name = "lblWind";
            lblWind.Size = new Size(50, 20);
            lblWind.TabIndex = 3;
            lblWind.Text = "label7";
            // 
            // lblHumidity
            // 
            lblHumidity.AutoSize = true;
            lblHumidity.Location = new Point(411, 136);
            lblHumidity.Name = "lblHumidity";
            lblHumidity.Size = new Size(50, 20);
            lblHumidity.TabIndex = 2;
            lblHumidity.Text = "label6";
            // 
            // lblCondition
            // 
            lblCondition.AutoSize = true;
            lblCondition.Location = new Point(411, 96);
            lblCondition.Name = "lblCondition";
            lblCondition.Size = new Size(50, 20);
            lblCondition.TabIndex = 1;
            lblCondition.Text = "label5";
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Location = new Point(411, 54);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(50, 20);
            lblTemperature.TabIndex = 0;
            lblTemperature.Text = "label3";
            // 
            // dataGridViewForecast
            // 
            dataGridViewForecast.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewForecast.Location = new Point(355, 495);
            dataGridViewForecast.Name = "dataGridViewForecast";
            dataGridViewForecast.RowHeadersWidth = 51;
            dataGridViewForecast.Size = new Size(739, 207);
            dataGridViewForecast.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(432, 184);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 7;
            label3.Text = " 1 .";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(432, 233);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 8;
            label5.Text = "2 .";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(207, 54);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 9;
            label6.Text = "Temperature";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(207, 96);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 10;
            label7.Text = "Condition";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(207, 136);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 11;
            label8.Text = "Humidity";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(207, 173);
            label9.Name = "label9";
            label9.Size = new Size(44, 20);
            label9.TabIndex = 12;
            label9.Text = "Wind";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(68, 54);
            label10.Name = "label10";
            label10.Size = new Size(30, 20);
            label10.TabIndex = 13;
            label10.Text = "🌡️";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(68, 96);
            label11.Name = "label11";
            label11.Size = new Size(30, 20);
            label11.TabIndex = 14;
            label11.Text = "☁️";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(68, 136);
            label12.Name = "label12";
            label12.Size = new Size(30, 20);
            label12.TabIndex = 15;
            label12.Text = "💧";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(68, 173);
            label13.Name = "label13";
            label13.Size = new Size(30, 20);
            label13.TabIndex = 16;
            label13.Text = "🌬️";
            // 
            // Weather
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 740);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(dataGridViewForecast);
            Controls.Add(grpCurrentWeather);
            Controls.Add(lblPlace);
            Controls.Add(label4);
            Controls.Add(lblDestination);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Weather";
            Text = "Weather";
            grpCurrentWeather.ResumeLayout(false);
            grpCurrentWeather.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewForecast).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblDestination;
        private Label label4;
        private Label lblPlace;
        private GroupBox grpCurrentWeather;
        private Label lblWind;
        private Label lblHumidity;
        private Label lblCondition;
        private Label lblTemperature;
        private DataGridView dataGridViewForecast;
        private Label label3;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
    }
}