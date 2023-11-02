using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotePad
{
    public partial class Form1 : Form
    {
        bool acikDosyaVarMi = false;
        bool degisiklikVarMi = false;
        string acikDosyaAdi = "Adsız";

        public Form1()
        {
            InitializeComponent();
            this.Text = acikDosyaAdi + "-" + "NotePad";
        }

        public void yeniIslemleri()
        {
            richTextBox1.Clear();
            acikDosyaVarMi = false;
            degisiklikVarMi = false;
            acikDosyaAdi = "Adsız";
            this.Text = acikDosyaAdi + "-" + "NotePad";
        }

        public void dosyaAcmaIslemleri()
        {
            OpenFileDialog od = new OpenFileDialog();
            DialogResult basilan = od.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                acikDosyaAdi = od.FileName;
                richTextBox1.LoadFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                acikDosyaVarMi = true;
                degisiklikVarMi = false;
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarMi == false)
            {
                if (degisiklikVarMi == false)
                {
                    yeniIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "NotePad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                    {
                        yeniIslemleri();
                    }
                    else if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.DefaultExt = ".txt";
                        sd.Filter = "Metin Dosyaları|*.txt";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            yeniIslemleri();
                        }
                    }
                }
            }//if yenidosyaislemi

            else
            {
                if (degisiklikVarMi == false)
                {
                    yeniIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "NotePad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                    {
                        yeniIslemleri();
                    }
                    else if (basilan == DialogResult.Yes)
                    {
                        richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        yeniIslemleri();
                    }
                }
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarMi == false)
            {
                if (degisiklikVarMi == false)
                {
                    dosyaAcmaIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "NotePad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                    {
                        dosyaAcmaIslemleri();
                    }
                    else if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.DefaultExt = ".txt";
                        sd.Filter = "Metin Dosyaları|*.txt";
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            dosyaAcmaIslemleri();
                        }
                    }
                }
            }//if acikdosyavarmi

            else
            {
                if (degisiklikVarMi == false)
                {
                    dosyaAcmaIslemleri();
                }
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "NotePad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                    {
                        dosyaAcmaIslemleri();
                    }
                    else if (basilan == DialogResult.Yes)
                    {
                        richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        dosyaAcmaIslemleri();
                    }
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            degisiklikVarMi = true;
            this.Text = "*" + acikDosyaAdi + "-" + "NotePad";
            if (richTextBox1.Text == "" && degisiklikVarMi == false)
            {
                this.Text = acikDosyaAdi + "-" + "NotePad";
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter yazmaNesnesi = new StreamWriter(acikDosyaAdi, false);
            yazmaNesnesi.Write(richTextBox1.Text);
            yazmaNesnesi.Close();
            /*richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);*/
            this.Text = acikDosyaAdi + "-" + "NotePad";
            degisiklikVarMi = false;
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.DefaultExt = ".txt";
            sd.Filter = "Metin Dosyaları|*.txt";
            DialogResult basilan = sd.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void sözcükKaydırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sözcükKaydırToolStripMenuItem.Checked = !sözcükKaydırToolStripMenuItem.Checked;
            richTextBox1.WordWrap = sözcükKaydırToolStripMenuItem.Checked;
        }

        private void yazıBiçimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult basilan = fd.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                Font secilenFont = fd.Font;
                richTextBox1.SelectionFont = secilenFont;
            }
        }

        private void durumÇubuğuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            durumÇubuğuToolStripMenuItem.Checked = !durumÇubuğuToolStripMenuItem.Checked;
            statusStrip1.Visible = durumÇubuğuToolStripMenuItem.Checked;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
