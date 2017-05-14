using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ESALON
    {
        #region Salon Bilgileri
        private int _SalonID;
        private string _SalonAd;
        private int _Kapasite;

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

        public string SalonAd
        {
            get
            {
                return _SalonAd;
            }

            set
            {
                _SalonAd = value;
            }
        }

        public int Kapasite
        {
            get
            {
                return _Kapasite;
            }

            set
            {
                _Kapasite = value;
            }
        }
        #endregion
    }
}
