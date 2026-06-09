namespace P7_Travel_Planner_Frontend.Forms
{
    partial class Activity
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
            dataGridViewActivity = new DataGridView();
            btnAdd = new Button();
            txtName = new TextBox();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            numCost = new NumericUpDown();
            txtLocation = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCost).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(366, 67);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(366, 101);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 1;
            label2.Text = "Location";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 134);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 2;
            label3.Text = "Cost";
            // 
            // dataGridViewActivity
            // 
            dataGridViewActivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewActivity.Location = new Point(147, 309);
            dataGridViewActivity.Name = "dataGridViewActivity";
            dataGridViewActivity.RowHeadersWidth = 51;
            dataGridViewActivity.Size = new Size(1115, 409);
            dataGridViewActivity.TabIndex = 3;
            dataGridViewActivity.CellClick += dataGridViewActivities_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1084, 242);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(102, 49);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(561, 60);
            txtName.Name = "txtName";
            txtName.Size = new Size(610, 27);
            txtName.TabIndex = 5;
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(561, 163);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(610, 27);
            dtpStart.TabIndex = 8;
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(561, 196);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(610, 27);
            dtpEnd.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 170);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 10;
            label4.Text = "Start Time";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(366, 203);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 11;
            label5.Text = "End Time";
            // 
            // numCost
            // 
            numCost.Location = new Point(561, 127);
            numCost.Name = "numCost";
            numCost.Size = new Size(610, 27);
            numCost.TabIndex = 14;
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(561, 93);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(610, 27);
            txtLocation.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(235, 67);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 16;
            label6.Text = "1 .";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(235, 100);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 17;
            label7.Text = "2 .";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(235, 134);
            label8.Name = "label8";
            label8.Size = new Size(24, 20);
            label8.TabIndex = 18;
            label8.Text = "3 .";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(235, 170);
            label9.Name = "label9";
            label9.Size = new Size(24, 20);
            label9.TabIndex = 19;
            label9.Text = "4 .";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(235, 201);
            label10.Name = "label10";
            label10.Size = new Size(24, 20);
            label10.TabIndex = 20;
            label10.Text = "5 .";
            // 
            // Activity
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1404, 739);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtLocation);
            Controls.Add(numCost);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(dataGridViewActivity);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Activity";
            Text = "Activity";
            Load += ActivityForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewActivity).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridViewActivity;
        private Button btnAdd;
        private TextBox txtName;
        private ComboBox cmbLocation;
        private TextBox txtCost;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Label label4;
        private Label label5;
        private NumericUpDown numCost;
        private TextBox txtLocation;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}