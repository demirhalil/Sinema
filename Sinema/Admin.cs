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
using EntityLayer;
using FacadeLayer;

namespace Sinema
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            lblUyariFilm.Visible = false;
            lblUyariSalon.Visible = false;
            lblUyariSeans.Visible = false;
            lblUyariCalisan.Visible = false;
            if (tabControl1.SelectedIndex == 0)
            {
                filmCek();
            }
        }
      
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriCek();
        }

        //Verilerin çekildiği metotlar.
        private void verileriCek()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                filmCek();
            }

            else  if (tabControl1.SelectedIndex == 1)
            {
                salonCek();
            }

            else if (tabControl1.SelectedIndex == 2)
            {
                seansCek();
            }

            else
            {
                calisanCek();
            }
        }

        private void filmCek()
        {
            DataTable dt = new DataTable();
            dt = BLLADMIN.getDataTableFilm();
            dt.Columns["FilmAd"].ColumnName = "Film Ad";
            dt.Columns["Yonetmen"].ColumnName = "Yönetmen";
            dt.Columns["Sure"].ColumnName = "Filmin Süresi";
            dt.Columns["YayinTarih"].ColumnName = "Yayın Tarihi";
            dt.Columns["Kategori"].ColumnName = "Filmin Kategorisi";
            dt.Columns["Aktif"].ColumnName = "Aktif";

            dataGridViewFilm.DataSource = dt;
            dataGridViewFilm.Columns["FilmID"].Visible = false;
            dataGridViewFilm.Columns["Film Ad"].Width = 150;
            dataGridViewFilm.Columns["Yönetmen"].Width = 150;
            dataGridViewFilm.Columns["Filmin Süresi"].Width = 125;
            dataGridViewFilm.Columns["Yayın Tarihi"].Width = 125;
            dataGridViewFilm.Columns["Aktif"].Width = 50;
            dataGridViewFilm.Columns["Filmin Kategorisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            satirRenklendir(dataGridViewFilm);
        }

        private void salonCek()
        {
            DataTable dt = new DataTable();
            dt = BLLADMIN.getDataTableSalon();
            dt.Columns["SalonAd"].ColumnName = "Salon Adı";
            dt.Columns["Kapasite"].ColumnName = "Salon Kapasitesi";

            dataGridViewSalon.DataSource = dt;
            dataGridViewSalon.Columns["SalonID"].Visible = false;
            dataGridViewSalon.Columns["Salon Adı"].Width = 400;
            dataGridViewSalon.Columns["Salon Kapasitesi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            satirRenklendir(dataGridViewSalon);
        }

        private void seansCek()
        {
            DataTable dt = new DataTable();
            dt = BLLADMIN.getDataTableSeans();
            dt.Columns["SeansID"].ColumnName = "Seans Numarası";
            dt.Columns["SeansSaat"].ColumnName = "Seans Saati";

            dataGridViewSeans.DataSource = dt;
            dataGridViewSeans.Columns["Seans Numarası"].Width = 400;
            dataGridViewSeans.Columns["Seans Saati"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            satirRenklendir(dataGridViewSeans);
        }

        private void calisanCek()
        {
            DataTable dt = new DataTable();
            dt = BLLADMIN.getDataTableCalisan();
            dt.Columns["Ad"].ColumnName = "Ad";
            dt.Columns["Soyad"].ColumnName = "Soyad";
            dt.Columns["KullaniciAd"].ColumnName = "Kullanıcı Ad";
            dt.Columns["KullaniciParola"].ColumnName = "Kullanıcı Parolası";
            dt.Columns["DogumTarih"].ColumnName = "Doğum Tarihi";
            dt.Columns["IseGirisTarih"].ColumnName = "İşe Giriş Tarihi";
            dt.Columns["TCNO"].ColumnName = "TC Kimlik Numarası";
            dt.Columns["AdminYetki"].ColumnName = "Admin Yetkisi";

            dataGridViewCalisan.DataSource = dt;
            dataGridViewCalisan.Columns["CalisanID"].Visible = false;
            dataGridViewCalisan.Columns["Ad"].Width = 100;
            dataGridViewCalisan.Columns["Soyad"].Width = 100;
            dataGridViewCalisan.Columns["Kullanıcı Ad"].Width = 125;
            dataGridViewCalisan.Columns["Kullanıcı Parolası"].Width = 125;
            dataGridViewCalisan.Columns["Doğum Tarihi"].Width = 100;
            dataGridViewCalisan.Columns["İşe Giriş Tarihi"].Width = 100;
            dataGridViewCalisan.Columns["TC Kimlik Numarası"].Width = 100;
            dataGridViewCalisan.Columns["Admin Yetkisi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            satirRenklendir(dataGridViewCalisan);
        }

        //Film işlemlerinin yapıldığı kontroller.
        private void btnFilmEkle_Click(object sender, EventArgs e)
        {
            EFILM item = new EFILM();

            item.FilmAd = txtFilmAd.Text;
            item.Yonetmen = txtYonetmen.Text;
            item.Sure = Convert.ToInt32(txtSure.Text);
            item.Kategori = txtKategori.Text;
            item.YayinTarih = Convert.ToDateTime(dateTimeYayinTarih.Text);
            if (rdbAktif.Checked)
            {
                item.Aktif = true;
            }
            else
                item.Aktif = false;

            if (BLLADMIN.Film_Insert(item) > 0)
            {
                filmCek();
                MessageBox.Show("Film ekleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                filmTemizle();
                lblUyariFilm.Visible = false;
            }

            else
            {
                filmCek();
                MessageBox.Show("Film ekleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariFilm.Visible = true;
                lblUyariFilm.ForeColor = Color.Red;
                filmTemizle();
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EFILM item = new EFILM();

            //Eski filmin bilgilerini aldık.
            item.FilmID = Convert.ToInt32(dataGridViewFilm.SelectedRows[0].Cells["FilmID"].Value.ToString());
            item.FilmAd = dataGridViewFilm.SelectedRows[0].Cells["Film Ad"].Value.ToString();
            item.Yonetmen = dataGridViewFilm.SelectedRows[0].Cells["Yönetmen"].Value.ToString();
            item.Sure = Convert.ToInt32(dataGridViewFilm.SelectedRows[0].Cells["Filmin Süresi"].Value.ToString());
            item.YayinTarih = Convert.ToDateTime(dataGridViewFilm.SelectedRows[0].Cells["Yayın Tarihi"].Value.ToString());
            item.Kategori = dataGridViewFilm.SelectedRows[0].Cells["Filmin Kategorisi"].Value.ToString();
            item.Aktif = Convert.ToBoolean(dataGridViewFilm.SelectedRows[0].Cells["Aktif"].Value.ToString());

            //Güncellenecek film bilgilerini burada alıyoruz.
            item.FilmAd = txtFilmAd.Text;
            item.Yonetmen = txtYonetmen.Text;
            item.Sure = Convert.ToInt32(txtSure.Text);
            item.Kategori = txtKategori.Text;
            item.YayinTarih = Convert.ToDateTime(dateTimeYayinTarih.Text);
            if (rdbAktif.Checked)
            {
                item.Aktif = true;
            }
            else
                item.Aktif = false;

            if (BLLADMIN.Film_Update(item))
            {
                filmCek();
                MessageBox.Show("Film güncelleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                filmTemizle();
                lblUyariFilm.Visible = false;
            }

            else
            {
                filmCek();
                MessageBox.Show("Film güncelleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariFilm.Visible = true;
                lblUyariFilm.ForeColor = Color.Red;
                filmTemizle();

            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EFILM item = new EFILM();

            item.FilmID = Convert.ToInt32(dataGridViewFilm.SelectedRows[0].Cells["FilmID"].Value.ToString());

            if (BLLADMIN.Film_Delete(item.FilmID))
            {
                filmCek();
                MessageBox.Show("Film silme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                filmTemizle();
            }


            else
            {
                filmCek();
                MessageBox.Show("Film silme işlemi gerçekleştirilemedi.Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filmTemizle();

            }

        }

        private void dataGridViewFilm_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtFilmAd.Text = dataGridViewFilm.SelectedRows[0].Cells["Film Ad"].Value.ToString();
            txtYonetmen.Text = dataGridViewFilm.SelectedRows[0].Cells["Yönetmen"].Value.ToString();
            txtSure.Text = dataGridViewFilm.SelectedRows[0].Cells["Filmin Süresi"].Value.ToString();
            txtKategori.Text = dataGridViewFilm.SelectedRows[0].Cells["Filmin Kategorisi"].Value.ToString();
            dateTimeYayinTarih.Text = dataGridViewFilm.SelectedRows[0].Cells["Yayın Tarihi"].Value.ToString();
            if (dataGridViewFilm.SelectedRows[0].Cells["Aktif"].Value.ToString() == "True")
            {
                rdbAktif.Select();
            }
            else
            {
                rdbAktifDegil.Select();
            }
        }

        private void filmTemizle()
        {
            txtFilmAd.Clear();
            txtYonetmen.Clear();
            txtKategori.Clear();
            txtSure.Clear();
            dateTimeYayinTarih.Text = DateTime.Now.ToString();
            if (rdbAktif.Checked)
            {
                rdbAktif.Checked = false;
            }

            rdbAktifDegil.Checked = false;
        }

        //Salon işlemlerinin yapıldığı kontroller.
        private void btnSalonEkle_Click(object sender, EventArgs e)
        {
            ESALON item = new ESALON();

            item.SalonAd = txtSalonAd.Text;
            item.Kapasite = Convert.ToInt32(txtSalonKapasite.Text);

            if (BLLADMIN.Salon_Insert(item) > 0)
            {
                salonCek();
                MessageBox.Show("Salon ekleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                salonTemizle();
                lblUyariSalon.Visible = false;
            }

            else
            {
                salonCek();
                MessageBox.Show("Salon ekleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariSalon.Visible = true;
                lblUyariSalon.ForeColor = Color.Red;
                salonTemizle();
            }
        }

        private void btnSalonGuncelle_Click(object sender, EventArgs e)
        {
            ESALON item = new ESALON();

            //Eski salon bilgilerini aldık.
            item.SalonID = Convert.ToInt32(dataGridViewSalon.SelectedRows[0].Cells["SalonID"].Value.ToString());
            item.SalonAd = dataGridViewSalon.SelectedRows[0].Cells["Salon Adı"].Value.ToString();
            item.Kapasite = Convert.ToInt32(dataGridViewSalon.SelectedRows[0].Cells["Salon Kapasitesi"].Value.ToString());

            //Güncellenecek salon bilgilerini burada alıyoruz.
            item.SalonAd = txtSalonAd.Text;
            item.Kapasite = Convert.ToInt32(txtSalonKapasite.Text);
           

            if (BLLADMIN.Salon_Update(item))
            {
                salonCek();
                MessageBox.Show("Salon güncelleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                salonTemizle();
                lblUyariSalon.Visible = false;
            }

            else
            {
                salonCek();
                MessageBox.Show("Salon güncelleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariSalon.Visible = true;
                lblUyariSalon.ForeColor = Color.Red;
                salonTemizle();

            }
        }

        private void dataGridViewSalon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSalonAd.Text = dataGridViewSalon.SelectedRows[0].Cells["Salon Adı"].Value.ToString();
            txtSalonKapasite.Text = dataGridViewSalon.SelectedRows[0].Cells["Salon Kapasitesi"].Value.ToString();
        }

        private void salonTemizle()
        {
            txtSalonAd.Clear();
            txtSalonKapasite.Clear();
        }

        private void btnSalonSil_Click(object sender, EventArgs e)
        {
            ESALON item = new ESALON();

            item.SalonID = Convert.ToInt32(dataGridViewSalon.SelectedRows[0].Cells["SalonID"].Value.ToString());

            if (BLLADMIN.Salon_Delete(item.SalonID))
            {
                salonCek();
                MessageBox.Show("Salon silme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                salonTemizle();
            }


            else
            {
                salonCek();
                MessageBox.Show("Salon silme işlemi gerçekleştirilemedi.Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                salonTemizle();

            }
        }

        //Seans işlemlerinin yapıldığı kontroller.
        private void seansTemizle()
        {
            txtSeansSaati.Clear();
        }

        private void dataGridViewSeans_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtSeansSaati.Text = dataGridViewSeans.SelectedRows[0].Cells["Seans Saati"].Value.ToString();
        }

        private void btnSeansEkle_Click(object sender, EventArgs e)
        {
            ESEANS item = new ESEANS();

            item.SeansSaat = txtSeansSaati.Text;

            if (BLLADMIN.Seans_Insert(item) > 0)
            {
                seansCek();
                MessageBox.Show("Seans ekleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                seansTemizle();
                lblUyariSeans.Visible = false;
            }

            else
            {
                seansCek();
                MessageBox.Show("Seans ekleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariSeans.Visible = true;
                lblUyariSeans.ForeColor = Color.Red;
                seansTemizle();
            }
        }

        private void btnSeansGuncelle_Click(object sender, EventArgs e)
        {
            ESEANS item = new ESEANS();

            //Eski seans bilgilerini aldık.
            item.SeansID = Convert.ToInt32(dataGridViewSeans.SelectedRows[0].Cells["Seans Numarası"].Value.ToString());
            item.SeansSaat = dataGridViewSeans.SelectedRows[0].Cells["Seans Saati"].Value.ToString();

            //Güncellenecek seans bilgilerini burada alıyoruz.
            item.SeansSaat = txtSeansSaati.Text;

            if (BLLADMIN.Seans_Update(item))
            {
                seansCek();
                MessageBox.Show("Seans güncelleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                seansTemizle();
                lblUyariSeans.Visible = false;
            }

            else
            {
                seansCek();
                MessageBox.Show("Seans güncelleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariSeans.Visible = true;
                lblUyariSeans.ForeColor = Color.Red;
                seansTemizle();

            }
        }

        private void btnSeansSil_Click(object sender, EventArgs e)
        {
            ESEANS item = new ESEANS();

            item.SeansID = Convert.ToInt32(dataGridViewSeans.SelectedRows[0].Cells["Seans Numarası"].Value.ToString());

            if (BLLADMIN.Seans_Delete(item.SeansID))
            {
                seansCek();
                MessageBox.Show("Seans silme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                seansTemizle();
            }


            else
            {
                seansCek();
                MessageBox.Show("Seans silme işlemi gerçekleştirilemedi.Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                seansTemizle();

            }
        }

        //Çalışan işlemlerinin yapıldığı knotroler.
        private void calisanTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtKullaniciAd.Clear();
            txtKullaniciParola.Clear();
            txtTC.Clear();
            dateTimeDogumTarih.Text = DateTime.Now.ToString();
            dateTimeIseGirisTarih.Text = DateTime.Now.ToString();
            if (rdbAdmin.Checked)
            {
                rdbAdmin.Checked = false;
            }

            rdbAdminDegil.Checked = false;
        }

        private void dataGridViewCalisan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtAd.Text = dataGridViewCalisan.SelectedRows[0].Cells["Ad"].Value.ToString();
            txtSoyad.Text = dataGridViewCalisan.SelectedRows[0].Cells["Soyad"].Value.ToString();
            txtKullaniciAd.Text = dataGridViewCalisan.SelectedRows[0].Cells["Kullanıcı Ad"].Value.ToString();
            txtKullaniciParola.Text = dataGridViewCalisan.SelectedRows[0].Cells["Kullanıcı Parolası"].Value.ToString();
            txtTC.Text = dataGridViewCalisan.SelectedRows[0].Cells["TC Kimlik Numarası"].Value.ToString();
            dateTimeDogumTarih.Text = dataGridViewCalisan.SelectedRows[0].Cells["Doğum Tarihi"].Value.ToString();
            dateTimeIseGirisTarih.Text = dataGridViewCalisan.SelectedRows[0].Cells["İşe Giriş Tarihi"].Value.ToString();
            if (dataGridViewCalisan.SelectedRows[0].Cells["Admin Yetkisi"].Value.ToString() == "True")
            {
                rdbAdmin.Select();
            }
            else
            {
                rdbAdminDegil.Select();
            }
        }

        private void btnCalisanEkle_Click(object sender, EventArgs e)
        {
            ECALISAN item = new ECALISAN();

            item.Ad = txtAd.Text;
            item.Soyad = txtSoyad.Text;
            item.KullaniciAd = txtKullaniciAd.Text;
            item.KullaniciParola = txtKullaniciParola.Text;
            item.TCNO = txtTC.Text;
            item.DogumTarih = Convert.ToDateTime(dateTimeDogumTarih.Text);
            item.IseGirisTarih = Convert.ToDateTime(dateTimeIseGirisTarih.Text);
            if (rdbAdmin.Checked)
            {
                item.AdminYetki = true;
            }
            else
                item.AdminYetki = false;

            if (BLLADMIN.Calisan_Insert(item) > 0)
            {
                calisanCek();
                MessageBox.Show("Çalışan ekleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                calisanTemizle();
                lblUyariCalisan.Visible = false;
            }

            else
            {
                calisanCek();
                MessageBox.Show("Çalışan ekleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariCalisan.Visible = true;
                lblUyariCalisan.ForeColor = Color.Red;
                calisanTemizle();
            }
        }

        private void btnCalisanGuncelle_Click(object sender, EventArgs e)
        {
            ECALISAN item = new ECALISAN();

            //Eski çalışan bilgilerini aldık.
            item.CalisanID = Convert.ToInt32(dataGridViewCalisan.SelectedRows[0].Cells["CalisanID"].Value.ToString());
            item.Ad = dataGridViewCalisan.SelectedRows[0].Cells["Ad"].Value.ToString();
            item.Soyad = dataGridViewCalisan.SelectedRows[0].Cells["Soyad"].Value.ToString();
            item.KullaniciAd = dataGridViewCalisan.SelectedRows[0].Cells["Kullanıcı Ad"].Value.ToString();
            item.KullaniciParola = dataGridViewCalisan.SelectedRows[0].Cells["Kullanıcı Parolası"].Value.ToString();
            item.TCNO = dataGridViewCalisan.SelectedRows[0].Cells["TC Kimlik Numarası"].Value.ToString();
            item.DogumTarih = Convert.ToDateTime(dataGridViewCalisan.SelectedRows[0].Cells["Doğum Tarihi"].Value.ToString());
            item.IseGirisTarih = Convert.ToDateTime(dataGridViewCalisan.SelectedRows[0].Cells["İşe Giriş Tarihi"].Value.ToString());
            item.AdminYetki = Convert.ToBoolean(dataGridViewCalisan.SelectedRows[0].Cells["Admin Yetkisi"].Value.ToString());

            //Güncellenen film bilgilerini alıyoruz.
            item.Ad = txtAd.Text;
            item.Soyad = txtSoyad.Text;
            item.KullaniciAd = txtKullaniciAd.Text;
            item.KullaniciParola = txtKullaniciParola.Text;
            item.TCNO = txtTC.Text;
            item.DogumTarih = Convert.ToDateTime(dateTimeDogumTarih.Text);
            item.IseGirisTarih = Convert.ToDateTime(dateTimeIseGirisTarih.Text);
            if (rdbAdmin.Checked)
            {
                item.AdminYetki = true;
            }
            else
                item.AdminYetki = false;

            if (BLLADMIN.Calisan_Update(item))
            {
                calisanCek();
                MessageBox.Show("Çalışan güncelleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                calisanTemizle();
                lblUyariCalisan.Visible = false;
            }

            else
            {
                calisanCek();
                MessageBox.Show("Çalışan güncelleme işlemi eksik bilgiler yada başka nedenlerden dolayı gerçekleştirilemedi.Tüm boş alanları doldurup tekrar deneyin. Sorunun devam etmesi halinde lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblUyariCalisan.Visible = true;
                lblUyariCalisan.ForeColor = Color.Red;
                calisanTemizle();
            }
        }

        private void btnCalisanSil_Click(object sender, EventArgs e)
        {
            ECALISAN item = new ECALISAN();

            item.CalisanID = Convert.ToInt32(dataGridViewCalisan.SelectedRows[0].Cells["CalisanID"].Value.ToString());

            if (BLLADMIN.Calisan_Delete(item.CalisanID))
            {
                calisanCek();
                MessageBox.Show("Çalışan silme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                calisanTemizle();
            }


            else
            {
                calisanCek();
                MessageBox.Show("Çalışan silme işlemi gerçekleştirilemedi.Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                calisanTemizle();

            }
        }

        //DataGridViewler de her satırın farklı renkte olmasını sağlayan metot.
        private void satirRenklendir(DataGridView dt)
        {

            int satirSayisi = dt.Rows.Count;

            for (int i = 0; i < satirSayisi; i++)
            {
                if (i % 2 == 0)
                {
                    continue;
                }

                else
                {
                    dt.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }
            }

        }
    }
}
