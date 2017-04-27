using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ESEANS
    {
        private int _SeansID;
        private string _SeansSaat;

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

        public string SeansSaat
        {
            get
            {
                return _SeansSaat;
            }

            set
            {
                _SeansSaat = value;
            }
        }
    }
}
