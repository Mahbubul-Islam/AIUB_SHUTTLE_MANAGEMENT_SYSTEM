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

        private static readonly string connectionString = "data source=DESKTOP-0871C35\\SQLEXPRESS; database=AIUB_SHUTTLE_MANAGEMENT_SYSTEM; integrated security=SSPI";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
