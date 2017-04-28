namespace Sinema
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.tabPageCalisan = new System.Windows.Forms.TabPage();
            this.tabPageSeans = new System.Windows.Forms.TabPage();
            this.tabPageSalon = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPageFilm = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilmAd = new System.Windows.Forms.TextBox();
            this.txtYonetmen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKategori = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbAktif = new System.Windows.Forms.RadioButton();
            this.rdbAktifDegil = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnFilmEkle = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.dataGridViewFilm = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSalon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageFilm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilm)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageCalisan
            // 
            this.tabPageCalisan.Location = new System.Drawing.Point(4, 25);
            this.tabPageCalisan.Name = "tabPageCalisan";
            this.tabPageCalisan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalisan.Size = new System.Drawing.Size(1183, 652);
            this.tabPageCalisan.TabIndex = 3;
            this.tabPageCalisan.Text = "Çalışan İşlemleri";
            this.tabPageCalisan.UseVisualStyleBackColor = true;
            // 
            // tabPageSeans
            // 
            this.tabPageSeans.Location = new System.Drawing.Point(4, 25);
            this.tabPageSeans.Name = "tabPageSeans";
            this.tabPageSeans.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeans.Size = new System.Drawing.Size(1183, 652);
            this.tabPageSeans.TabIndex = 2;
            this.tabPageSeans.Text = "Seans İşlemleri";
            this.tabPageSeans.UseVisualStyleBackColor = true;
            // 
            // tabPageSalon
            // 
            this.tabPageSalon.Controls.Add(this.dataGridView1);
            this.tabPageSalon.Location = new System.Drawing.Point(4, 25);
            this.tabPageSalon.Name = "tabPageSalon";
            this.tabPageSalon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSalon.Size = new System.Drawing.Size(1183, 652);
            this.tabPageSalon.TabIndex = 1;
            this.tabPageSalon.Text = "Salon İşlemleri";
            this.tabPageSalon.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 332);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPageFilm
            // 
            this.tabPageFilm.Controls.Add(this.dataGridViewFilm);
            this.tabPageFilm.Controls.Add(this.groupBox1);
            this.tabPageFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPageFilm.Location = new System.Drawing.Point(4, 25);
            this.tabPageFilm.Name = "tabPageFilm";
            this.tabPageFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilm.Size = new System.Drawing.Size(1183, 652);
            this.tabPageFilm.TabIndex = 0;
            this.tabPageFilm.Text = "Film İşlemleri";
            this.tabPageFilm.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.btnFilmEkle);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.rdbAktifDegil);
            this.groupBox1.Controls.Add(this.rdbAktif);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtKategori);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtYonetmen);
            this.groupBox1.Controls.Add(this.txtFilmAd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 260);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Film Ekleme,Güncelleme";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Film Ad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yönetmen :";
            // 
            // txtFilmAd
            // 
            this.txtFilmAd.Location = new System.Drawing.Point(93, 45);
            this.txtFilmAd.Name = "txtFilmAd";
            this.txtFilmAd.Size = new System.Drawing.Size(255, 27);
            this.txtFilmAd.TabIndex = 0;
            // 
            // txtYonetmen
            // 
            this.txtYonetmen.Location = new System.Drawing.Point(93, 141);
            this.txtYonetmen.Name = "txtYonetmen";
            this.txtYonetmen.Size = new System.Drawing.Size(255, 27);
            this.txtYonetmen.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(15, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kategori :";
            // 
            // txtKategori
            // 
            this.txtKategori.Location = new System.Drawing.Point(93, 92);
            this.txtKategori.Name = "txtKategori";
            this.txtKategori.Size = new System.Drawing.Size(255, 27);
            this.txtKategori.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(430, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Süre :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(411, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Yayın Tarih:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(498, 45);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(255, 27);
            this.textBox7.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(420, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Aktif :";
            // 
            // rdbAktif
            // 
            this.rdbAktif.AutoSize = true;
            this.rdbAktif.Location = new System.Drawing.Point(498, 88);
            this.rdbAktif.Name = "rdbAktif";
            this.rdbAktif.Size = new System.Drawing.Size(57, 23);
            this.rdbAktif.TabIndex = 4;
            this.rdbAktif.TabStop = true;
            this.rdbAktif.Text = "Aktif";
            this.rdbAktif.UseVisualStyleBackColor = true;
            // 
            // rdbAktifDegil
            // 
            this.rdbAktifDegil.AutoSize = true;
            this.rdbAktifDegil.Location = new System.Drawing.Point(658, 88);
            this.rdbAktifDegil.Name = "rdbAktifDegil";
            this.rdbAktifDegil.Size = new System.Drawing.Size(95, 23);
            this.rdbAktifDegil.TabIndex = 5;
            this.rdbAktifDegil.TabStop = true;
            this.rdbAktifDegil.Text = "Aktif Değil";
            this.rdbAktifDegil.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(500, 135);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(253, 27);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // btnFilmEkle
            // 
            this.btnFilmEkle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFilmEkle.Location = new System.Drawing.Point(500, 188);
            this.btnFilmEkle.Name = "btnFilmEkle";
            this.btnFilmEkle.Size = new System.Drawing.Size(105, 42);
            this.btnFilmEkle.TabIndex = 7;
            this.btnFilmEkle.Text = "Film Ekle";
            this.btnFilmEkle.UseVisualStyleBackColor = true;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(648, 188);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(105, 42);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFilm
            // 
            this.dataGridViewFilm.AllowUserToAddRows = false;
            this.dataGridViewFilm.AllowUserToDeleteRows = false;
            this.dataGridViewFilm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFilm.Location = new System.Drawing.Point(17, 306);
            this.dataGridViewFilm.MultiSelect = false;
            this.dataGridViewFilm.Name = "dataGridViewFilm";
            this.dataGridViewFilm.ReadOnly = true;
            this.dataGridViewFilm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFilm.Size = new System.Drawing.Size(819, 340);
            this.dataGridViewFilm.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFilm);
            this.tabControl1.Controls.Add(this.tabPageSalon);
            this.tabControl1.Controls.Add(this.tabPageSeans);
            this.tabControl1.Controls.Add(this.tabPageCalisan);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1191, 681);
            this.tabControl1.TabIndex = 0;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 705);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.Text = "Admin Paneli";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.tabPageSalon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageFilm.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFilm)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageCalisan;
        private System.Windows.Forms.TabPage tabPageSeans;
        private System.Windows.Forms.TabPage tabPageSalon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPageFilm;
        private System.Windows.Forms.DataGridView dataGridViewFilm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnFilmEkle;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rdbAktifDegil;
        private System.Windows.Forms.RadioButton rdbAktif;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtKategori;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYonetmen;
        private System.Windows.Forms.TextBox txtFilmAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}