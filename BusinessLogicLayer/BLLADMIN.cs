using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BLLADMIN
    {
        #region Çalışan Veri Kontrolü
        //Çalışan verilerinin kontrolünün yapıldığı metotlar.
        public static int Calisan_Insert(ECALISAN item)
        {
            if (item.Ad != null && item.Ad.Trim().Length > 0 && item.Soyad != null && item.Soyad.Trim().Length > 0 && item.KullaniciAd != null && item.KullaniciAd.Trim().Length > 0 && item.KullaniciParola != null && item.KullaniciParola.Trim().Length > 0 && item.DogumTarih != null && item.IseGirisTarih != null && item.TCNO != null && item.TCNO.Trim().Length > 0)
            {
                return FADMIN.Calisan_Insert(item);
            }

            return -1;
        }

        public static bool Calisan_Update(ECALISAN item)
        {
            if (item.CalisanID > 0 && item.Ad != null && item.Ad.Trim().Length > 0 && item.Soyad != null && item.Soyad.Trim().Length > 0 && item.KullaniciAd != null && item.KullaniciAd.Trim().Length > 0 && item.KullaniciParola != null && item.KullaniciParola.Trim().Length > 0 && item.DogumTarih != null && item.IseGirisTarih != null && item.TCNO != null && item.TCNO.Trim().Length > 0)
            {
                return FADMIN.Calisan_Update(item);
            }

            return false;
        }

        public static bool Calisan_Delete(int _CalisanID)
        {
            if (_CalisanID > 0)
            {
                return FADMIN.Calisan_Delete(_CalisanID);
            }

            return false;
        }

        public static ECALISAN Calisan_Select(int _CalisanID)
        {
            if (_CalisanID > 0)
            {
                return FADMIN.Calisan_Select(_CalisanID);
            }

            return null;
        }

        public static List<ECALISAN> Calisan_SelectList()
        {
            return FADMIN.Calisan_SelectList();
        }

        public static DataTable getDataTableCalisan()
        {
            return FADMIN.getDataTableCalisan();
        }
        #endregion

        #region Film Veri Kontrolü
        //Film verilerinin kontrolünün yapıldığı metotlar.
        public static int Film_Insert(EFILM item)
        {
            if (item.FilmAd != null && item.FilmAd.Trim().Length > 0 && item.Yonetmen != null && item.Yonetmen.Trim().Length > 0 && item.Sure > 0 && item.YayinTarih != null && item.Kategori != null && item.Kategori.Trim().Length > 0)
            {
                return FADMIN.Film_Insert(item);
            }

            return -1;
        }

        public static bool Film_Update(EFILM item)
        {
            if (item.FilmID > 0 && item.FilmAd != null && item.FilmAd.Trim().Length > 0 && item.Yonetmen != null && item.Yonetmen.Trim().Length > 0 && item.Sure > 0 && item.YayinTarih != null && item.Kategori != null && item.Kategori.Trim().Length > 0)
            {
                return FADMIN.Film_Update(item);
            }

            return false;
        }

        public static bool Film_Delete(int _FilmID)
        {
            if (_FilmID > 0)
            {
               return FADMIN.Film_Delete(_FilmID);
            }

            return false;
        }

        public static EFILM Film_Select(int _FilmID)
        {
            if (_FilmID > 0)
            {
                return FADMIN.Film_Select(_FilmID);
            }

            return null;
        }

        public static List<EFILM> Film_SelectList()
        {
            return FADMIN.Film_SelectList();
        }

        public static DataTable getDataTableFilm()
        {
            return FADMIN.getDataTableFilm();
        }
        #endregion

        #region Salon Veri Kontrolü
        //Salon verilerinin kontrolünün yapıldığı metotlar.
        public static int Salon_Insert(ESALON item)
        {
            if (item.SalonAd != null && item.SalonAd.Trim().Length > 0 && item.Kapasite > 0)
            {
                return FADMIN.Salon_Insert(item);
            }

            return -1;
        }

        public static bool Salon_Update(ESALON item)
        {
            if (item.SalonID > 0 && item.SalonAd != null && item.SalonAd.Trim().Length > 0 && item.Kapasite > 0)
            {
                return FADMIN.Salon_Update(item);
            }

            return false;
        }

        public static bool Salon_Delete(int _SalonID)
        {
            if (_SalonID > 0)
            {
                return FADMIN.Salon_Delete(_SalonID);
            }

            return false;
        }

        public static ESALON Salon_Select(int _SalonID)
        {
            if (_SalonID > 0)
            {
                return FADMIN.Salon_Select(_SalonID);
            }

            return null;
        }

        public static List<ESALON> Salon_SelectList()
        {
            return FADMIN.Salon_SelectList();
        }

        public static DataTable getDataTableSalon()
        {
            return FADMIN.getDataTableSalon();
        }
        #endregion

        #region Seans Veri Kontrolü
        //Seans verilerinin kontrolünün yapıldı metotlar.
        public static int Seans_Insert(ESEANS item)
        {
            if (item.SeansSaat != null && item.SeansSaat.Trim().Length > 0)
            {
                return FADMIN.Seans_Insert(item);
            }

            return -1;
        }

        public static bool Seans_Update(ESEANS item)
        {
            if (item.SeansID > 0 &&  item.SeansSaat != null && item.SeansSaat.Trim().Length > 0)
            {
                return FADMIN.Seans_Update(item);
            }

            return false;
        }

        public static bool Seans_Delete(int _SeansID)
        {
            if (_SeansID > 0)
            {
                return FADMIN.Seans_Delete(_SeansID);
            }

            return false;
        }

        public static ESEANS Seans_Select(int _SeansID)
        {
            if (_SeansID > 0)
            {
                return FADMIN.Seans_Select(_SeansID);
            }

            return null;
            
        }

        public static List<ESEANS> Seans_SelectList()
        {
            return FADMIN.Seans_SelectList();
        }

        public static DataTable getDataTableSeans()
        {
            return FADMIN.getDataTableSeans();
        }
        #endregion
    }
}
