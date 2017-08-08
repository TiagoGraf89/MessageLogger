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
        /// Generate a token for the application id
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public Models.TokenModel GenerateToken(string appId)
        {
            var app = this.GetApplication(appId);
            if (app == null)
                return null;

            var token = new Models.TokenModel()
            {
                Application_Id = appId,
                CreatedOn = DateTime.Now,
                ExpiresOn = DateTime.Now.AddMinutes(this.Settings.Token_Expiry_Minutes),
                Token = Guid.NewGuid().ToString()
            };
            this.InsertToken(token);

            return token;
        }



        /// <summary>
        /// Method to validate token against expiry and existence in database.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool CheckTokenAuthentication(string tokenId)
        {
            var token = this.GetToken(tokenId);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                token.ExpiresOn = token.ExpiresOn.AddMinutes(this.Settings.Token_Expiry_Minutes);
                this.UpdateToken(token);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Insert a new token
        /// </summary>
        /// <param name="app"></param>
        public void InsertToken(Models.TokenModel token)
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.InsertToken);
                Dapper.SqlMapper.Execute(conn, query, token);
            }
        }

        /// <summary>
        /// Update an existing token
        /// </summary>
        /// <param name="app"></param>
        public void UpdateToken(Models.TokenModel token)
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.UpdateToken);
                Dapper.SqlMapper.Execute(conn, query, token);
            }
        }

        /// <summary>
        /// Get an auth token from the database
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Models.TokenModel GetToken(string token)
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.GetToken);
                var result = Dapper.SqlMapper.Query<Models.TokenModel>(conn, query, 
                    new { token = token });
                return result.FirstOrDefault();
            }
        }
    }
}
