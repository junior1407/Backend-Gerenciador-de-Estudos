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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.newSubject = new System.Windows.Forms.TextBox();
            this.newGrade = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.day = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(496, 270);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 8;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.start,
            this.end,
            this.day});
            this.dataGridView2.Location = new System.Drawing.Point(50, 270);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(386, 150);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // start
            // 
            this.start.HeaderText = "Start Hour";
            this.start.Name = "start";
            // 
            // end
            // 
            this.end.HeaderText = "End Hour";
            this.end.Name = "end";
            // 
            // day
            // 
            this.day.HeaderText = "Day of the Week";
            this.day.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.day.Name = "day";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 519);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.newGrade);
            this.Controls.Add(this.newSubject);
            this.Controls.Add(this.listBox1);
            this.Name = "Config";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox newSubject;
        private System.Windows.Forms.TextBox newGrade;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
        private System.Windows.Forms.DataGridViewComboBoxColumn day;
    }
}