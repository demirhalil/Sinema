using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using EntityLayer;


namespace FacadeLayer
{
    public class FADMIN
    {
        //Çalışan işlemlerinin yapıldığı metotlar.
        public static int Calisan_Insert(ECALISAN item)
        {
            int sonuc;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Calisan_Insert", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("Ad", item.Ad);
                com.Parameters.AddWithValue("Soyad", item.Soyad);
                com.Parameters.AddWithValue("KullaniciAd", item.KullaniciAd);
                com.Parameters.AddWithValue("KullaniciParola", item.KullaniciParola);
                com.Parameters.AddWithValue("DogumTarih", item.DogumTarih);
                com.Parameters.AddWithValue("IseGirisTarih", item.IseGirisTarih);
                com.Parameters.AddWithValue("TCNO", item.TCNO);
                com.Parameters.AddWithValue("AdminYetki", item.AdminYetki);
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

        public static bool Calisan_Update(ECALISAN item)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Calisan_Update", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("CalisanID", item.CalisanID);
                com.Parameters.AddWithValue("Ad", item.Ad);
                com.Parameters.AddWithValue("Soyad", item.Soyad);
                com.Parameters.AddWithValue("KullaniciAd", item.KullaniciAd);
                com.Parameters.AddWithValue("KullaniciParola", item.KullaniciParola);
                com.Parameters.AddWithValue("DogumTarih", item.DogumTarih);
                com.Parameters.AddWithValue("IseGirisTarih", item.IseGirisTarih);
                com.Parameters.AddWithValue("TCNO", item.TCNO);
                com.Parameters.AddWithValue("AdminYetki", item.AdminYetki);
                sonuc = com.ExecuteNonQuery() > 0;

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                sonuc = true;
            }

            return sonuc;
        }

        public static bool Calisan_Delete(int _CalisanID)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Calisan_Delete", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("CalisanID", _CalisanID);
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

