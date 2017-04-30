using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Collections;
using EntityLayer;
using System.Data.Sql;
using System.Data.SqlClient;
using FacadeLayer;

namespace Sinema
{
    public partial class Biletci : Form
    {
        public Biletci()
        {
            InitializeComponent();
        }

        ArrayList koltuklar = new ArrayList();
        ArrayList iptalKoltuk = new ArrayList();

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                biletCek();
                iptalFilmCek();
                iptalSalonCek();
                iptalSeansCek();
            }

            else
            {
                doluKoltuklariCek();
            }
        }

        //Veritabanından Bilet,Film,Salon,Seans,Dolu koltukların verileri çekildi.
        private void biletCek()
        {
            DataTable dt = new DataTable();
            dt = BLLBILETCI.getDataTableBilet();
            dt.Columns["FilmID"].ColumnName = "Filmin Numarası";
            dt.Columns["SalonID"].ColumnName = "Salonun Numarası";
            dt.Columns["SeansID"].ColumnName = "Seans Numarası";
            dt.Columns["MusteriAd"].ColumnName = "Müşteri Ad";
            dt.Columns["MusteriSoyad"].ColumnName = "Müşteri Soyad";
            dt.Columns["Koltuk"].ColumnName = "Koltuk Numaraları";
            dt.Columns["BiletAdet"].ColumnName = "Bilet Adedi";
            dt.Columns["Ucret"].ColumnName = "Ücret";

            dataGridViewBilet.DataSource = dt;
            dataGridViewBilet.Columns["BiletID"].Visible = false;
            dataGridViewBilet.Columns["Filmin Numarası"].Width = 100;
            dataGridViewBilet.Columns["Salonun Numarası"].Width = 100;
            dataGridViewBilet.Columns["Seans Numarası"].Width = 100;
            dataGridViewBilet.Columns["Müşteri Ad"].Width = 100;
            dataGridViewBilet.Columns["Müşteri Soyad"].Width = 100;
            dataGridViewBilet.Columns["Koltuk Numaraları"].Width = 150;
            dataGridViewBilet.Columns["Bilet Adedi"].Width = 100;
            dataGridViewBilet.Columns["Ücret"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void salonCek()
        {
            DataTable dtSalon = new DataTable();
            dtSalon = BLLADMIN.getDataTableSalon();

            cmbSalon.DataSource = dtSalon;
            cmbSalon.DisplayMember = dtSalon.Columns["SalonAd"].ToString();
            cmbSalon.ValueMember = dtSalon.Columns["SalonID"].ToString();
        }

        private void seansCek()
        {
            DataTable dtSeans = new DataTable();
            dtSeans = BLLADMIN.getDataTableSeans();

            cmbSeans.DataSource = dtSeans;
            cmbSeans.DisplayMember = dtSeans.Columns["SeansSaat"].ToString();
            cmbSeans.ValueMember = dtSeans.Columns["SeansID"].ToString();
        }

        private void filmCek()
        {
            DataTable dtFilm = new DataTable();
            dtFilm = BLLADMIN.getDataTableFilm();


            cmbFilm.DataSource = dtFilm;
            cmbFilm.DisplayMember = dtFilm.Columns["FilmAd"].ToString();
            cmbFilm.ValueMember = dtFilm.Columns["FilmID"].ToString();
        }

        private void biletTemizle()
        {
            cmbIptalFilm.SelectedIndex = 0;
            cmbIptalSalon.SelectedIndex = 0;
            cmbIptalSeans.SelectedIndex = 0;
            txtIptalAd.Clear();
            txtIptalSoyad.Clear();
            txtIptalKoltuk.Clear();
            numericUpDownIptalBiletAdet.Value = 0;
        }

        private void doluKoltuklariCek()
        {
            List<EBILET> itemlist = BLLBILETCI.Bilet_SelectList();

            string koltuk = "";
            foreach (EBILET item in itemlist)
            {
                koltuk += item.Koltuk;
                koltuk += ",";
            }
            string[] values = koltuk.Split(',');

            for (int i = 0; i < values.Length - 1; i++)
            {
                this.Controls.Find("btn" + values[i], true)[0].BackColor = Color.Red;
            }
        }

        private void Biletci_Load(object sender, EventArgs e)
        {
            filmCek();
            salonCek();
            seansCek();
            iptalFilmCek();
            iptalSalonCek();
            iptalSeansCek();
            lblFiyat.Visible = false;
            doluKoltuklariCek();
            lblUyari.Visible = false;
            lblUyariGuncelleme.Visible = false;
        }

        //İptal işlemleri için veriler çekiliyor.
        private void iptalSalonCek()
        {
            DataTable dtSalon = new DataTable();
            dtSalon = BLLADMIN.getDataTableSalon();

            cmbIptalSalon.DataSource = dtSalon;
            cmbIptalSalon.DisplayMember = dtSalon.Columns["SalonAd"].ToString();
            cmbIptalSalon.ValueMember = dtSalon.Columns["SalonID"].ToString();
        }

        private void iptalSeansCek()
        {
            DataTable dt = new DataTable();
            dt = BLLADMIN.getDataTableSeans();

            cmbIptalSeans.DataSource = dt;
            cmbIptalSeans.DisplayMember = dt.Columns["SeansSaat"].ToString();
            cmbIptalSeans.ValueMember = dt.Columns["SeansID"].ToString();
        }

        private void iptalFilmCek()
        {
            DataTable dtFilm = new DataTable();
            dtFilm = BLLADMIN.getDataTableFilm();


            cmbIptalFilm.DataSource = dtFilm;
            cmbIptalFilm.DisplayMember = dtFilm.Columns["FilmAd"].ToString();
            cmbIptalFilm.ValueMember = dtFilm.Columns["FilmID"].ToString();
        }

        private void dataGridViewBilet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbIptalFilm.SelectedValue = dataGridViewBilet.SelectedRows[0].Cells["Filmin Numarası"].Value.ToString();
            cmbIptalSalon.SelectedValue = dataGridViewBilet.SelectedRows[0].Cells["Salonun Numarası"].Value.ToString();
            cmbIptalSeans.SelectedValue = dataGridViewBilet.SelectedRows[0].Cells["Seans Numarası"].Value.ToString();
            txtIptalAd.Text = dataGridViewBilet.SelectedRows[0].Cells["Müşteri Ad"].Value.ToString();
            txtIptalSoyad.Text = dataGridViewBilet.SelectedRows[0].Cells["Müşteri Soyad"].Value.ToString();
            txtIptalKoltuk.Text = dataGridViewBilet.SelectedRows[0].Cells["Koltuk Numaraları"].Value.ToString();
            numericUpDownIptalBiletAdet.Value = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["Bilet Adedi"].Value.ToString());
        }

        //Koltuk seçimi yaparken koltukların rengini değiştiren kodlar.
        private void btnKoltuk_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Chartreuse) // yeşil

            {

                ((Button)sender).BackColor = Color.Orange;

                if (!koltuklar.Contains(((Button)sender).Text))

                {

                    koltuklar.Add(((Button)sender).Text);                
                }

                koltukYazdir();
                
            }

            else if (((Button)sender).BackColor == Color.Orange) // turuncu

            {

                ((Button)sender).BackColor = Color.Chartreuse;

                if (koltuklar.Contains(((Button)sender).Text))

                {

                    koltuklar.Remove(((Button)sender).Text);

                }

                koltukYazdir();

            }

            else // kırmızı

            {

                if (!iptalKoltuk.Contains(((Button)sender).Text))

                {

                    iptalKoltuk.Add(((Button)sender).Text);

                }

                else //www.gorselprogramlama.com

                {

                    iptalKoltuk.Remove(((Button)sender).Text);

                }

                string koltuk = "";

                for (int i = 0; i < iptalKoltuk.Count; i++)

                {

                    koltuk += iptalKoltuk[i].ToString() + ",";

                }

                if (iptalKoltuk.Count >= 1)

                {

                    koltuk = koltuk.Remove(koltuk.Length - 1, 1);

                }

                txtIptalKoltuk.Text = koltuk;

            }
        }

        private void koltukYazdir()

        {
            
            string koltuk = "";

            for (int i = 0; i < koltuklar.Count; i++)

            {

                koltuk += koltuklar[i].ToString() + ",";

            }

            if (koltuklar.Count >= 1)

            {

                koltuk = koltuk.Remove(koltuk.Length - 1, 1);

            }

            txtKoltuk.Text = koltuk;

        }

        private void biletAyir()

        {
            decimal ucret;

            if (rbOgrenci.Checked) ucret = 6;

            else ucret = 10;

            EBILET item = new EBILET();

            for (int i = 0; i < koltuklar.Count; i++)

            {
                item.FilmID = Convert.ToInt32(cmbFilm.SelectedValue);
                item.SalonID = Convert.ToInt32(cmbSalon.SelectedValue);
                item.SeansID = Convert.ToInt32(cmbSeans.SelectedValue);
                item.MusteriAd = txtAd.Text;
                item.MusteriSoyad = txtSoyad.Text;
                item.Koltuk = txtKoltuk.Text;
                item.BiletAdet = Convert.ToInt32(numericBiletAdet.Value);
                item.Ucret = Convert.ToDecimal(koltuklar.Count * ucret);

                this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Red;
            }


            if (BLLBILETCI.Bilet_Insert(item) < 0)
            {
                MessageBox.Show("Bilet alma işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyari.Visible = true;
                lblUyari.ForeColor = Color.Red;
                for (int i = 0; i < koltuklar.Count; i++)

                {
                    this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Chartreuse;
                }

            }
            else
            {
                lblFiyat.Visible = true;
                MessageBox.Show("Seçilen biletler başarılı bir şekilde kesilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAd.Clear();
                txtSoyad.Clear();
                txtKoltuk.Clear();
                koltuklar.Clear();
                numericBiletAdet.Value = 0;
            }

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EBILET item = new EBILET();

            item.BiletID = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["BiletID"].Value.ToString());

            if (BLLBILETCI.Bilet_Delete(item.BiletID))
            {
                iptalEt();
                biletCek();
                MessageBox.Show("Bilet silme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                biletTemizle();                         
            }
            else
            {
                biletCek();
                MessageBox.Show("Bilet silme işlemi gerçekleştirilemedi.Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                biletTemizle();

            }
        }

        private void btnBiletKes_Click(object sender, EventArgs e)
        {
            biletAyir();
            doluKoltuklariCek();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EBILET item = new EBILET();

            item.BiletID = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["BiletID"].Value.ToString());
            item.FilmID = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["Filmin Numarası"].Value.ToString());
            item.SalonID = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["Salonun Numarası"].Value.ToString());
            item.SeansID = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["Seans Numarası"].Value.ToString());
            item.MusteriAd = dataGridViewBilet.SelectedRows[0].Cells["Müşteri Ad"].Value.ToString();
            item.MusteriSoyad = dataGridViewBilet.SelectedRows[0].Cells["Müşteri Soyad"].Value.ToString();
            item.Koltuk = dataGridViewBilet.SelectedRows[0].Cells["Koltuk Numaraları"].Value.ToString();
            item.BiletAdet = Convert.ToInt32(dataGridViewBilet.SelectedRows[0].Cells["Bilet Adedi"].Value.ToString());
            item.Ucret = Convert.ToDecimal(dataGridViewBilet.SelectedRows[0].Cells["Ücret"].Value.ToString());

            decimal ucret;

            if (rbOgrenci.Checked) ucret = 6;

            else ucret = 10;

            item.FilmID = Convert.ToInt32(cmbIptalFilm.SelectedValue);
            item.SalonID = Convert.ToInt32(cmbIptalSalon.SelectedValue);
            item.SeansID = Convert.ToInt32(cmbIptalSeans.SelectedValue);
            item.MusteriAd = txtIptalAd.Text;
            item.MusteriSoyad = txtIptalSoyad.Text;
            item.Koltuk = txtIptalKoltuk.Text;
            item.BiletAdet = Convert.ToInt32(numericUpDownIptalBiletAdet.Value);
            item.Ucret = Convert.ToDecimal(numericUpDownIptalBiletAdet.Value * ucret);

            if (BLLBILETCI.Bilet_Update(item))
            {
                doluKoltuklariCek();
                MessageBox.Show("Seçilen biletler başarılı bir şekilde güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                biletTemizle();
                Application.Restart();

            }
            else
            {
                MessageBox.Show("Bilet güncelleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariGuncelleme.Visible = true;
                lblUyariGuncelleme.ForeColor = Color.Red;

            }
        }

        //İptal edilen koltukların rengini değiştirmek için.
        private void iptalEt()
        {
            string[] values = txtIptalKoltuk.Text.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                this.Controls.Find("btn" + values[i], true)[0].BackColor = Color.Chartreuse;
            }
        }

        
    }
}

