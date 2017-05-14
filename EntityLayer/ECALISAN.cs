using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ECALISAN
    {
        #region Çalışan Bilgileri
        private int _CalisanID;
        private string _Ad;
        private string _Soyad;
        private string _KullaniciAd;
        private string _KullaniciParola;
        private DateTime _DogumTarih;
        private DateTime _IseGirisTarih;
        private string _TCNO;
        private bool _AdminYetki;

        public int CalisanID
        {
            get
            {
                return _CalisanID;
            }

            set
            {
                _CalisanID = value;
            }
        }

        public string Ad
        {
            get
            {
                return _Ad;
            }

            set
            {
                _Ad = value;
            }
        }

        public string Soyad
        {
            get
            {
                return _Soyad;
            }

            set
            {
                _Soyad = value;
            }
        }

        public string KullaniciAd
        {
            get
            {
                return _KullaniciAd;
            }

            set
            {
                _KullaniciAd = value;
            }
        }

        public string KullaniciParola
        {
            get
            {
                return _KullaniciParola;
            }

            set
            {
                _KullaniciParola = value;
            }
        }

        public DateTime DogumTarih
        {
            get
            {
                return _DogumTarih;
            }

            set
            {
                _DogumTarih = value;
            }
        }

        public DateTime IseGirisTarih
        {
            get
            {
                return _IseGirisTarih;
            }

            set
            {
                _IseGirisTarih = value;
            }
        }

        public string TCNO
        {
            get
            {
                return _TCNO;
            }

            set
            {
                _TCNO = value;
            }
        }

        public bool AdminYetki
        {
            get
            {
                return _AdminYetki;
            }

            set
            {
                _AdminYetki = value;
            }
        }
        #endregion
    }
}
