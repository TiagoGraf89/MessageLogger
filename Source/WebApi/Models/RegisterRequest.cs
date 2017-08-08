using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class RegisterRequest
    {
        [Required]
        [MaxLength(32)]
        public string Display_Name { get; set; }
    }
}