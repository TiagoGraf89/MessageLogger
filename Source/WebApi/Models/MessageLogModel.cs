using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MessageLogModel
    {
        [Required]
        [MaxLength(32)]
        public string Application_Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Logger { get; set; }
        [Required]
        [MaxLength(256)]
        public string Level { get; set; }
        [Required]
        [MaxLength(2048)]
        public string Message { get; set; }

    }
}