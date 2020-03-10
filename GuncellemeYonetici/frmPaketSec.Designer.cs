namespace GuncellemeYonetici
{
    partial class frmPaketSec
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.pnlKonumlar = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnKaydet.Location = new System.Drawing.Point(0, 191);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(264, 27);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // pnlKonumlar
            // 
            this.pnlKonumlar.AutoScroll = true;
            this.pnlKonumlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKonumlar.Location = new System.Drawing.Point(0, 0);
            this.pnlKonumlar.Name = "pnlKonumlar";
            this.pnlKonumlar.Size = new System.Drawing.Size(264, 185);
            this.pnlKonumlar.TabIndex = 1;
            // 
            // frmPaketSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 218);
            this.Controls.Add(this.pnlKonumlar);
            this.Controls.Add(this.btnKaydet);
            this.Name = "frmPaketSec";
            this.Text = "frmPaketSec";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Panel pnlKonumlar;
    }
}