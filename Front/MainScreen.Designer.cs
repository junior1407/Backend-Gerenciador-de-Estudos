namespace Front
{
    partial class MainScreen
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dashboardTab = new System.Windows.Forms.TabPage();
            this.Configure = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.Configure.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.dashboardTab);
            this.tabControl1.Controls.Add(this.Configure);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 492);
            this.tabControl1.TabIndex = 0;
            // 
            // dashboardTab
            // 
            this.dashboardTab.Location = new System.Drawing.Point(4, 25);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Padding = new System.Windows.Forms.Padding(3);
            this.dashboardTab.Size = new System.Drawing.Size(808, 463);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            this.dashboardTab.UseVisualStyleBackColor = true;
            this.dashboardTab.Click += new System.EventHandler(this.dashboardTab_Click);
            // 
            // Configure
            // 
            this.Configure.Controls.Add(this.panel1);
            this.Configure.Location = new System.Drawing.Point(4, 25);
            this.Configure.Name = "Configure";
            this.Configure.Padding = new System.Windows.Forms.Padding(3);
            this.Configure.Size = new System.Drawing.Size(808, 463);
            this.Configure.TabIndex = 1;
            this.Configure.Text = "configureTab";
            this.Configure.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 457);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(814, 490);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.tabControl1.ResumeLayout(false);
            this.Configure.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage dashboardTab;
        private System.Windows.Forms.TabPage Configure;
        private System.Windows.Forms.Panel panel1;
    }
}