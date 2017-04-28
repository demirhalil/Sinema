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
using System.Data;
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

        private void Biletci_Load(object sender, EventArgs e)
        {
            DataTable dtFilm = new DataTable();
            DataTable dtSalon = new DataTable();
            DataTable dtSeans = new DataTable();

            dtFilm = BLLADMIN.getDataTableFilm();
            dtSalon = BLLADMIN.getDataTableSalon();
            dtSeans = BLLADMIN.getDataTableSeans();

            cmbFilm.DataSource = dtFilm;
            cmbFilm.DisplayMember = dtFilm.Columns["FilmAd"].ToString();
            cmbFilm.ValueMember = dtFilm.Columns["FilmID"].ToString();

            cmbSalon.DataSource = dtSalon;
            cmbSalon.DisplayMember = dtSalon.Columns["SalonAd"].ToString();
            cmbSalon.ValueMember = dtSalon.Columns["SalonID"].ToString();

            cmbSeans.DataSource = dtSeans;
            cmbSeans.DisplayMember = dtSeans.Columns["SeansSaat"].ToString();
            cmbSeans.ValueMember = dtSeans.Columns["SeansID"].ToString();

            lblFiyat.Visible = false;
        }

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

                txtiptalKoltuk.Text = koltuk;

            }
        }

       private void koltukYazdir()

        {

            string koltuk = "";

            for (int i = 0; i < koltuklar.Count; i++)

            {

                koltuk += koltuklar[i].ToString() + ",";//www.gorselprogramlama.com

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

            BLLBILETCI.Bilet_Insert(item);

            if (BLLBILETCI.Bilet_Insert(item) < 0)
            {
                MessageBox.Show("Bilet alma işlemi gerçekleştirilemedi. Lütfen yöneticinize danışın.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                for (int i = 0; i < koltuklar.Count; i++)

                {
                    this.Controls.Find("btn" + koltuklar[i].ToString(), true)[0].BackColor = Color.Chartreuse;
                }

            }
            else
            {

                MessageBox.Show("Seçilen biletler başarılı bir şekilde kesilmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAd.Clear();
                txtSoyad.Clear();
                txtKoltuk.Clear();
                numericBiletAdet.Value = 0;
            }

        }

        private void btnBiletKes_MouseClick(object sender, MouseEventArgs e)
        {
            biletAyir();         
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            EBILET item = new EBILET();
            //string koltuk;

                for (int i = 0; i < iptalKoltuk.Count; i++)

                {
                 //koltuk = iptalKoltuk[i].ToString() + ",";
                    //BLLBILETCI.Bilet_Delete(Convert.ToInt32(iptalKoltuk[i]));
                    this.Controls.Find("btn" + iptalKoltuk[i].ToString(), true)[0].BackColor = Color.Chartreuse;
                }

            FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
            SqlCommand com = new SqlCommand("SELECT *FROM Bilet WHERE Koltuk ='"+txtiptalKoltuk.Text+"'", FBAGLANTI.Baglan);
            FBAGLANTI.Baglan.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    item.BiletID = Convert.ToInt32(dr["BiletID"]);
                    item.FilmID = Convert.ToInt32(dr["FilmID"]);
                    item.SalonID = Convert.ToInt32(dr["SalonID"]);
                    item.SeansID = Convert.ToInt32(dr["SeansID"]);
                    item.MusteriAd = dr["MusteriAd"].ToString();
                    item.MusteriSoyad = dr["MusteriSoyad"].ToString();
                    item.Koltuk = dr["Koltuk"].ToString();
                    item.BiletAdet = Convert.ToInt32(dr["BiletAdet"]);
                }
            }

            BLLBILETCI.Bilet_Delete(item.BiletID);
            dr.Close();
            com.Dispose();
            FBAGLANTI.Baglan.Close();
            FBAGLANTI.Baglan.Dispose();



            iptalKoltuk.Clear();//www.gorselprogramlama.com

                txtiptalKoltuk.Text = "";

                txtAd.Text = "";

                txtSoyad.Text = "";

        }


    }
}

