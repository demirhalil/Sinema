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
                dataGridViewFilm.Columns["Aktif"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            else if (tabControl1.SelectedIndex == 1)
            {
                tabPageSalon.ImeMode = ImeMode.On;
                
                DataTable dt = new DataTable();
                dt = BLLADMIN.getDataTableSalon();
                dt.Columns["SalonAd"].ColumnName = "Salon Ad";
                dt.Columns["Kapasite"].ColumnName = "Kapasite";


                dataGridView1.DataSource = dt;
                dataGridView1.Columns["SalonID"].Visible = false;
                dataGridView1.Columns["Salon Ad"].Width = 150;
                dataGridView1.Columns["Kapasite"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
           
            

            
        }
    }
}
