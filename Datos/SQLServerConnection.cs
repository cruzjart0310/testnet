using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class SQLServerConnection
    {
        public static SqlConnection open()
        {
            SqlConnection conex = new SqlConnection("Data Source=DESKTOP-EJ14VN6; Initial Catalog=test; User Id=sa; Password=12345678;");
            conex.Open();
            return conex;
        }

        public static SqlConnection close()
        {
            SqlConnection conex = new SqlConnection("Data Source=DESKTOP-EJ14VN6; Initial Catalog=test; User Id=sa; Password=12345678;");
            conex.Close();
            return conex;
        }
    }
}
