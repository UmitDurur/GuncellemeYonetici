using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;

namespace GuncellemeYonetici
{
    public partial class flowVersiyonlar : UserControl
    {
        public flowVersiyonlar()
        {
            InitializeComponent();
        }

        UygulamaBilgisi aktifUygulama = null;

        Button sonSecili = null;

        private void flowDuzenlenmis_Load(object sender, EventArgs e)
        {
            flowListe.HorizontalScroll.Enabled = false;
            flowListe.AutoScroll = true;
            //flow.BackColor = Color.FromArgb(255, 0, 99, 177);
        }


        #region Versiyon Kısmı

        public void versiyonCek(UygulamaBilgisi uygulama)
        {
            aktifUygulama = uygulama;
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}guncelleme/{1}/", ((frmAna)Parent).apiSunucuAdresi, uygulama.Namespace));
            istek.Method = "GET";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    versiyonDoldur(new JavaScriptSerializer().Deserialize<VersiyonBilgisi[]>(okuyucu.ReadToEnd()));
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        public void versiyonCek()
        {
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}guncelleme/{1}/", ((frmAna)Parent).apiSunucuAdresi, aktifUygulama.Namespace));
            istek.Method = "GET";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    versiyonDoldur(new JavaScriptSerializer().Deserialize<VersiyonBilgisi[]>(okuyucu.ReadToEnd()));
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        private void versiyonDoldur(VersiyonBilgisi[] versiyonlar)
        {
            if (flowListe.Controls.Count > 0)
                flowListe.Controls.Clear();
            if(versiyonlar!=null)
            foreach (VersiyonBilgisi versiyon in versiyonlar)
            {
                Button btn = new Button();
                btn.Text = versiyon.Versiyon;
                btn.Tag = versiyon;
                btn.Click += new EventHandler(versiyonButonu_Click);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(255, 0, 99, 177);
                btn.Width = flowListe.Width - 20;
                btn.Margin = new Padding(0);
                flowListe.Controls.Add(btn);
            }
        }
        private void versiyonButonu_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (sonSecili != null && sonSecili != b)
            {
                sonSecili.BackColor = Color.FromArgb(255, 0, 99, 177);
                sonSecili.Controls.Clear();
            }

            if (sonSecili != b)
            {
                b.BackColor = Color.FromArgb(255, 0, 120, 215);
                ((frmAna)Parent).versiyonAyrintisiDoldur((VersiyonBilgisi)b.Tag, aktifUygulama);

                Button btn = new Button();
                btn.Text = "Sil";
                btn.Click += new EventHandler(btnSil_Click);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.ForeColor = Color.White;
                btn.Width = 30;
                btn.Location = new Point(b.Right-30,0);
                btn.Parent = b;
                b.Controls.Add(btn);
            }

            sonSecili = b;
        }
        #endregion

        private void btnSil_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}guncelleme/{1}/", ((frmAna)Parent).apiSunucuAdresi, ((VersiyonBilgisi)b.Parent.Tag).ID));
            istek.Method = "DELETE";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    string sonuc = okuyucu.ReadToEnd();
                    if (sonuc == "true") { versiyonCek(); }
                    else
                        MessageBox.Show("Veritabanı kaydı yapılamadı."+sonuc);
                }
            }
            catch (Exception ex)
            {
                ex.logKaydiEkle();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            frmVersiyon versiyon = new frmVersiyon((frmAna)Parent);
            versiyon.ShowDialog();
            
            /*HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}guncelleme/{1}/{2}/", ((frmAna)Parent).apiSunucuAdresi, lblGuncellemeKodu.Text, btnYayinlaKaldir.Tag.ToString()));
            istek.Method = "POST";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    string sonuc = okuyucu.ReadToEnd();
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }*/
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            frmVersiyonDuzenle versiyon = new frmVersiyonDuzenle((frmAna)this.Parent);
            versiyon.ShowDialog();
        }
    }
}
