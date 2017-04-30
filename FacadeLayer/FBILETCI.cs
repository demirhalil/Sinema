using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using EntityLayer;

namespace FacadeLayer
{
   public class FBILETCI
    {
        //Bilet işlemlerinin yapıldığı metotlar.
        public static int Bilet_Insert(EBILET item)
        {
            int sonuc;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Bilet_Insert", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("FilmID", item.FilmID);
                com.Parameters.AddWithValue("SalonID", item.SalonID);
                com.Parameters.AddWithValue("SeansID", item.SeansID);
                com.Parameters.AddWithValue("MusteriAd", item.MusteriAd);
                com.Parameters.AddWithValue("MusteriSoyad", item.MusteriSoyad);
                com.Parameters.AddWithValue("Koltuk", item.Koltuk);
                com.Parameters.AddWithValue("BiletAdet", item.BiletAdet);
                com.Parameters.AddWithValue("Ucret", item.Ucret);
                sonuc = com.ExecuteNonQuery();

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                sonuc = -1;
            }

            return sonuc;
        }

        public static bool Bilet_Update(EBILET item)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Bilet_Update", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("BiletID", item.BiletID);
                com.Parameters.AddWithValue("FilmID", item.FilmID);
                com.Parameters.AddWithValue("SalonID", item.SalonID);
                com.Parameters.AddWithValue("SeansID", item.SeansID);
                com.Parameters.AddWithValue("MusteriAd", item.MusteriAd);
                com.Parameters.AddWithValue("MusteriSoyad", item.MusteriSoyad);
                com.Parameters.AddWithValue("Koltuk", item.Koltuk);
                com.Parameters.AddWithValue("BiletAdet", item.BiletAdet);
                com.Parameters.AddWithValue("Ucret", item.Ucret);
                sonuc = com.ExecuteNonQuery() > 0;

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                sonuc = false;
            }

            return sonuc;
        }

        public static bool Bilet_Delete(int _BiletID)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Bilet_Delete", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("BiletID", _BiletID);
                sonuc = com.ExecuteNonQuery() > 0;

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();

            }
            catch
            {
                sonuc = false;
            }

            return sonuc;
        }

        public static EBILET Bilet_Select(int _BiletID)
        {
            EBILET item = new EBILET();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Bilet_Select", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("BiletID", _BiletID);
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
                dr.Close();
                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                item = null;
            }

            return item;
        }

        public static List<EBILET> Bilet_SelectList()
        {
            List<EBILET> itemList = new List<EBILET>();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Bilet_SelectList", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EBILET item = new EBILET();

                        item.BiletID = Convert.ToInt32(dr["BiletID"]);
                        item.FilmID = Convert.ToInt32(dr["FilmID"]);
                        item.SalonID = Convert.ToInt32(dr["SalonID"]);
                        item.SeansID = Convert.ToInt32(dr["SeansID"]);
                        item.MusteriAd = dr["MusteriAd"].ToString();
                        item.MusteriSoyad = dr["MusteriSoyad"].ToString();
                        item.Koltuk = dr["Koltuk"].ToString();
                        item.BiletAdet = Convert.ToInt32(dr["BiletAdet"]);

                        itemList.Add(item);
                    }
                }

                dr.Close();
                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                itemList = null;
            }

            return itemList;
        }

        public static DataTable getDataTableBilet()
        {
            FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Bilet_SelectList", FBAGLANTI.Baglan);
            DataTable dt = new DataTable();

            try
            {
                adapter.Fill(dt);
            }
            catch
            {
                dt = null;
            }

            dt.Dispose();
            adapter.Dispose();
            FBAGLANTI.Baglan.Close();
            FBAGLANTI.Baglan.Dispose();

            return dt;
        }
    }
}
