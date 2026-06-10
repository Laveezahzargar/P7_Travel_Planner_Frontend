namespace P7_Travel_Planner_Frontend.Forms
{
    partial class DestinationDetails
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
            lblName = new Label();
            lblCountry = new Label();
            lblDescription = new Label();
            label4 = new Label();
            dataGridViewPlaces = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlaces).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(555, 88);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "Destination";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(555, 134);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 1;
            label2.Text = "Country";
            // 
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(803, 88);
            lblName.Name = "lblName";
            lblName.Size = new Size(50, 20);
            lblName.TabIndex = 3;
            lblName.Text = "label4";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Location = new Point(803, 134);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(50, 20);
            lblCountry.TabIndex = 4;
            lblCountry.Text = "label5";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(803, 183);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(50, 20);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "label6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(299, 224);
            label4.Name = "label4";
            label4.Size = new Size(203, 20);
            label4.TabIndex = 6;
            label4.Text = "Places in this destination are :";
            // 
            // dataGridViewPlaces
            // 
            dataGridViewPlaces.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlaces.Location = new Point(200, 283);
            dataGridViewPlaces.Name = "dataGridViewPlaces";
            dataGridViewPlaces.RowHeadersWidth = 51;
            dataGridViewPlaces.Size = new Size(1082, 444);
            dataGridViewPlaces.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(362, 134);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 9;
            label6.Text = "2 .";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(362, 183);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 10;
            label7.Text = "3 .";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(362, 88);
            label5.Name = "label5";
            label5.Size = new Size(24, 20);
            label5.TabIndex = 8;
            label5.Text = "1 .";
            // 
            // DestinationDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 739);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(dataGridViewPlaces);
            Controls.Add(label4);
            Controls.Add(lblDescription);
            Controls.Add(lblCountry);
            Controls.Add(lblName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DestinationDetails";
            Text = "DestinationDetails";
            Load += DestinationDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlaces).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblName;
        private Label lblCountry;
        private Label lblDescription;
        private Label label4;
        private DataGridView dataGridViewPlaces;
        private Label label6;
        private Label label7;
        private Label label5;
    }
}