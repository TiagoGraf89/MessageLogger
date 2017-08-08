using System;
using System.IO;
using System.Reflection;
using DataLib.Extensions;
using System.Data.SqlClient;
using System.Linq;

namespace DataLib
{
    public partial class Repository
    {
        public Models.SettingModel _settings;
        public Models.SettingModel Settings {
            get
            {
                if (_settings == null)
                    _settings = GetSettings();

                return _settings;
            }
        }
        /// <summary>
        /// Get the connection string from the config file
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        /// <summary>
        /// Get the sql script stored in the application resources
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public string GetScript(Scripts.Scripts script)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            using (Stream resFilestream = a.GetManifestResourceStream("DataLib.Scripts." + script.DescriptionAttr()))
            {
                if (resFilestream != null)
                {
                    StreamReader br = new StreamReader(resFilestream);
                    return br.ReadToEnd();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Get settings for the application
        /// </summary>
        /// <returns></returns>
        public Models.SettingModel GetSettings()
        {
            using (SqlConnection conn = new SqlConnection(this.GetConnectionString()))
            {
                conn.Open();
                string query = this.GetScript(Scripts.Scripts.GetSettings);
                var result = Dapper.SqlMapper.Query<Models.SettingModel>(conn, query, null);
                return result.FirstOrDefault();
            }
        }
    }
}
