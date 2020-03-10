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
    public partial class frmVersiyon : Form
    {
        public frmVersiyon(frmAna kokForm)
        {
            InitializeComponent();
            this.kokForm = kokForm;
            flowUygulamalar uygulamalar = (flowUygulamalar)kokForm.Controls.Find("flowUygulamalar", true).FirstOrDefault();
            FlowLayoutPanel flowListe = (FlowLayoutPanel)uygulamalar.Controls.Find("flowListe", true).FirstOrDefault();
            foreach (Button buton in flowListe.Controls)
            { cmbxNamespace.Items.Add(((UygulamaBilgisi)buton.Tag).Namespace); }
        }

        frmAna kokForm;
        UygulamaPaketi[] paketler = null;


        private void btnEkle_Click(object sender, EventArgs e)
        {
            lblKayitDurum.Text = "Dosya sunucuya yükleniyor.";
            btnEkle.Enabled = false;
            if (paketler != null)
                bgwYukleyici.RunWorkerAsync();
            else veritabaninaKaydet();
        }


        private void btnPaketSec_Click(object sender, EventArgs e)
        {
            frmPaketSec pktsec = new frmPaketSec((int)numericPaketSayisi.Value);
            pktsec.ShowDialog();
            paketler = pktsec.paketler;
        }

        private void veritabaninaKaydet() {
            lblKayitDurum.Text = "Veritabanına kaydediliyor.";
            VersiyonBilgisi versiyon = new VersiyonBilgisi();
            versiyon.GuncellemeNotu = txtGuncelemeNotu.Text;
            versiyon.GuncellemeDurumu = 0;
            versiyon.PaketSayisi = (int)numericPaketSayisi.Value;
            versiyon.Versiyon = txtVersiyon.Text;
            versiyon.Namespace = cmbxNamespace.Text;
            versiyon.Zorunlu = cbxZorunlu.Checked ? (byte)1 : (byte)0;
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(string.Format("{0}guncelleme/{1}", kokForm.apiSunucuAdresi, new JavaScriptSerializer().Serialize(versiyon)));
            istek.Method = "POST";
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(), Encoding.UTF8))
                {
                    string sonuc = okuyucu.ReadToEnd();
                    if (sonuc == "true") { this.Close(); }
                    else
                        lblKayitDurum.Text = "Veritabanı kaydı yapılamadı.";
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        private void bgwYukleyici_DoWork(object sender, DoWorkEventArgs e)
        {
           string temelLink= string.Format("{0}{1}/{2}/",kokForm.ftpSunucuAdresi,cmbxNamespace.Text,txtVersiyon.Text);
            //lblDurum.Text = i.ToString() + "/" + paketler.Count(); 
            //Klasör oluştur
            WebRequest ftpRequest = WebRequest.Create(temelLink);
            ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
            ftpRequest.Credentials = new NetworkCredential(kokForm.ftpKullaniciAdi, kokForm.ftpSifre);
            using (var resp = (FtpWebResponse)ftpRequest.GetResponse())
            {
            }
            try
            {

                for (int i=1;i<= paketler.Count();i++)
                {
                    lblDurum.Text = i.ToString() + "/" + paketler.Count();
                   
                    //upload new file
                    FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(string.Format("{0}{1}.zip", temelLink,i.ToString()));
                    requestFTPUploader.UseBinary = true;
                    requestFTPUploader.Credentials = new NetworkCredential(kokForm.ftpKullaniciAdi, kokForm.ftpSifre);
                    requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

                    FileInfo fileInfo = new FileInfo(paketler[i-1].Konum);
                    FileStream fileStream = fileInfo.OpenRead();

                    int bufferLength = 2048;
                    byte[] buffer = new byte[bufferLength];
                    double inen=0;
                    Stream uploadStream = requestFTPUploader.GetRequestStream();
                    int contentLength = fileStream.Read(buffer, 0, bufferLength);

                    while (contentLength != 0)
                    {
                        uploadStream.Write(buffer, 0, contentLength);
                        bgwYukleyici.ReportProgress(Convert.ToInt32((inen/fileInfo.Length)*100));
                        contentLength = fileStream.Read(buffer, 0, bufferLength);inen += contentLength;
                    }

                    uploadStream.Close();
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bgwYukleyici_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressYukleme.Value = e.ProgressPercentage;
        }

        private void bgwYukleyici_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            veritabaninaKaydet(); 
        }
    }
}
