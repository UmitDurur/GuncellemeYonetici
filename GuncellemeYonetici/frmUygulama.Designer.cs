namespace GuncellemeYonetici
{
    partial class frmUygulama
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
            this.lblUygID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblUygulamaNamespace = new System.Windows.Forms.Label();
            this.lblUygulamaAdi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUygID
            // 
            this.lblUygID.AutoSize = true;
            this.lblUygID.Location = new System.Drawing.Point(90, 9);
            this.lblUygID.Name = "lblUygID";
            this.lblUygID.Size = new System.Drawing.Size(68, 13);
            this.lblUygID.TabIndex = 13;
            this.lblUygID.Text = "Uygulama ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Uygulama ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Namespace";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Uygulama adı";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(12, 62);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(190, 23);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            // 
            // lblUygulamaNamespace
            // 
            this.lblUygulamaNamespace.AutoSize = true;
            this.lblUygulamaNamespace.Location = new System.Drawing.Point(90, 35);
            this.lblUygulamaNamespace.Name = "lblUygulamaNamespace";
            this.lblUygulamaNamespace.Size = new System.Drawing.Size(64, 13);
            this.lblUygulamaNamespace.TabIndex = 15;
            this.lblUygulamaNamespace.Text = "Namespace";
            // 
            // lblUygulamaAdi
            // 
            this.lblUygulamaAdi.AutoSize = true;
            this.lblUygulamaAdi.Location = new System.Drawing.Point(90, 22);
            this.lblUygulamaAdi.Name = "lblUygulamaAdi";
            this.lblUygulamaAdi.Size = new System.Drawing.Size(71, 13);
            this.lblUygulamaAdi.TabIndex = 14;
            this.lblUygulamaAdi.Text = "Uygulama adı";
            // 
            // frmUygulama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 127);
            this.Controls.Add(this.lblUygulamaNamespace);
            this.Controls.Add(this.lblUygulamaAdi);
            this.Controls.Add(this.lblUygID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKaydet);
            this.Name = "frmUygulama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmUygulama";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUygID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label lblUygulamaNamespace;
        private System.Windows.Forms.Label lblUygulamaAdi;
    }
}