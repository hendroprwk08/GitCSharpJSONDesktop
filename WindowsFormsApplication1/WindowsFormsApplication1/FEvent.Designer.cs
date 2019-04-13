namespace WindowsFormsApplication1
{
    partial class FEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEvent));
            this.dtp_jam = new System.Windows.Forms.DateTimePicker();
            this.dtp_tanggal = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_deskripsi = new System.Windows.Forms.TextBox();
            this.tb_event = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.tb_cari = new System.Windows.Forms.TextBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_jam
            // 
            this.dtp_jam.CustomFormat = "HH:mm";
            this.dtp_jam.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_jam.Location = new System.Drawing.Point(674, 134);
            this.dtp_jam.Name = "dtp_jam";
            this.dtp_jam.ShowUpDown = true;
            this.dtp_jam.Size = new System.Drawing.Size(54, 20);
            this.dtp_jam.TabIndex = 27;
            // 
            // dtp_tanggal
            // 
            this.dtp_tanggal.CustomFormat = "yyyy-MM-dd";
            this.dtp_tanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_tanggal.Location = new System.Drawing.Point(522, 136);
            this.dtp_tanggal.Name = "dtp_tanggal";
            this.dtp_tanggal.Size = new System.Drawing.Size(80, 20);
            this.dtp_tanggal.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Image = global::WindowsFormsApplication1.Properties.Resources.Save;
            this.button3.Location = new System.Drawing.Point(485, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 29);
            this.button3.TabIndex = 23;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::WindowsFormsApplication1.Properties.Resources.Delete;
            this.button2.Location = new System.Drawing.Point(520, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 29);
            this.button2.TabIndex = 24;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::WindowsFormsApplication1.Properties.Resources.Add;
            this.button1.Location = new System.Drawing.Point(450, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 29);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_deskripsi
            // 
            this.tb_deskripsi.Location = new System.Drawing.Point(521, 40);
            this.tb_deskripsi.Multiline = true;
            this.tb_deskripsi.Name = "tb_deskripsi";
            this.tb_deskripsi.Size = new System.Drawing.Size(207, 92);
            this.tb_deskripsi.TabIndex = 18;
            // 
            // tb_event
            // 
            this.tb_event.Location = new System.Drawing.Point(521, 14);
            this.tb_event.MaxLength = 1000;
            this.tb_event.Name = "tb_event";
            this.tb_event.Size = new System.Drawing.Size(207, 20);
            this.tb_event.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(642, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(451, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Event";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(432, 232);
            this.dataGridView1.TabIndex = 27;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(170, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "Find";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tb_cari
            // 
            this.tb_cari.Location = new System.Drawing.Point(12, 14);
            this.tb_cari.Name = "tb_cari";
            this.tb_cari.Size = new System.Drawing.Size(150, 20);
            this.tb_cari.TabIndex = 25;
            // 
            // tb_log
            // 
            this.tb_log.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tb_log.ForeColor = System.Drawing.Color.White;
            this.tb_log.Location = new System.Drawing.Point(450, 205);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(278, 67);
            this.tb_log.TabIndex = 15;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 280);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(733, 4);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 18;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(224, 13);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "Reload";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.FEvent_Load);
            // 
            // FEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 287);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dtp_jam);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dtp_tanggal);
            this.Controls.Add(this.tb_cari);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.tb_deskripsi);
            this.Controls.Add(this.tb_event);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event";
            this.Load += new System.EventHandler(this.FEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_event;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tb_cari;
        private System.Windows.Forms.DateTimePicker dtp_tanggal;
        private System.Windows.Forms.DateTimePicker dtp_jam;
        private System.Windows.Forms.TextBox tb_deskripsi;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button5;
    }
}