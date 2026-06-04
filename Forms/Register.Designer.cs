namespace P7_Travel_Planner_Frontend
{
    partial class Register
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
            label1 = new Label();
            label2 = new Label();
            btnRegister = new Button();
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            label7 = new Label();
            linkLogin = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(422, 145);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Full Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(422, 193);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(776, 401);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(589, 142);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(312, 27);
            txtFullName.TabIndex = 4;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(589, 186);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(312, 27);
            txtUsername.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 63);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 6;
            label3.Text = "Register Form";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 244);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 7;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 295);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 8;
            label5.Text = "Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(422, 340);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 9;
            label6.Text = "Confirm Password";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(589, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(312, 27);
            txtEmail.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(589, 288);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(312, 27);
            txtPassword.TabIndex = 11;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(589, 333);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(312, 27);
            txtConfirmPassword.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(556, 488);
            label7.Name = "label7";
            label7.Size = new Size(186, 20);
            label7.TabIndex = 13;
            label7.Text = "Already have an account ? ";
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.Location = new Point(619, 518);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(46, 20);
            linkLogin.TabIndex = 14;
            linkLogin.TabStop = true;
            linkLogin.Text = "Login";
            linkLogin.LinkClicked += this.linkLogin_LinkClicked;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1407, 738);
            Controls.Add(linkLogin);
            Controls.Add(label7);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(txtFullName);
            Controls.Add(btnRegister);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Register";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnRegister;
        private TextBox txtFullName;
        private TextBox txtUsername;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Label label7;
        private LinkLabel linkLogin;
    }
}
