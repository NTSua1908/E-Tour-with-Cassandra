using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class DataConnection
    {
        String conStr;
        public DataConnection()
        {
            //conStr = "Data Source= DESKTOP-QLEJV95\\SQLEXPRESS; Initial Catalog=TourManagement; Integrated Security=True";
            conStr = "Data Source= DESKTOP-CI36P6F; Initial Catalog = TourManagement; Integrated Security = True";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
            
    }
}
