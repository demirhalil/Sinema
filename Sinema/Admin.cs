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
            if (tabControl1.SelectedIndex == 0)
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
                dataGridViewFilm.Columns["Filmin Kategorisi"].Width = 125;
                dataGridViewFilm.Columns["Aktif"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
        }
      
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verileriCek();
        }

        private void verileriCek()
        {
            if (tabControl1.SelectedIndex == 0)
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
                dataGridViewFilm.Columns["Aktif"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

          else  if (tabControl1.SelectedIndex == 1)
            {
                DataTable dt = new DataTable();
                dt = BLLADMIN.getDataTableSalon();
                dt.Columns["SalonAd"].ColumnName = "Salon Ad";
                dt.Columns["Kapasite"].ColumnName = "Kapasite";



            }
        }

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
                MessageBox.Show("Film ekleme işlemi gerçekleştirilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Film ekleme işlemi gerçekleştirilemedi. Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
