using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuncellemeYonetici
{
    public partial class frmAna : Form
    {
        public frmAna()
        {
            InitializeComponent();
            apiSunucuAdresi = Bilesenler.AyarAl("guncelleme_sunucu_adresi");
            ftpSunucuAdresi = Bilesenler.AyarAl("guncelleme_ftp_adresi");
            ftpKullaniciAdi = Bilesenler.AyarAl("kullanici_adi");
            ftpSifre = Bilesenler.DESCoz(Bilesenler.AyarAl("Sfr"));
            OnYukle();
        }
        public readonly string apiSunucuAdresi, ftpSunucuAdresi, ftpKullaniciAdi, ftpSifre;

        private void btnYayinlaKaldir_Click(object sender, EventArgs e)
        {
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}yayinla/{1}/{2}/", apiSunucuAdresi, lblGuncellemeKodu.Text, btnYayinlaKaldir.Tag.ToString()));
            istek.Method = "POST";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    string sonuc = okuyucu.ReadToEnd();
                    if (sonuc == "true")
                    {
                        lblSonuc.ForeColor = Color.Green; lblSonuc.Text = btnYayinlaKaldir.Tag.ToString() == "1" ? "Yayınlandı." : "Yayından kaldırıldı.";
                        if (btnYayinlaKaldir.Tag.ToString() == "1")
                        {
                            btnYayinlaKaldir.Text = "Yayından kaldır";
                            lblGuncellemeDurumu.Text = "Yayınlandı";
                            lblGuncellemeDurumu.ForeColor = Color.Green;
                            if (lblNamespace.Text == ((UygulamaBilgisi)flowUygulamalar.sonSecili.Tag).Namespace)
                            {
                                FlowLayoutPanel flowListe = (FlowLayoutPanel)flowVersiyonlar.Controls.Find("flowListe", true).FirstOrDefault();
                                foreach (Button btn in flowListe.Controls)
                                {
                                    if (btn.Text == lblVersiyon.Text)
                                        ((VersiyonBilgisi)btn.Tag).GuncellemeDurumu = 1;
                                }
                            }
                            btnYayinlaKaldir.Tag = 0;
                        }
                        else
                        {
                            btnYayinlaKaldir.Text = "Yayınla";
                            lblGuncellemeDurumu.Text = "Yayınlanmadı";
                            lblGuncellemeDurumu.ForeColor = Color.Red;
                            if (lblNamespace.Text == ((UygulamaBilgisi)flowUygulamalar.sonSecili.Tag).Namespace)
                            {
                                FlowLayoutPanel flowListe = (FlowLayoutPanel)flowVersiyonlar.Controls.Find("flowListe", true).FirstOrDefault();
                                foreach (Button btn in flowListe.Controls)
                                {
                                    if (btn.Text == lblVersiyon.Text)
                                        ((VersiyonBilgisi)btn.Tag).GuncellemeDurumu = 0;
                                }
                            }
                            btnYayinlaKaldir.Tag = 1;
                        }
                    }
                    else
                    {
                        lblSonuc.ForeColor = Color.Red;
                        lblSonuc.Text = btnYayinlaKaldir.Tag.ToString() == "1" ? "Yayınlanamadı." : "Yayından kaldırılamadı.";
                    }
                    if (tmrDurumSil.Enabled)
                        tmrDurumSil.Stop();
                    tmrDurumSil.Start();
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        private void tmrDurumSil_Tick(object sender, EventArgs e)
        {
            lblSonuc.Text = "";
            tmrDurumSil.Stop();
        }

        public void OnYukle()
        {
            flowUygulamalar.OnYukle();

            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}uygulama/", apiSunucuAdresi));
            istek.Method = "GET";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    flowUygulamalar.uygulamaDoldur(new JavaScriptSerializer().Deserialize<UygulamaBilgisi[]>(okuyucu.ReadToEnd()));
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        public void versiyonAyrintisiDoldur(VersiyonBilgisi versiyon, UygulamaBilgisi uygulama)
        {
            lblUygulamaAdi.Text = uygulama.UygulamaAdi;
            lblNamespace.Text = uygulama.Namespace;
            lblVersiyon.Text = versiyon.Versiyon;
            lblPaketSayisi.Text = versiyon.PaketSayisi.ToString();
            if (versiyon.GuncellemeDurumu == 0)
            {
                lblGuncellemeDurumu.Text = "Yayınlanmadı"; lblGuncellemeDurumu.ForeColor = Color.Red; btnYayinlaKaldir.Text = "Yayınla"; btnYayinlaKaldir.Tag = 1;
            }
            else if (versiyon.GuncellemeDurumu == 1) { lblGuncellemeDurumu.Text = "Yayınlandı"; lblGuncellemeDurumu.ForeColor = Color.Green; btnYayinlaKaldir.Text = "Yayından kaldır"; btnYayinlaKaldir.Tag = 0; }
            lblZorunlu.Text = versiyon.Zorunlu == 0 ? "Zorunlu değil" : "Zorunlu";
            lblGuncellemeNotu.Text = versiyon.GuncellemeNotu;
            lblGuncellemeKodu.Text = versiyon.ID.ToString();
            btnYayinlaKaldir.Visible = true;
        }
    }
}
