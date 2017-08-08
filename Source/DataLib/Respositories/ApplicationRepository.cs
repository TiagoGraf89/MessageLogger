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
        /// <summary>
        /// Check application id and password
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public bool CheckAuthentication(string appId, string appSecret)
        {
            var app = this.GetApplication(appId);
            if (app == null)
                return false;

            if (app.Secret == appSecret)
                return true;
            else
                return false;
        }

        public Models.ApplicationModel GetApplication(string appId)
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.GetApplications);
                return Dapper.SqlMapper.Query<Models.ApplicationModel>(conn, query, new
                {
                    application_id = appId
                }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Insert a new application
        /// </summary>
        /// <param name="app"></param>
        public void InsertApplication(Models.ApplicationModel app)
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.InsertApplication);
                Dapper.SqlMapper.Execute(conn, query, app);
            }
        }

        
    }
}
