namespace WindowsFormsApplication1
{
    partial class Latihan_2_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Latihan_2_1));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tanggal = new System.Windows.Forms.NumericUpDown();
            this.halaman2prev = new System.Windows.Forms.PictureBox();
            this.halaman2next = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bulan = new System.Windows.Forms.DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.tanggal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.halaman2prev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.halaman2next)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 3);
            this.monthCalendar1.Location = new System.Drawing.Point(9, 36);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // tanggal
            // 
            this.tanggal.Location = new System.Drawing.Point(10, 8);
            this.tanggal.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.tanggal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tanggal.Name = "tanggal";
            this.tanggal.Size = new System.Drawing.Size(120, 20);
            this.tanggal.TabIndex = 31;
            this.tanggal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // halaman2prev
            // 
            this.halaman2prev.Image = ((System.Drawing.Image)(resources.GetObject("halaman2prev.Image")));
            this.halaman2prev.Location = new System.Drawing.Point(719, 8);
            this.halaman2prev.Name = "halaman2prev";
            this.halaman2prev.Size = new System.Drawing.Size(26, 26);
            this.halaman2prev.TabIndex = 32;
            this.halaman2prev.TabStop = false;
            this.halaman2prev.Click += new System.EventHandler(this.halaman2prev_Click);
            // 
            // halaman2next
            // 
            this.halaman2next.Image = ((System.Drawing.Image)(resources.GetObject("halaman2next.Image")));
            this.halaman2next.Location = new System.Drawing.Point(755, 8);
            this.halaman2next.Name = "halaman2next";
            this.halaman2next.Size = new System.Drawing.Size(26, 26);
            this.halaman2next.TabIndex = 33;
            this.halaman2next.TabStop = false;
            this.halaman2next.Click += new System.EventHandler(this.halaman2next_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Tambah";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "Hapus";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bulan
            // 
            this.bulan.Items.Add("Januari");
            this.bulan.Items.Add("Februari");
            this.bulan.Items.Add("Maret");
            this.bulan.Items.Add("April");
            this.bulan.Items.Add("Mei");
            this.bulan.Items.Add("Juni");
            this.bulan.Items.Add("Juli");
            this.bulan.Items.Add("Agustus");
            this.bulan.Items.Add("September");
            this.bulan.Items.Add("Oktober");
            this.bulan.Items.Add("November");
            this.bulan.Items.Add("Desember");
            this.bulan.Location = new System.Drawing.Point(163, 8);
            this.bulan.Name = "bulan";
            this.bulan.Size = new System.Drawing.Size(120, 20);
            this.bulan.TabIndex = 38;
            this.bulan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Latihan_2_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 497);
            this.Controls.Add(this.bulan);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.halaman2next);
            this.Controls.Add(this.halaman2prev);
            this.Controls.Add(this.tanggal);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Latihan_2_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Latihan_2_1";
            this.Load += new System.EventHandler(this.Latihan_2_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tanggal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.halaman2prev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.halaman2next)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.NumericUpDown tanggal;
        private System.Windows.Forms.PictureBox halaman2prev;
        private System.Windows.Forms.PictureBox halaman2next;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DomainUpDown bulan;
    }
}