using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Latihan_4_1 : Form
    {
        public bool isSave = true;
        public string saveFileDirectory = "";
        public Latihan_4_1()
        {
            InitializeComponent();
        }

        private void Latihan_4_1_Load(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.AutoPopDelay = 5000;
            tooltip.InitialDelay = 1000;
            tooltip.ReshowDelay = 500;
            tooltip.SetToolTip(this.halaman2prev, "Back");
            tooltip.SetToolTip(this.halaman2next, "Next");
            
            Color clr = new Color();
            PropertyInfo[] colors = clr.GetType().GetProperties();
            for (int i = 8; i <= 72; i++)
            {
                fontsize.Items.Add(i);
            }

            InstalledFontCollection fontsCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontsCollection.Families;
            foreach (FontFamily font in fontFamilies)
            {
                fontfamily.Items.Add(font.Name);
            }

            this.fontbackground.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.fontforeground.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            foreach (PropertyInfo color in colors)
            {
                if (color.PropertyType == typeof(System.Drawing.Color))
                {
                    fontbackground.Items.Add(color.Name);
                    fontforeground.Items.Add(color.Name);
                }
            }

            //inisiasi
            fontsize.SelectedIndex = 3;
            fontfamily.Text = "Calibri";
            fontforeground.Text = "Black";
            fontbackground.Text = "White";
            changeText();
            //event
            this.fontbackground.ComboBox.DrawItem += new DrawItemEventHandler(fontforeground_DrawItem);
            this.fontforeground.ComboBox.DrawItem += new DrawItemEventHandler(fontforeground_DrawItem);
        }
        private void fontforeground_DrawItem(object sender, DrawItemEventArgs e)
        {
            // a dropdownlist may initially have no item selected, so skip the highlighting:
            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;
                Brush brush = new SolidBrush(e.BackColor);
                Brush tBrush = new SolidBrush(e.ForeColor);

                g.FillRectangle(brush, e.Bounds);
                string s = (string)this.fontbackground.Items[e.Index].ToString();
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
        private void rtb_SelectionChanged(object sender, EventArgs e)
        {
            tombolbold.Checked = false;
            tombolitalic.Checked = false;
            tombolunderline.Checked = false;
            if (rtb.SelectionFont != null)
            {
                fontfamily.Text = rtb.SelectionFont.FontFamily.Name;
                fontsize.Text = rtb.SelectionFont.Size.ToString();
                if (rtb.SelectionFont.Style.ToString().IndexOf("Bold") >= 0)
                {
                    tombolbold.Checked = true;
                }
                if (rtb.SelectionFont.Style.ToString().IndexOf("Italic") >= 0)
                {
                    tombolitalic.Checked = true;
                }
                if (rtb.SelectionFont.Style.ToString().IndexOf("Underline") >= 0)
                {
                    tombolunderline.Checked = true;
                }
            }
            else
            {
                fontfamily.Text = "";
                fontsize.Text = "";
            }

            if (rtb.SelectionColor.Name == "0")
            {
                fontforeground.Text = "Black";
            }
            else
            {
                fontforeground.Text = rtb.SelectionColor.Name;
            }

            fontbackground.Text = rtb.BackColor.Name;
        }
        private void fontsize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            changeText(sender);
        }
        private void fontforeground_SelectedIndexChanged(object sender, EventArgs e)
        {
            int length = rtb.SelectionLength;
            int start = rtb.SelectionStart;
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            rtb.SelectionColor = Color.FromName(fontforeground.Text);
            rtb.Select(start, length);
        }
        private void tscbBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int length = rtb.SelectionLength;
            int start = rtb.SelectionStart;
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            rtb.SelectionBackColor = Color.FromName(fontbackground.Text);
            rtb.Select(start, length);
        }
        private void fontfamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox tscb = (ToolStripComboBox)sender;
            if (!tscb.Focused)
            {
                return;
            }
            changeText(sender);
        }
        private void fontsize_LostFocus(object sender, EventArgs e)
        {
            changeText(sender);
        }
        private void fontforeground_LostFocus(object sender, EventArgs e)
        {
            int length = rtb.SelectionLength;
            int start = rtb.SelectionStart;
            rtb.SelectionColor = Color.FromName(fontforeground.Text);
            rtb.Select(start, length);
        }
        private void fontbackground_LostFocus(object sender, EventArgs e)
        {
            int length = rtb.SelectionLength;
            int start = rtb.SelectionStart;
            rtb.SelectionBackColor = Color.FromName(fontbackground.Text);
            rtb.Select(start, length);
        }
        private void fontfamily_LostFocus(object sender, EventArgs e)
        {
            changeText(sender);
        }
        private void tombolbold_Click(object sender, EventArgs e)
        {
            tombolbold.Checked ^= true;
            changeText(sender);
        }

        private void tombolitalic_Click(object sender, EventArgs e)
        {
            tombolitalic.Checked ^= true;
            changeText(sender);
        }

        private void tombolunderline_Click(object sender, EventArgs e)
        {
            tombolunderline.Checked ^= true;
            changeText(sender);
        }

        private void saveFile()
        {
            DialogResult dr;
            if (saveFileDirectory == "")
            {
                saveFileDialog1.Filter = "Text File | *.txt";
                dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    rtb.SaveFile(saveFileDialog1.FileName);
                    saveFileDirectory = saveFileDialog1.FileName;
                    this.Text = "Form 4.1 - " + saveFileDialog1.FileName;
                }
            }
            else
            {
                dr = MessageBox.Show("File ini telah pernah disimpan. Apakah anda ingin menimpanya?", "Simpan File", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    rtb.SaveFile(saveFileDirectory);
                }
            }
            isSave = true;
        }
        private void changeText(object sender = null)
        {
            bool isBold, isItalic, isUnderline;
            int length = rtb.SelectionLength;
            int start = rtb.SelectionStart;
            float fontSize;
            string fontFamily;
            System.Drawing.FontStyle currentStyle;
            this.rtb.SelectionChanged -= new System.EventHandler(this.rtb_SelectionChanged);
            if (length == 0)
            {
                fontFamily = (fontfamily.Text == "") ? rtb.SelectionFont.FontFamily.Name : fontfamily.Text;
                fontSize = (fontsize.Text == "") ? rtb.SelectionFont.Size : Convert.ToSingle(fontsize.Text);

                isBold = rtb.SelectionFont.Bold;
                isItalic = rtb.SelectionFont.Italic;
                isUnderline = rtb.SelectionFont.Underline;

                if (sender != null && sender.ToString() == "tombolbold")
                {
                    isBold = tombolbold.Checked;
                }
                else if (sender != null && sender.ToString() == "tombolitalic")
                {
                    isItalic = tombolitalic.Checked;
                }
                else if (sender != null && sender.ToString() == "tombolunderline")
                {
                    isUnderline = tombolunderline.Checked;
                }

                currentStyle = (isBold) ? FontStyle.Bold : FontStyle.Regular;
                currentStyle |= (isItalic) ? FontStyle.Italic : FontStyle.Regular;
                currentStyle |= (isUnderline) ? FontStyle.Underline : FontStyle.Regular;

                rtb.SelectionFont = new Font(fontFamily,
                                                fontSize,
                                                currentStyle);
            }
            for (int i = start; i < start + length; i++)
            {
                rtb.SelectionChanged -= new System.EventHandler(this.rtb_SelectionChanged);
                rtb.Select(i, 1);
                fontFamily = (fontfamily.Text == "") ? rtb.SelectionFont.FontFamily.Name : fontfamily.Text;
                fontSize = (fontsize.Text == "") ? rtb.SelectionFont.Size : Convert.ToSingle(fontsize.Text);

                isBold = rtb.SelectionFont.Bold;
                isItalic = rtb.SelectionFont.Italic;
                isUnderline = rtb.SelectionFont.Underline;

                if (sender != null && sender.ToString() == "tombolbold")
                {
                    isBold = tombolbold.Checked;
                }
                else if (sender != null && sender.ToString() == "tombolitalic")
                {
                    isItalic = tombolitalic.Checked;
                }
                else if (sender != null && sender.ToString() == "tombolunderline")
                {
                    isUnderline = tombolunderline.Checked;
                }

                currentStyle = (isBold) ? FontStyle.Bold : FontStyle.Regular;
                currentStyle |= (isItalic) ? FontStyle.Italic : FontStyle.Regular;
                currentStyle |= (isUnderline) ? FontStyle.Underline : FontStyle.Regular;

                rtb.SelectionFont = new Font(fontFamily,
                                                fontSize,
                                                currentStyle);
            }

            rtb.Focus();
            rtb.Select(start, length);

            this.rtb.SelectionChanged += new System.EventHandler(this.rtb_SelectionChanged);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (!isSave)
            {
                dr = MessageBox.Show("Apakah Anda ingin menyimpan file terlebih dahulu?", "Simpan file", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    saveFile();
                }
            }
            dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                rtb.LoadFile(openFileDialog1.FileName);
                saveFileDirectory = openFileDialog1.FileName;
                this.Text = "Form 4.1 - " + openFileDialog1.FileName;
            }
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {
            isSave = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            if (!isSave)
            {
                dr = MessageBox.Show("Apakah Anda ingin menyimpan file terlebih dahulu?", "Simpan file", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    saveFile();
                }
            }
            isSave = true;
            saveFileDirectory = "";
            this.Text = "Form 4.1";
            rtb.Rtf = "";
        }
        private void halaman2prev_Click(object sender, EventArgs e)
        {
            Latihan_3_1 latihan3 = new Latihan_3_1();
            Latihan_4_1 latihan4 = new Latihan_4_1();
            this.Close();
            latihan4.Hide();
            latihan3.Show();

        }

    }
}
