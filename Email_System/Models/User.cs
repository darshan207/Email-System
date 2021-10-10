using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Email_System.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string uname { get; set; }
        [Required]
        public string pass { get; set; }
    }
}