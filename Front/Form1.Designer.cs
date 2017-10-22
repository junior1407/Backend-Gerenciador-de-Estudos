namespace Front
{
    partial class Form1
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
            this.logarBtn = new System.Windows.Forms.Button();
            this.passwordText1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.loginTab = new System.Windows.Forms.TabPage();
            this.usernameText1 = new System.Windows.Forms.TextBox();
            this.registerTab = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.registerBtn = new System.Windows.Forms.Button();
            this.idRedeSocial = new System.Windows.Forms.TextBox();
            this.avatar = new System.Windows.Forms.TextBox();
            this.nickname = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.loginTab.SuspendLayout();
            this.registerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // logarBtn
            // 
            this.logarBtn.Location = new System.Drawing.Point(219, 151);
            this.logarBtn.Name = "logarBtn";
            this.logarBtn.Size = new System.Drawing.Size(75, 23);
            this.logarBtn.TabIndex = 0;
            this.logarBtn.Text = "Logar";
            this.logarBtn.UseVisualStyleBackColor = true;
            this.logarBtn.Click += new System.EventHandler(this.logarBtn_Click);
            // 
            // passwordText1
            // 
            this.passwordText1.Location = new System.Drawing.Point(356, 105);
            this.passwordText1.Name = "passwordText1";
            this.passwordText1.Size = new System.Drawing.Size(100, 22);
            this.passwordText1.TabIndex = 2;
            this.passwordText1.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "password";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.loginTab);
            this.tabControl1.Controls.Add(this.registerTab);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 440);
            this.tabControl1.TabIndex = 6;
            // 
            // loginTab
            // 
            this.loginTab.Controls.Add(this.usernameText1);
            this.loginTab.Controls.Add(this.label1);
            this.loginTab.Controls.Add(this.logarBtn);
            this.loginTab.Controls.Add(this.label2);
            this.loginTab.Controls.Add(this.passwordText1);
            this.loginTab.Location = new System.Drawing.Point(4, 25);
            this.loginTab.Name = "loginTab";
            this.loginTab.Padding = new System.Windows.Forms.Padding(3);
            this.loginTab.Size = new System.Drawing.Size(560, 411);
            this.loginTab.TabIndex = 0;
            this.loginTab.Text = "Login";
            this.loginTab.UseVisualStyleBackColor = true;
            this.loginTab.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // usernameText1
            // 
            this.usernameText1.Location = new System.Drawing.Point(64, 105);
            this.usernameText1.Name = "usernameText1";
            this.usernameText1.Size = new System.Drawing.Size(100, 22);
            this.usernameText1.TabIndex = 1;
            // 
            // registerTab
            // 
            this.registerTab.Controls.Add(this.label7);
            this.registerTab.Controls.Add(this.label6);
            this.registerTab.Controls.Add(this.label5);
            this.registerTab.Controls.Add(this.label4);
            this.registerTab.Controls.Add(this.label3);
            this.registerTab.Controls.Add(this.registerBtn);
            this.registerTab.Controls.Add(this.idRedeSocial);
            this.registerTab.Controls.Add(this.avatar);
            this.registerTab.Controls.Add(this.nickname);
            this.registerTab.Controls.Add(this.passwordBox);
            this.registerTab.Controls.Add(this.usernameBox);
            this.registerTab.Location = new System.Drawing.Point(4, 25);
            this.registerTab.Name = "registerTab";
            this.registerTab.Padding = new System.Windows.Forms.Padding(3);
            this.registerTab.Size = new System.Drawing.Size(560, 411);
            this.registerTab.TabIndex = 1;
            this.registerTab.Text = "Register";
            this.registerTab.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Id Rede Social";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Avatar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nickname";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(214, 264);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(75, 23);
            this.registerBtn.TabIndex = 5;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click_1);
            // 
            // idRedeSocial
            // 
            this.idRedeSocial.Location = new System.Drawing.Point(202, 219);
            this.idRedeSocial.Name = "idRedeSocial";
            this.idRedeSocial.Size = new System.Drawing.Size(100, 22);
            this.idRedeSocial.TabIndex = 4;
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(202, 191);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(100, 22);
            this.avatar.TabIndex = 3;
            // 
            // nickname
            // 
            this.nickname.Location = new System.Drawing.Point(202, 163);
            this.nickname.Name = "nickname";
            this.nickname.Size = new System.Drawing.Size(100, 22);
            this.nickname.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(202, 135);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(100, 22);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(202, 107);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 22);
            this.usernameBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 437);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.loginTab.ResumeLayout(false);
            this.loginTab.PerformLayout();
            this.registerTab.ResumeLayout(false);
            this.registerTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logarBtn;
        private System.Windows.Forms.TextBox passwordText1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage loginTab;
        private System.Windows.Forms.TextBox usernameText1;
        private System.Windows.Forms.TabPage registerTab;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox nickname;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox idRedeSocial;
        private System.Windows.Forms.TextBox avatar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button registerBtn;
    }
}