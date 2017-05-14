using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class EFILM
    {
        #region Film Bilgileri
        private int _FilmID;
        private string _FilmAd;
        private string _Yonetmen;
        private int _Sure;
        private DateTime _YayinTarih;
        private bool _Aktif;
        private string _Kategori;

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

        public string FilmAd
        {
            get
            {
                return _FilmAd;
            }

            set
            {
                _FilmAd = value;
            }
        }

        public string Yonetmen
        {
            get
            {
                return _Yonetmen;
            }

            set
            {
                _Yonetmen = value;
            }
        }

        public int Sure
        {
            get
            {
                return _Sure;
            }

            set
            {
                _Sure = value;
            }
        }

        public DateTime YayinTarih
        {
            get
            {
                return _YayinTarih;
            }

            set
            {
                _YayinTarih = value;
            }
        }

        public bool Aktif
        {
            get
            {
                return _Aktif;
            }

            set
            {
                _Aktif = value;
            }
        }

        public string Kategori
        {
            get
            {
                return _Kategori;
            }

            set
            {
                _Kategori = value;
            }
        }
        #endregion
    }
}
