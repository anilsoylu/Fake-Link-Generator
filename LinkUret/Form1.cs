using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkUret
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count = Convert.ToInt32(lblCount.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void BtnLink1_Click(object sender, EventArgs e)
        {
            lblSonucYaz.Text = "";
            btnTRLinkCopy.Enabled = true;
            var link1list = File.ReadLines(@"trlink.txt", Encoding.GetEncoding("iso-8859-9"));
            List<string> Yazilar = new List<string>();
            foreach (var yenilink1 in link1list)
            {
                Yazilar.Add(yenilink1);
            }

            Random Rastgele = new Random();
            int indeks = Rastgele.Next(1, Yazilar.Count);
            lblTRLinkURL.Text = Yazilar[indeks];
        }

        private void BtnEnLinkUret_Click(object sender, EventArgs e)
        {
            lblSonucYaz.Text = "";
            btnENLinkCopy.Enabled = true;
            var link1list = File.ReadLines(@"enlink.txt", Encoding.GetEncoding("iso-8859-9"));
            List<string> Yazilar = new List<string>();
            foreach (var yenilink1 in link1list)
            {
                Yazilar.Add(yenilink1);
            }

            Random Rastgele = new Random();
            int indeks = Rastgele.Next(0, Yazilar.Count);
            lblENLinkURL.Text = Yazilar[indeks];
        }

        private void btnTRLinkCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTRLinkURL.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtSiteAdi.Text.Trim()))
                {
                    lblCountText.Visible = true;
                    lblCount.Visible = true;
                    count = count + 1;
                    lblCount.Text = count.ToString();
                    Clipboard.SetText(txtSiteAdi.Text.Replace("/", "") + "/" + lblTRLinkURL.Text);
                    lblSonucYaz.Text = "TR Link Başarıyla Kopyalandı !";
                    lblSonucYaz.ForeColor = Color.Green;
                    btnTRLinkCopy.Enabled = false;
                }
                else
                {
                    lblSonucYaz.Text = "Domain adı yazıp tekrar deneyin !";
                    lblSonucYaz.ForeColor = Color.Brown;
                }
            }
            else
            {
                lblSonucYaz.Text = "Kopyalamadan önce TR link oluşturun !";
                lblSonucYaz.ForeColor = Color.Brown;
            }
        }

        private void BtnENLinkCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblENLinkURL.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtSiteAdi.Text.Trim()))
                {
                    lblCountText.Visible = true;
                    lblCount.Visible = true;
                    count = count + 1;
                    lblCount.Text = count.ToString();
                    Clipboard.SetText(txtSiteAdi.Text.Replace("/", "") + "/" + lblENLinkURL.Text);
                    lblSonucYaz.Text = "EN Link Başarıyla Kopyalandı !";
                    lblSonucYaz.ForeColor = Color.Green;
                    btnENLinkCopy.Enabled = false;
                }
                else
                {
                    lblSonucYaz.Text = "Domain adı yazıp tekrar deneyin !";
                    lblSonucYaz.ForeColor = Color.Brown;
                }
            }
            else
            {
                lblSonucYaz.Text = "Kopyalamadan önce EN link oluşturun !";
                lblSonucYaz.ForeColor = Color.Brown;
            }
        }
    }
}
