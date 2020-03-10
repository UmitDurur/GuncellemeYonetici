using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuncellemeYonetici
{
    public partial class frmAnaEski : Form
    {
        public frmAnaEski()
        {
            InitializeComponent();
            apiSunucuAdresi = Bilesenler.AyarAl("guncelleme_sunucu_adresi");
        }
        public readonly string apiSunucuAdresi, ftpSunucuAdresi, ftpKullaniciAdi, ftpSifre;
        UygulamaBilgisi[] uygulamalar;


        private void frmAna_Load(object sender, EventArgs e)
        {
            uygulamaListesiYukle();
            //lbxUygulamalar.SelectedIndex = 0;
            //lbxVersiyonlar.SelectedIndex = 0;
        }

        private void lbxVersiyonlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VersiyonBilgisi secili = (VersiyonBilgisi)lbxVersiyonlar.SelectedItem;
                lblNamespace.Text = ((UygulamaBilgisi)lbxUygulamalar.SelectedItem).Namespace;
                if (secili.GuncellemeDurumu == 0) {
                    lblGuncellemeDurumu.Text = "Yayınlanmadı"; lblGuncellemeDurumu.ForeColor = Color.Red;
                } else if (secili.GuncellemeDurumu == 1) { lblGuncellemeDurumu.Text = "Yayınlandı"; lblGuncellemeDurumu.ForeColor = Color.Green; }
                lblZorunlu.Text = secili.Zorunlu == 0 ? "Zorunlu değil":"Zorunlu";
                lblVersiyon.Text = secili.Versiyon;
                lblGuncellemeNotu.Text = secili.GuncellemeNotu;
                lblPaketSayisi.Text =secili.PaketSayisi.ToString();
                
                pnlAyrintilar.Enabled = true;
            }
            catch { }
        }

        private void btnUygulamaEkle_Click(object sender, EventArgs e)
        {

        }

        private void uygulamaListesiYukle()
        {
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}uygulama/", apiSunucuAdresi));
            istek.Method = "GET";
            try
            {
                WebResponse cevap = istek.GetResponse(); 
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    uygulamalar = new JavaScriptSerializer().Deserialize<UygulamaBilgisi[]>(okuyucu.ReadToEnd());
                }
                lbxUygulamalar.DataSource = uygulamalar;
                lbxUygulamalar.DisplayMember = "Namespace";
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        private void lbxUygulamalar_SelectedIndexChanged(object sender, EventArgs e)
        {try
            {
                versiyonBilgisiGetir(((UygulamaBilgisi)lbxUygulamalar.SelectedItem).Namespace);
            }
            catch { }
        }
        private void versiyonBilgisiGetir(string _namespace) {
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}guncelleme/{1}/", apiSunucuAdresi,_namespace));
            istek.Method = "GET";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    lbxVersiyonlar.DataSource = new JavaScriptSerializer().Deserialize<VersiyonBilgisi[]>(okuyucu.ReadToEnd());
                    lbxVersiyonlar.DisplayMember = "Versiyon";
                }
                
            }
            catch (Exception ex) { ex.logKaydiEkle(); }

        }
    }
}
