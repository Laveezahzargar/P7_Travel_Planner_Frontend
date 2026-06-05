namespace P7_Travel_Planner_Frontend.Forms
{
    partial class Destinations
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
            txtSearch = new TextBox();
            dataGridViewDestinations = new DataGridView();
            label1 = new Label();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDestinations).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(437, 114);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(665, 27);
            txtSearch.TabIndex = 0;
            // 
            // dataGridViewDestinations
            // 
            dataGridViewDestinations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDestinations.Location = new Point(129, 173);
            dataGridViewDestinations.Name = "dataGridViewDestinations";
            dataGridViewDestinations.RowHeadersWidth = 51;
            dataGridViewDestinations.Size = new Size(1114, 557);
            dataGridViewDestinations.TabIndex = 1;
            dataGridViewDestinations.CellContentClick += dataGridViewDestinations_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(149, 121);
            label1.Name = "label1";
            label1.Size = new Size(235, 20);
            label1.TabIndex = 2;
            label1.Text = "Search Your Favorite Destinations :";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1108, 114);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Destinations
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1412, 742);
            Controls.Add(btnSearch);
            Controls.Add(label1);
            Controls.Add(dataGridViewDestinations);
            Controls.Add(txtSearch);
            Name = "Destinations";
            Text = "Destinations";
            Load += Destinations_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDestinations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dataGridViewDestinations;
        private Label label1;
        private Button btnSearch;
    }
}