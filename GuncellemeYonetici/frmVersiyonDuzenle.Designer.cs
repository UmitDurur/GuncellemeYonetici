namespace GuncellemeYonetici
{
    partial class frmVersiyonDuzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlAyrintilar = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblKayitDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDurum = new System.Windows.Forms.Label();
            this.progressYukleme = new System.Windows.Forms.ProgressBar();
            this.btnPaketSec = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.cbxZorunlu = new System.Windows.Forms.CheckBox();
            this.txtGuncelemeNotu = new System.Windows.Forms.TextBox();
            this.numericPaketSayisi = new System.Windows.Forms.NumericUpDown();
            this.txtVersiyon = new System.Windows.Forms.TextBox();
            this.cmbxNamespace = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgwYukleyici = new System.ComponentModel.BackgroundWorker();
            this.pnlAyrintilar.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPaketSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAyrintilar
            // 
            this.pnlAyrintilar.Controls.Add(this.statusStrip1);
            this.pnlAyrintilar.Controls.Add(this.lblDurum);
            this.pnlAyrintilar.Controls.Add(this.progressYukleme);
            this.pnlAyrintilar.Controls.Add(this.btnPaketSec);
            this.pnlAyrintilar.Controls.Add(this.btnKaydet);
            this.pnlAyrintilar.Controls.Add(this.cbxZorunlu);
            this.pnlAyrintilar.Controls.Add(this.txtGuncelemeNotu);
            this.pnlAyrintilar.Controls.Add(this.numericPaketSayisi);
            this.pnlAyrintilar.Controls.Add(this.txtVersiyon);
            this.pnlAyrintilar.Controls.Add(this.cmbxNamespace);
            this.pnlAyrintilar.Controls.Add(this.label4);
            this.pnlAyrintilar.Controls.Add(this.label3);
            this.pnlAyrintilar.Controls.Add(this.label2);
            this.pnlAyrintilar.Controls.Add(this.label1);
            this.pnlAyrintilar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAyrintilar.Location = new System.Drawing.Point(0, 0);
            this.pnlAyrintilar.Name = "pnlAyrintilar";
            this.pnlAyrintilar.Size = new System.Drawing.Size(358, 324);
            this.pnlAyrintilar.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblKayitDurum});
            this.statusStrip1.Location = new System.Drawing.Point(0, 302);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(358, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblKayitDurum
            // 
            this.lblKayitDurum.Name = "lblKayitDurum";
            this.lblKayitDurum.Size = new System.Drawing.Size(0, 17);
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(12, 256);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 13);
            this.lblDurum.TabIndex = 17;
            // 
            // progressYukleme
            // 
            this.progressYukleme.Location = new System.Drawing.Point(12, 272);
            this.progressYukleme.Name = "progressYukleme";
            this.progressYukleme.Size = new System.Drawing.Size(334, 23);
            this.progressYukleme.TabIndex = 16;
            // 
            // btnPaketSec
            // 
            this.btnPaketSec.Location = new System.Drawing.Point(185, 60);
            this.btnPaketSec.Name = "btnPaketSec";
            this.btnPaketSec.Size = new System.Drawing.Size(88, 23);
            this.btnPaketSec.TabIndex = 15;
            this.btnPaketSec.Text = "Paketleri seç";
            this.btnPaketSec.UseVisualStyleBackColor = true;
            this.btnPaketSec.Click += new System.EventHandler(this.btnPaketSec_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(269, 247);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 14;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cbxZorunlu
            // 
            this.cbxZorunlu.AutoSize = true;
            this.cbxZorunlu.Location = new System.Drawing.Point(19, 218);
            this.cbxZorunlu.Name = "cbxZorunlu";
            this.cbxZorunlu.Size = new System.Drawing.Size(62, 17);
            this.cbxZorunlu.TabIndex = 10;
            this.cbxZorunlu.Text = "Zorunlu";
            this.cbxZorunlu.UseVisualStyleBackColor = true;
            // 
            // txtGuncelemeNotu
            // 
            this.txtGuncelemeNotu.Location = new System.Drawing.Point(112, 89);
            this.txtGuncelemeNotu.Multiline = true;
            this.txtGuncelemeNotu.Name = "txtGuncelemeNotu";
            this.txtGuncelemeNotu.Size = new System.Drawing.Size(232, 123);
            this.txtGuncelemeNotu.TabIndex = 9;
            // 
            // numericPaketSayisi
            // 
            this.numericPaketSayisi.Location = new System.Drawing.Point(112, 63);
            this.numericPaketSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPaketSayisi.Name = "numericPaketSayisi";
            this.numericPaketSayisi.Size = new System.Drawing.Size(40, 20);
            this.numericPaketSayisi.TabIndex = 8;
            this.numericPaketSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtVersiyon
            // 
            this.txtVersiyon.Location = new System.Drawing.Point(112, 37);
            this.txtVersiyon.Name = "txtVersiyon";
            this.txtVersiyon.ReadOnly = true;
            this.txtVersiyon.Size = new System.Drawing.Size(232, 20);
            this.txtVersiyon.TabIndex = 7;
            this.txtVersiyon.Click += new System.EventHandler(this.txtVersiyon_Click);
            // 
            // cmbxNamespace
            // 
            this.cmbxNamespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxNamespace.FormattingEnabled = true;
            this.cmbxNamespace.Location = new System.Drawing.Point(112, 12);
            this.cmbxNamespace.Name = "cmbxNamespace";
            this.cmbxNamespace.Size = new System.Drawing.Size(232, 21);
            this.cmbxNamespace.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Güncelleme notu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Paket sayısı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Versiyon";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespace";
            // 
            // bgwYukleyici
            // 
            this.bgwYukleyici.WorkerReportsProgress = true;
            this.bgwYukleyici.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwYukleyici_DoWork);
            this.bgwYukleyici.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwYukleyici_ProgressChanged);
            this.bgwYukleyici.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwYukleyici_RunWorkerCompleted);
            // 
            // frmVersiyonDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 324);
            this.Controls.Add(this.pnlAyrintilar);
            this.Name = "frmVersiyonDuzenle";
            this.Text = "frmVersiyon";
            this.Load += new System.EventHandler(this.frmVersiyonDuzenle_Load);
            this.pnlAyrintilar.ResumeLayout(false);
            this.pnlAyrintilar.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPaketSayisi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAyrintilar;
        private System.Windows.Forms.CheckBox cbxZorunlu;
        private System.Windows.Forms.TextBox txtGuncelemeNotu;
        private System.Windows.Forms.NumericUpDown numericPaketSayisi;
        private System.Windows.Forms.TextBox txtVersiyon;
        private System.Windows.Forms.ComboBox cmbxNamespace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnPaketSec;
        private System.Windows.Forms.ProgressBar progressYukleme;
        private System.ComponentModel.BackgroundWorker bgwYukleyici;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblKayitDurum;
    }
}