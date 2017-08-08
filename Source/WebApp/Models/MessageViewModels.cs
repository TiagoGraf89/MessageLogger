using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApp.Models
{

    public class MessageViewModel
    {
        [Required]
        [MaxLength(32)]
        [Display(Name = "Application Id")]
        public string Application_Id { get; set; }
        [Required]
        [MaxLength(256)]
        [Display(Name = "Logger")]
        public string Logger { get; set; }
        [Required]
        [MaxLength(256)]
        [Display(Name = "Level")]
        public string Level { get; set; }
        [Required]
        [MaxLength(2048)]
        [Display(Name = "Message")]
        public string Message { get; set; }

    }
}
