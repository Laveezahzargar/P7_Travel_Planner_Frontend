namespace P7_Travel_Planner_Frontend.Forms
{
    partial class TripDetails
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblTitle = new Label();
            lblDestination = new Label();
            lblStartDate = new Label();
            lblEndDate = new Label();
            lblStatus = new Label();
            dataGridViewDays = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnAdd = new Button();
            txtNotes = new TextBox();
            dtpDate = new DateTimePicker();
            numDayNumber = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDayNumber).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(305, 86);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 0;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(305, 151);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 1;
            label2.Text = "Destination";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(305, 214);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Start Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(305, 281);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 3;
            label4.Text = "End Date";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(305, 335);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Status";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(547, 86);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(50, 20);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "label6";
            // 
            // lblDestination
            // 
            lblDestination.AutoSize = true;
            lblDestination.Location = new Point(547, 151);
            lblDestination.Name = "lblDestination";
            lblDestination.Size = new Size(50, 20);
            lblDestination.TabIndex = 6;
            lblDestination.Text = "label7";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(547, 214);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(50, 20);
            lblStartDate.TabIndex = 7;
            lblStartDate.Text = "label8";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(547, 281);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(50, 20);
            lblEndDate.TabIndex = 8;
            lblEndDate.Text = "label9";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(547, 335);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(58, 20);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "label10";
            // 
            // dataGridViewDays
            // 
            dataGridViewDays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDays.Location = new Point(218, 442);
            dataGridViewDays.Name = "dataGridViewDays";
            dataGridViewDays.RowHeadersWidth = 51;
            dataGridViewDays.Size = new Size(1062, 286);
            dataGridViewDays.TabIndex = 10;
            dataGridViewDays.CellClick += dataGridViewDays_CellClick;
            dataGridViewDays.CellContentClick += dataGridViewDays_CellContentClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(792, 86);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 11;
            label6.Text = "Date";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(792, 151);
            label7.Name = "label7";
            label7.Size = new Size(93, 20);
            label7.TabIndex = 12;
            label7.Text = "Day Number";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(792, 214);
            label8.Name = "label8";
            label8.Size = new Size(48, 20);
            label8.TabIndex = 13;
            label8.Text = "Notes";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1132, 270);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 43);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAddDay_Click;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(924, 207);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(317, 27);
            txtNotes.TabIndex = 19;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(924, 79);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(317, 27);
            dtpDate.TabIndex = 20;
            // 
            // numDayNumber
            // 
            numDayNumber.Location = new Point(924, 144);
            numDayNumber.Name = "numDayNumber";
            numDayNumber.Size = new Size(317, 27);
            numDayNumber.TabIndex = 21;
            // 
            // TripDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1451, 740);
            Controls.Add(numDayNumber);
            Controls.Add(dtpDate);
            Controls.Add(txtNotes);
            Controls.Add(btnAdd);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(dataGridViewDays);
            Controls.Add(lblStatus);
            Controls.Add(lblEndDate);
            Controls.Add(lblStartDate);
            Controls.Add(lblDestination);
            Controls.Add(lblTitle);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TripDetails";
            Text = "TripDetails";
            Load += TripDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDayNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblTitle;
        private Label lblDestination;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label lblStatus;
        private DataGridView dataGridViewDays;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnAdd;
        private TextBox txtNotes;
        private DateTimePicker dtpDate;
        private NumericUpDown numDayNumber;
    }
}