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
    public partial class Latihan_3_1 : Form
    {
        public Latihan_3_1()
        {
            InitializeComponent();
        }

        private void Latihan_3_1_Load(object sender, EventArgs e)
        {
            InstalledFontCollection kumpulanfont = new InstalledFontCollection();
            foreach (FontFamily i in kumpulanfont.Families)
            {
                toolStripComboBox2.Items.Add(i.Name);
            }
            toolStripComboBox2.SelectedIndex = 14;

            for (int i = 5; i <= 72; i++)
                toolStripComboBox1.Items.Add(i);
            toolStripComboBox1.SelectedIndex = 7;

            toolStripComboBox2.ComboBox.LostFocus += new EventHandler(toolStripComboBox2_LostFocus);
            toolStripComboBox1.ComboBox.LostFocus += new EventHandler(toolStripComboBox2_LostFocus);
            toolStripComboBox2.ComboBox.DrawItem += new DrawItemEventHandler(toolStripComboBox2_DrawItem);
            toolStripComboBox2.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo property in typeof(Color).GetProperties())
            {
                if (property.PropertyType == typeof(Color))
                    toolStripComboBox3.Items.Add(property.Name);
            }

            toolStripComboBox3.SelectedIndex = 8;
            toolStripComboBox3.ComboBox.LostFocus += new EventHandler(toolStripComboBox2_LostFocus);
            toolStripComboBox3.ComboBox.DrawItem += new DrawItemEventHandler(toolStripComboBox3_DrawItem);
            toolStripComboBox3.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            update_teks();

            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;
            tooltip.SetToolTip(this.halaman2prev, "Back");
            tooltip.SetToolTip(this.halaman2next, "Next");
        }
        private void halaman2prev_Click(object sender, EventArgs e)
        {
            Latihan_3_1 latihan3 = new Latihan_3_1();
            Latihan_2_1 latihan2 = new Latihan_2_1();
            this.Close();
            latihan3.Hide();
            latihan2.Show();
        }
        private void halaman2next_Click(object sender, EventArgs e)
        {
            Latihan_3_1 latihan3 = new Latihan_3_1();
            Latihan_4_1 latihan4 = new Latihan_4_1();
            this.Hide();
            latihan3.Close();
            latihan4.Show();
        }

        private void toolStripComboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(toolStripComboBox2.Items[e.Index].ToString(), new Font(toolStripComboBox2.Items[e.Index].ToString(), toolStripComboBox2.Font.Size), Brushes.Black, e.Bounds);
        }

        private void toolStripComboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            // a dropdownlist may initially have no item selected, so skip the highlighting:
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.toolStripComboBox3.Items[e.Index].ToString();
                SolidBrush b = new SolidBrush(Color.FromName(s));
                // Draw a rectangle and fill it with the current color
                // and add the name to the right of the color
                e.Graphics.DrawRectangle(Pens.Black, 2, e.Bounds.Top + 1, 20, 11);
                e.Graphics.FillRectangle(b, 3, e.Bounds.Top + 2, 19, 10);
                e.Graphics.DrawString(s, this.Font, Brushes.Black, 25, e.Bounds.Top);
                brush.Dispose();
                tBrush.Dispose();
            }
            e.DrawFocusRectangle();
        }


        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox x = (ToolStripComboBox)sender;
            if (!x.Focused)
                return;
            update_teks();
        }


        public void update_teks()
        {
            float fontsize;
            if (toolStripComboBox1.Text == "")
                fontsize = 12;
            else
                fontsize = (float)Convert.ToDouble(toolStripComboBox1.SelectedItem);
            FontStyle style = (tombol_bold.Checked) ? FontStyle.Bold : FontStyle.Regular;
            style |= (tombol_italic.Checked) ? FontStyle.Italic : FontStyle.Regular;
            style |= (tombol_underline.Checked) ? FontStyle.Underline : FontStyle.Regular;
            Font baru = new Font(toolStripComboBox2.SelectedItem.ToString(), fontsize, style);
            richTextBox1.SelectionFont = baru;
            richTextBox1.SelectionColor = Color.FromName(toolStripComboBox3.Text);
            richTextBox1.Focus();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox x = (ToolStripComboBox)sender;
            if (!x.Focused)
                return;
            update_teks();
        }

        private void tombol_bold_Click(object sender, EventArgs e)
        {
            update_teks();
        }

        private void tombol_italic_Click(object sender, EventArgs e)
        {
            update_teks();
        }

        private void tombol_underline_Click(object sender, EventArgs e)
        {
            update_teks();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                try
                {
                    toolStripComboBox2.SelectedItem = richTextBox1.SelectionFont.FontFamily.Name;
                }
                catch
                {
                    toolStripComboBox2.Text = "";
                }

                try
                {
                    toolStripComboBox1.SelectedIndex = (int)richTextBox1.SelectionFont.Size - 5;
                }
                catch { toolStripComboBox1.Text = ""; }

                try
                {
                    toolStripComboBox3.SelectedItem = richTextBox1.SelectionColor.Name;
                }
                catch
                {
                    toolStripComboBox3.Text = "";
                }

                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Bold") != -1)
                    tombol_bold.Checked = true;

                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Italic") != -1)
                    tombol_italic.Checked = true;

                if (richTextBox1.SelectionFont.Style.ToString().IndexOf("Underline") != -1)
                    tombol_underline.Checked = true;
            }
            else
            {
                toolStripComboBox1.SelectedIndex = 7;
                toolStripComboBox2.SelectedIndex = 14;
            }
        }


        private void toolStripComboBox2_LostFocus(object sender, EventArgs e)
        {
            update_teks();
        }

        
    }
}
