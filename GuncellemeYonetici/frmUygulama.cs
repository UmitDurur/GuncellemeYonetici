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
    public partial class frmUygulama : Form
    {
        public frmUygulama(UygulamaBilgisi uygulama)
        {
            InitializeComponent();
            lblUygID.Text =uygulama.ID.ToString();
            lblUygulamaAdi.Text = uygulama.UygulamaAdi;
            lblUygulamaNamespace.Text = uygulama.Namespace;
        }
    }
}
