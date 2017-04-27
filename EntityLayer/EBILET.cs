using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class EBILET
    {
        private int _BiletID;
        private int _FilmID;
        private int _SalonID;
        private int _SeansID;
        private string _MusteriAd;
        private string _MusteriSoyad;
        private string _Koltuk;
        private int _BiletAdet;
        private Decimal _Ucret;

        public int BiletID
        {
            get
            {
                return _BiletID;
            }

            set
            {
                _BiletID = value;
            }
        }

        public int FilmID
        {
            get
            {
                return _FilmID;
            }

            set
            {
                _FilmID = value;
            }
        }

        public int SalonID
        {
            get
            {
                return _SalonID;
            }

            set
            {
                _SalonID = value;
            }
        }

        public int SeansID
        {
            get
            {
                return _SeansID;
            }

            set
            {
                _SeansID = value;
            }
        }

        public string MusteriAd
        {
            get
            {
                return _MusteriAd;
            }

            set
            {
                _MusteriAd = value;
            }
        }

        public string MusteriSoyad
        {
            get
            {
                return _MusteriSoyad;
            }

            set
            {
                _MusteriSoyad = value;
            }
        }

        public string Koltuk
        {
            get
            {
                return _Koltuk;
            }

            set
            {
                _Koltuk = value;
            }
        }

        public int BiletAdet
        {
            get
            {
                return _BiletAdet;
            }

            set
            {
                _BiletAdet = value;
            }
        }

        public decimal Ucret
        {
            get
            {
                return _Ucret;
            }

            set
            {
                _Ucret = value;
            }
        }
    }
}
