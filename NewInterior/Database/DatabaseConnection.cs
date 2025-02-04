using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInterior.Database
{
    public static class DatabaseConnection
    {

        //"data source=YourServerName; database=DB_Name; integrated security=SSPI"
        //MH-SHUVO\\SQLEXPRESS
        //DESKTOP-RPJPVDU\\SQLEXPRESS
        //DESKTOP-0871C35\SQLEXPRESS

        private static readonly string connectionString = "Server=MH-SHUVO\\SQLEXPRESS; database=AIUB_SHUTTLE_MANAGEMENT_SYSTEM; integrated security=SSPI";



        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
