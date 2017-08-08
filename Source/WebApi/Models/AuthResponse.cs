using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AuthResponse
    {
        public string Access_Token { get; set; }
    }

    public class SaveResponse
    {
        public bool Success { get; set; }
    }
}