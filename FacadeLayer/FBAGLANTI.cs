using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;


namespace FacadeLayer
{
   public class FBAGLANTI
    {
        public static SqlConnection Baglan = new SqlConnection("Data Source=.;Initial Catalog=SINEMA;Integrated Security=True");
    }
}