        public static ECALISAN Calisan_Select(int _CalisanID)
        {
            ECALISAN item = new ECALISAN();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Calisan_Select", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("CalisanID", _CalisanID);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item.CalisanID = Convert.ToInt32(dr["CalisanID"]);
                        item.Ad = dr["Ad"].ToString();
                        item.Soyad = dr["Soyad"].ToString();
                        item.KullaniciAd = dr["KullaniciAd"].ToString();
                        item.KullaniciParola = dr["KullaniciParola"].ToString();
                        item.DogumTarih = Convert.ToDateTime(dr["DogumTarih"]);
                        item.IseGirisTarih = Convert.ToDateTime(dr["IseGirisTarih"]);
                        item.TCNO = dr["TCNO"].ToString();
                        item.AdminYetki = Convert.ToBoolean(dr["AdminYetki"]);
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

        public static List<ECALISAN> Calisan_SelectList()
        {
            List<ECALISAN> itemList = new List<ECALISAN>();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Calisan_SelectList", FBAGLANTI.Baglan);
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
                        ECALISAN item = new ECALISAN();

                        item.CalisanID = Convert.ToInt32(dr["CalisanID"]);
                        item.Ad = dr["Ad"].ToString();
                        item.Soyad = dr["Soyad"].ToString();
                        item.KullaniciAd = dr["KullaniciAd"].ToString();
                        item.KullaniciParola = dr["KullaniciParola"].ToString();
                        item.DogumTarih = Convert.ToDateTime(dr["DogumTarih"]);
                        item.IseGirisTarih = Convert.ToDateTime(dr["IseGirisTarih"]);
                        item.TCNO = dr["TCNO"].ToString();
                        item.AdminYetki = Convert.ToBoolean(dr["AdminYetki"]);

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

        public static DataTable getDataTableCalisan()
        {
            FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Calisan_SelectList", FBAGLANTI.Baglan);
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


        //Film işlemlerinin yapıldığı metotlar.
        public static int Film_Insert(EFILM item)
        {
            int sonuc;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Film_Insert", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("FilmAd", item.FilmAd);
                com.Parameters.AddWithValue("Yonetmen", item.Yonetmen);
                com.Parameters.AddWithValue("Sure", item.Sure);
                com.Parameters.AddWithValue("YayinTarih", item.YayinTarih);
                com.Parameters.AddWithValue("Aktif", item.Aktif);
                com.Parameters.AddWithValue("Kategori", item.Kategori);
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

        public static bool Film_Update(EFILM item)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Film_Update", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("FilmID", item.FilmID);
                com.Parameters.AddWithValue("FilmAd", item.FilmAd);
                com.Parameters.AddWithValue("Yonetmen", item.Yonetmen);
                com.Parameters.AddWithValue("Sure", item.Sure);
                com.Parameters.AddWithValue("YayinTarih", item.YayinTarih);
                com.Parameters.AddWithValue("Aktif", item.Aktif);
                com.Parameters.AddWithValue("Kategori", item.Kategori);

                sonuc = com.ExecuteNonQuery() > 0;

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                sonuc = true;
            }

            return sonuc;
        }

        public static bool Film_Delete(int _FilmID)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Film_Delete", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("FilmID", _FilmID);
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

        public static EFILM Film_Select(int _FilmID)
        {
            EFILM item = new EFILM();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Film_Select", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("FilmID", _FilmID);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item.FilmID = Convert.ToInt32(dr["FilmID"]);
                        item.FilmAd = dr["FilmAd"].ToString();
                        item.Yonetmen = dr["Yonetmen"].ToString();
                        item.Sure = Convert.ToInt32(dr["Sure"]);
                        item.YayinTarih = Convert.ToDateTime(dr["YayinTarih"]);
                        item.Aktif = Convert.ToBoolean(dr["Aktif"]);
                        item.Kategori = dr["Kategori"].ToString();
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

        public static List<EFILM> Film_SelectList()
        {
            List<EFILM> itemList = new List<EFILM>();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Film_SelectList", FBAGLANTI.Baglan);
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
                        EFILM item = new EFILM();

                        item.FilmID = Convert.ToInt32(dr["FilmID"]);
                        item.FilmAd = dr["FilmAd"].ToString();
                        item.Yonetmen = dr["Yonetmen"].ToString();
                        item.Sure = Convert.ToInt32(dr["Sure"]);
                        item.YayinTarih = Convert.ToDateTime(dr["YayinTarih"]);
                        item.Aktif = Convert.ToBoolean(dr["Aktif"]);
                        item.Kategori = dr["Kategori"].ToString();

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

        public static DataTable getDataTableFilm()
        {
            FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Film_SelectList", FBAGLANTI.Baglan);
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


        //Salon işlemlerinin yapıldığı metotlar.
        public static int Salon_Insert(ESALON item)
        {
            int sonuc;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Salon_Insert", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SalonAd", item.SalonAd);
                com.Parameters.AddWithValue("Kapasite", item.Kapasite);

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

        public static bool Salon_Update(ESALON item)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Salon_Update", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SalonID", item.SalonID);
                com.Parameters.AddWithValue("SalonAd", item.SalonAd);
                com.Parameters.AddWithValue("Kapasite", item.Kapasite);

                sonuc = com.ExecuteNonQuery() > 0;

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                sonuc = true;
            }

            return sonuc;
        }

        public static bool Salon_Delete(int _SalonID)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Salon_Delete", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SalonID", _SalonID);
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

        public static ESALON Salon_Select(int _SalonID)
        {
            ESALON item = new ESALON();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Salon_Select", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SalonID", _SalonID);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item.SalonID = Convert.ToInt32(dr["SalonID"]);
                        item.SalonAd = dr["SalonAd"].ToString();
                        item.Kapasite = Convert.ToInt32(dr["Kapasite"]);
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

        public static List<ESALON> Salon_SelectList()
        {
            List<ESALON> itemList = new List<ESALON>();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Salon_SelectList", FBAGLANTI.Baglan);
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
                        ESALON item = new ESALON();

                        item.SalonID = Convert.ToInt32(dr["SalonID"]);
                        item.SalonAd = dr["SalonAd"].ToString();
                        item.Kapasite = Convert.ToInt32(dr["Kapasite"]);

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

        public static DataTable getDataTableSalon()
        {
            FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Salon_SelectList", FBAGLANTI.Baglan);
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


        //Seans işlemlerinin yapıldı metotlar.
        public static int Seans_Insert(ESEANS item)
        {
            int sonuc;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Seans_Insert", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SeansSaat", item.SeansSaat);

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

        public static bool Seans_Update(ESEANS item)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Seans_Update", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SeansID", item.SeansID);
                com.Parameters.AddWithValue("SeansSaat", item.SeansSaat);

                sonuc = com.ExecuteNonQuery() > 0;

                com.Dispose();
                FBAGLANTI.Baglan.Close();
                FBAGLANTI.Baglan.Dispose();
            }
            catch
            {
                sonuc = true;
            }

            return sonuc;
        }

        public static bool Seans_Delete(int _SeansID)
        {
            bool sonuc = false;

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Seans_Delete", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SeansID", _SeansID);
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

        public static ESEANS Seans_Select(int _SeansID)
        {
            ESEANS item = new ESEANS();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Seans_Select", FBAGLANTI.Baglan);
                com.CommandType = CommandType.StoredProcedure;
                if (com.Connection.State != ConnectionState.Open)
                {
                    com.Connection.Open();
                }
                com.Parameters.AddWithValue("SeansID", _SeansID);
                SqlDataReader dr = com.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        item.SeansID = Convert.ToInt32(dr["SeansID"]);
                        item.SeansSaat = dr["SeansSaat"].ToString();
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

        public static List<ESEANS> Seans_SelectList()
        {
            List<ESEANS> itemList = new List<ESEANS>();

            try
            {
                FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
                SqlCommand com = new SqlCommand("Seans_SelectList", FBAGLANTI.Baglan);
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
                        ESEANS item = new ESEANS();

                        item.SeansID = Convert.ToInt32(dr["SeansID"]);
                        item.SeansSaat = dr["SeansSaat"].ToString();

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

        public static DataTable getDataTableSeans()
        {
            FBAGLANTI.Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter("Seans_SelectList", FBAGLANTI.Baglan);
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
