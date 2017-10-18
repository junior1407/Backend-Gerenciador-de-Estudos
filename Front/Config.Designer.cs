namespace Front
{
    partial class Config
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.newSubject = new System.Windows.Forms.TextBox();
            this.newGrade = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.configBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hour_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End_Hour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "Item1",
            "Item2",
            "Item 3"});
            this.listBox1.Location = new System.Drawing.Point(12, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 148);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // newSubject
            // 
            this.newSubject.Location = new System.Drawing.Point(437, 70);
            this.newSubject.Name = "newSubject";
            this.newSubject.Size = new System.Drawing.Size(100, 22);
            this.newSubject.TabIndex = 3;
            // 
            // newGrade
            // 
            this.newGrade.Location = new System.Drawing.Point(437, 98);
            this.newGrade.Name = "newGrade";
            this.newGrade.Size = new System.Drawing.Size(100, 22);
            this.newGrade.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(449, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(235, 80);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Delete Selected";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hour_start,
            this.End_Hour,
            this.day});
            this.dataGridView1.Location = new System.Drawing.Point(26, 270);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(439, 150);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // configBindingSource
            // 
            this.configBindingSource.DataSource = typeof(Front.Config);
            this.configBindingSource.CurrentChanged += new System.EventHandler(this.configBindingSource_CurrentChanged);
            // 
            // hour_start
            // 
            this.hour_start.Frozen = true;
            this.hour_start.HeaderText = "Start Hour";
            this.hour_start.Name = "hour_start";
            // 
            // End_Hour
            // 
            this.End_Hour.Frozen = true;
            this.End_Hour.HeaderText = "End Hour";
            this.End_Hour.Name = "End_Hour";
            // 
            // day
            // 
            this.day.DataSource = this.configBindingSource;
            this.day.Frozen = true;
            this.day.HeaderText = "Day of The Week";
            this.day.Name = "day";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 519);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.newGrade);
            this.Controls.Add(this.newSubject);
            this.Controls.Add(this.listBox1);
            this.Name = "Config";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox newSubject;
        private System.Windows.Forms.TextBox newGrade;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hour_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End_Hour;
        private System.Windows.Forms.DataGridViewComboBoxColumn day;
        private System.Windows.Forms.BindingSource configBindingSource;
    }
}