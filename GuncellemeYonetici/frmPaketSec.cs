using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuncellemeYonetici
{
    public partial class frmPaketSec : Form
    {
        public frmPaketSec(int paketSayisi)
        {
            InitializeComponent();
            int y = 0;
            for (int i = 1; i <= paketSayisi; i++)
            {
                Label lbl = new Label(); lbl.Text = i.ToString() + ". dosyanın konumu: ";
                lbl.Location = new Point(0, y);
                lbl.Width = 105;
                pnlKonumlar.Controls.Add(lbl);

                Label lbl2 = new Label();
                lbl2.Location = new Point(105, y);
                lbl2.Name = "lbl" + i.ToString();
                lbl2.Width = 80;
                pnlKonumlar.Controls.Add(lbl2);


                Button btn = new Button();
                btn.Location = new Point(pnlKonumlar.Right-btn.Width, y);
                btn.Tag = i;
                btn.Text = "Seç";
                btn.Click += new EventHandler(btnKonumAl_Click);
                pnlKonumlar.Controls.Add(btn);

                y += lbl.Height;
            }

            paketler = new UygulamaPaketi[paketSayisi];
        }

        public UygulamaPaketi[] paketler = null;

        private void btnKonumAl_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int indis = (int)btn.Tag;
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Zip Dosyası |*.zip";
            of.RestoreDirectory = true;
            of.ShowDialog();
            pnlKonumlar.Controls.Find("lbl" + indis, true).FirstOrDefault().Text = of.SafeFileName;
            UygulamaPaketi paket = new UygulamaPaketi();
            paket.PaketNo = indis;
            paket.Konum = of.FileName;
            paketler[indis - 1] = paket;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
