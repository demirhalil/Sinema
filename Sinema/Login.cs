using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using FacadeLayer;
using BusinessLogicLayer;

namespace Sinema
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            List<ECALISAN> itemlist = BLLADMIN.Calisan_SelectList();

            foreach (ECALISAN item in itemlist)
            {
                if (item.KullaniciAd == txtKullaniciAd.Text && item.KullaniciParola == txtParola.Text && item.AdminYetki == true)
                {
                    Admin frmAdmin = new Admin();
                    frmAdmin.ShowDialog();
                    this.Close();
                    break;
                }

                else if (item.KullaniciAd == txtKullaniciAd.Text && item.KullaniciParola == txtParola.Text && item.AdminYetki == false)
                {
                    Biletci frmBiletci = new Biletci();
                    frmBiletci.ShowDialog();
                    this.Close();
                    break;
                }

                else
                {
                    lblHata.Visible = true;
                    lblHata.ForeColor = System.Drawing.Color.Red;
                    continue;                 
                }              
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            lblHata.Visible = false;
        }
    }
}
