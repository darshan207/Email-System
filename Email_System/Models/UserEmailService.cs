using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Email_System.Models
{
    public class UserEmailService
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public User User { get; set; }
    }
}