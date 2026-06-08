namespace P7_Travel_Planner_Frontend.Forms
{
    partial class MyTrips
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
            dataGridViewTrips = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTitle = new TextBox();
            btnCreateTrip = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cmbStatus = new ComboBox();
            cmbDestination = new ComboBox();
            StartDate = new DateTimePicker();
            EndDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTrips).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewTrips
            // 
            dataGridViewTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTrips.Location = new Point(133, 321);
            dataGridViewTrips.Name = "dataGridViewTrips";
            dataGridViewTrips.RowHeadersWidth = 51;
            dataGridViewTrips.Size = new Size(1147, 371);
            dataGridViewTrips.TabIndex = 0;
            dataGridViewTrips.CellContentClick += dataGridViewTrips_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 70);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 1;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(358, 105);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 2;
            label2.Text = "Destination";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(358, 138);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 3;
            label3.Text = "Start Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(358, 179);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 4;
            label4.Text = "End date";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(523, 63);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(697, 27);
            txtTitle.TabIndex = 5;
            // 
            // btnCreateTrip
            // 
            btnCreateTrip.Location = new Point(1066, 256);
            btnCreateTrip.Name = "btnCreateTrip";
            btnCreateTrip.Size = new Size(105, 42);
            btnCreateTrip.TabIndex = 9;
            btnCreateTrip.Text = "Create";
            btnCreateTrip.UseVisualStyleBackColor = true;
            btnCreateTrip.Click += btnCreateTrip_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 70);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 10;
            label5.Text = "1 .";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(213, 105);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 11;
            label6.Text = "2 .";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(213, 141);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 12;
            label7.Text = "3 .";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(213, 179);
            label8.Name = "label8";
            label8.Size = new Size(24, 20);
            label8.TabIndex = 13;
            label8.Text = "4 .";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(358, 218);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 14;
            label9.Text = "Status";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(213, 218);
            label10.Name = "label10";
            label10.Size = new Size(24, 20);
            label10.TabIndex = 15;
            label10.Text = "5 .";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(523, 210);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(697, 28);
            cmbStatus.TabIndex = 16;
            // 
            // cmbDestination
            // 
            cmbDestination.FormattingEnabled = true;
            cmbDestination.Location = new Point(523, 97);
            cmbDestination.Name = "cmbDestination";
            cmbDestination.Size = new Size(697, 28);
            cmbDestination.TabIndex = 17;
            // 
            // StartDate
            // 
            StartDate.Location = new Point(523, 131);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(697, 27);
            StartDate.TabIndex = 18;
            // 
            // EndDate
            // 
            EndDate.Location = new Point(523, 172);
            EndDate.Name = "EndDate";
            EndDate.Size = new Size(697, 27);
            EndDate.TabIndex = 19;
            // 
            // MyTrips
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1413, 742);
            Controls.Add(EndDate);
            Controls.Add(StartDate);
            Controls.Add(cmbDestination);
            Controls.Add(cmbStatus);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnCreateTrip);
            Controls.Add(txtTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewTrips);
            Name = "MyTrips";
            Text = "MyTrips";
            Load += MyTripsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTrips).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTrips;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTitle;
        private TextBox txtStartDate;
        private TextBox textBox4;
        private Button btnCreateTrip;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cmbStatus;
        private ComboBox cmbDestination;
        private DateTimePicker StartDate;
        private DateTimePicker EndDate;
    }
}