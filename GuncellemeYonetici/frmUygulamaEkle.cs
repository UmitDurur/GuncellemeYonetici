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
    public partial class frmUygulamaEkle : Form
    {
        public frmUygulamaEkle(frmAna frm)
        {
            InitializeComponent();
            kokForm = frm;
        }
        frmAna kokForm;

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string temelLink = string.Format("{0}{1}/", kokForm.ftpSunucuAdresi, txtNamespace.Text);
            //lblDurum.Text = i.ToString() + "/" + paketler.Count(); 
            //Klasör oluştur
            try
            {
                WebRequest ftpRequest = WebRequest.Create(temelLink);
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpRequest.Credentials = new NetworkCredential(kokForm.ftpKullaniciAdi, kokForm.ftpSifre);
                using (var resp = (FtpWebResponse)ftpRequest.GetResponse())
                {
                }

                UygulamaBilgisi uygulama = new UygulamaBilgisi();
                uygulama.Namespace = txtNamespace.Text.Trim();
                uygulama.UygulamaAdi = txtUygulamaAdi.Text;
                uygulama.ID = 0;

                HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}uygulama/{1}", kokForm.apiSunucuAdresi, new JavaScriptSerializer().Serialize(uygulama)));
                istek.Method = "POST";
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream()))
                {
                    string sonuc = okuyucu.ReadToEnd();
                    if (sonuc == "true") { kokForm.OnYukle(); this.Close(); }
                    else
                        MessageBox.Show("Veritabanı kaydı yapılamadı.");
                }

            }
            catch (Exception ex) { ex.logKaydiEkle(); }

        }
    }
}
