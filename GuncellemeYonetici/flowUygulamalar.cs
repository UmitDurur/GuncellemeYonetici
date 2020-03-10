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
    public partial class flowUygulamalar : UserControl
    {
        public flowUygulamalar()
        {
            InitializeComponent();
        }

        //Uygulama değişkeni
        flowVersiyonlar flowVersiyon = null;

        //ortak
        public Button sonSecili = null;

        public void OnYukle()
        {
                flowVersiyon = (flowVersiyonlar)Parent.Controls.Find("flowVersiyonlar", true).FirstOrDefault();
        }

        private void flowDuzenlenmis_Load(object sender, EventArgs e)
        {
            flowListe.HorizontalScroll.Enabled = false;
            flowListe.AutoScroll = true;
            //flow.BackColor = Color.FromArgb(255, 0, 99, 177);
        }


        #region Uygulama Kısmı

        private void uygulamaButonu_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (sonSecili == null)
                flowVersiyon.Visible = true;
            else if (sonSecili != null && sonSecili != b)
                sonSecili.BackColor = Color.FromArgb(255, 0, 99, 177);

            if (sonSecili != b)
            {
                b.BackColor = Color.FromArgb(255, 0, 120, 215);
                flowVersiyon.versiyonCek((UygulamaBilgisi)b.Tag);
            }



            /*
            if (sonSecili == null)
            {
                flowVersiyon.Visible = true;
                b.BackColor = Color.FromArgb(255, 0, 120, 215);
                flowVersiyon.versiyonCek((UygulamaBilgisi)b.Tag);
            }
            if (sonSecili != null && b != sonSecili)
            {
                sonSecili.BackColor = Color.FromArgb(255, 0, 99, 177);
                b.BackColor = Color.FromArgb(255, 0, 120, 215);
            }*/
            sonSecili = b;
        }

        public void uygulamaDoldur(UygulamaBilgisi[] uygulamalar)
        {
            if (flowListe.Controls.Count > 0)
                flowListe.Controls.Clear();
            foreach (UygulamaBilgisi uygulama in uygulamalar)
            {
                Button btn = new Button();
                btn.Text = uygulama.UygulamaAdi +" - "+ uygulama.Namespace;
                btn.Tag = uygulama;
                btn.Click += new EventHandler(uygulamaButonu_Click);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(255, 0, 99, 177);
                btn.Width = flowListe.Width - 20;
                btn.Margin = new Padding(0);
                flowListe.Controls.Add(btn);
            }
        }
        #endregion

        private void btnEkle_Click(object sender, EventArgs e)
        {
            frmUygulamaEkle uygulama = new frmUygulamaEkle((frmAna)this.Parent);
            uygulama.ShowDialog();            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            frmUygulamaDuzenle uygulama = new frmUygulamaDuzenle((frmAna)this.Parent,(UygulamaBilgisi)sonSecili.Tag);
            uygulama.ShowDialog();
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            frmUygulama uygulama = new frmUygulama((UygulamaBilgisi)sonSecili.Tag);
            uygulama.ShowDialog();
        }
    }
}
