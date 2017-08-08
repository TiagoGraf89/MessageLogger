using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Scripts
{
    public enum Scripts
    {
        [Description("Application.GetApplications.sql")]
        GetApplications,
        [Description("Application.InsertApplication.sql")]
        InsertApplication,
        [Description("Log.InsertLog.sql")]
        InsertLog,
        [Description("Token.InsertToken.sql")]
        InsertToken,
        [Description("Token.UpdateToken.sql")]
        UpdateToken,
        [Description("Token.GetToken.sql")]
        GetToken,
        [Description("Settings.GetSettings.sql")]
        GetSettings,
    }
}
