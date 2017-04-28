using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer;
using FacadeLayer;

namespace BusinessLogicLayer
{
    public class BLLBILETCI
    {
        //Bilet verilerinin kontrolünün yapıldığı metotlar.
        public static int Bilet_Insert(EBILET item)
        {
            if (item.FilmID > 0 && item.SalonID > 0 && item.SeansID > 0 && item.MusteriAd != null && item.MusteriAd.Trim().Length > 0 && item.MusteriSoyad != null && item.MusteriSoyad.Trim().Length > 0 && item.Koltuk != null && item.Koltuk.Trim().Length > 0 && item.BiletAdet > 0 && item.Ucret > 0)
            {
                return FBILETCI.Bilet_Insert(item);
            }

            return -1;
        }

        public static bool Bilet_Update(EBILET item)
        {
            if (item.BiletID > 0 && item.FilmID > 0 && item.SalonID > 0 && item.SeansID > 0 && item.MusteriAd != null && item.MusteriAd.Trim().Length > 0 && item.MusteriSoyad != null && item.MusteriSoyad.Trim().Length > 0 && item.Koltuk != null && item.Koltuk.Trim().Length > 0 && item.BiletAdet > 0 && item.Ucret > 0)
            {
                return FBILETCI.Bilet_Update(item);
            }

            return false;
        }

        public static bool Bilet_Delete(int _BiletID)
        {
            if (_BiletID > 0)
            {
                return FBILETCI.Bilet_Delete(_BiletID);
            }

            return false;
        }

        public static EBILET Bilet_Select(int _BiletID)
        {
            if (_BiletID > 0)
            {
                return FBILETCI.Bilet_Select(_BiletID);
            }

            return null;
        }

        public static List<EBILET> Bilet_SelectList()
        {
            return FBILETCI.Bilet_SelectList();
        }

        public static DataTable getDataTableBilet()
        {
            return FBILETCI.getDataTableBilet();
        }
    }
}
