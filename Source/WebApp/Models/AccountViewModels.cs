using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Application Id")]
        public string ApplicationId { get; set; }

        [Required]
        [Display(Name = "Secret")]
        public string Secret { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Display Name")]
        public string Display_Name { get; set; }
    }
}
