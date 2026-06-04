namespace P7_Travel_Planner_Frontend.Forms
{
    partial class Login
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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            linkRegister = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(434, 144);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(434, 200);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(555, 320);
            label3.Name = "label3";
            label3.Size = new Size(167, 20);
            label3.TabIndex = 2;
            label3.Text = "Don't have an account ?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(579, 69);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 3;
            label4.Text = "Login Form";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(579, 137);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(579, 193);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 27);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(781, 255);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Location = new Point(598, 359);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(63, 20);
            linkRegister.TabIndex = 7;
            linkRegister.TabStop = true;
            linkRegister.Text = "Register";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 742);
            Controls.Add(linkRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel linkRegister;
    }
}