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
    public partial class frmUygulamaDuzenle : Form
    {
        public frmUygulamaDuzenle(frmAna frm,UygulamaBilgisi uyg)
        {
            InitializeComponent();
            kokForm = frm;
            uygulama = uyg;
        }
        frmAna kokForm;
        UygulamaBilgisi uygulama;


        private void btnEkle_Click(object sender, EventArgs e)
        {
            string temelLink = string.Format("{0}{1}", kokForm.ftpSunucuAdresi, this.uygulama.Namespace);
            //lblDurum.Text = i.ToString() + "/" + paketler.Count(); 
            //Klasör oluştur
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(temelLink);
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                ftpRequest.Credentials = new NetworkCredential(kokForm.ftpKullaniciAdi, kokForm.ftpSifre);
                ftpRequest.RenameTo =txtNamespace.Text.Trim();
                using (var resp = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }

                UygulamaBilgisi uygulama = new UygulamaBilgisi();
                uygulama.Namespace = txtNamespace.Text.Trim();
                uygulama.UygulamaAdi = txtUygulamaAdi.Text;
                uygulama.ID = this.uygulama.ID;

                HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}uygulama/{1}", kokForm.apiSunucuAdresi, new JavaScriptSerializer().Serialize(uygulama)));
                istek.Method = "PATCH";
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream()))
                {
                    string sonuc = okuyucu.ReadToEnd();
                    if (sonuc == "true") { kokForm.OnYukle(); this.Close(); }
                    else
                        MessageBox.Show("Veritabanı kaydı yapılamadı.");
                }

            }
            catch (Exception ex) { ex.logKaydiEkle(); MessageBox.Show("Kayıt yapılamadı."); }

        }

        private void frmUygulamaDuzenle_Load(object sender, EventArgs e)
        {
            lblUygID.Text = uygulama.ID.ToString();
            txtNamespace.Text = uygulama.Namespace;
            txtUygulamaAdi.Text = uygulama.UygulamaAdi;
        }
    }
}
