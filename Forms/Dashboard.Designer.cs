namespace P7_Travel_Planner_Frontend.Forms
{
    partial class Dashboard
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
            lblUsername = new Label();
            btnViewDestinations = new Button();
            btnMyTrips = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(614, 117);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(50, 20);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "label2";
            // 
            // btnViewDestinations
            // 
            btnViewDestinations.Location = new Point(511, 200);
            btnViewDestinations.Name = "btnViewDestinations";
            btnViewDestinations.Size = new Size(153, 51);
            btnViewDestinations.TabIndex = 2;
            btnViewDestinations.Text = "View Destinations";
            btnViewDestinations.UseVisualStyleBackColor = true;
            btnViewDestinations.Click += btnViewDestinations_Click;
            // 
            // btnMyTrips
            // 
            btnMyTrips.Location = new Point(682, 200);
            btnMyTrips.Name = "btnMyTrips";
            btnMyTrips.Size = new Size(153, 51);
            btnMyTrips.TabIndex = 3;
            btnMyTrips.Text = "My Trips";
            btnMyTrips.UseVisualStyleBackColor = true;
            btnMyTrips.Click += btnMyTrips_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(614, 277);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 51);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1411, 739);
            Controls.Add(btnLogout);
            Controls.Add(btnMyTrips);
            Controls.Add(btnViewDestinations);
            Controls.Add(lblUsername);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblUsername;
        private Button btnViewDestinations;
        private Button btnMyTrips;
        private Button btnLogout;
    }
}