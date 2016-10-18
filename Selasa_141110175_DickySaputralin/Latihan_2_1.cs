using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Latihan_2_1 : Form
    {
        public Latihan_2_1()
        {
            InitializeComponent();

            bulan.SelectedItem = "Januari";

            DateTime mulai = new DateTime(2016, 1, 1);
            DateTime akhir = new DateTime(2017, 12, 31);
            TimeSpan jarak = akhir - mulai;
            int day = jarak.Days;
            for (var i = 0; i <= day; i++)
            {
                var bolddate = mulai.AddDays(i);
                switch (bolddate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        monthCalendar1.AddBoldedDate(bolddate);
                        break;
                    case DayOfWeek.Sunday:
                        monthCalendar1.AddBoldedDate(bolddate);
                        break;
                }
            }

            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(1996, 10, 11));
        }

        private void Latihan_2_1_Load(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;
            tooltip.SetToolTip(this.halaman2prev, "Back");
            tooltip.SetToolTip(this.halaman2next, "Next");

        }

        private void halaman2prev_Click(object sender, EventArgs e)
        {
            Latihan_1_1 latihan1 = new Latihan_1_1();
            Latihan_2_1 latihan2 = new Latihan_2_1();
            this.Close();
            latihan2.Hide();
            latihan1.Show();
            
        }

        private void halaman2next_Click(object sender, EventArgs e)
        {
            Latihan_2_1 latihan2 = new Latihan_2_1();
            Latihan_3_1 latihan3 = new Latihan_3_1();
            this.Hide();
            latihan2.Close();
            latihan3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2016, bulan.SelectedIndex + 1, Convert.ToInt32(tanggal.Value)));
            monthCalendar1.UpdateBoldedDates();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            monthCalendar1.RemoveAnnuallyBoldedDate(new DateTime(2016, bulan.SelectedIndex + 1, Convert.ToInt32(tanggal.Value)));
            monthCalendar1.UpdateBoldedDates();
        }


    }
}
