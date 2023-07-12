using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Hastane_Projesi
{
    internal class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=PC-0540\\MS_SQL_SERVER;Initial Catalog=HastaneProje;Integrated Security=True");
        baglan.Open();

            return baglan;

        }
    }
}
