using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public partial class Repository
    {

        public void InsertMessageLog(Models.MessageModel log)
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.InsertLog);
                Dapper.SqlMapper.Execute(conn, query, log);
            }
        }

    }
}
