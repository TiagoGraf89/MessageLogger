using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Models
{
    public class ApplicationModel
    {
        public string Application_Id { get; set; }
        public string Display_Name { get; set; }
        public string Secret { get; set; }
    }

    public class TokenModel
    {
        public string Application_Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
