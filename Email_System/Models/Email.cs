using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Email_System.Models
{
    public class Email
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public UserEmailService UserEmailService { get; set; }

        public int UserId { get; set; }
        [Required]
        public int ToUserId { get; set; }
        public string EmailSubject { get; set; }
        [Required]
        public string EmailText { get; set; }
        public byte[] EmailAttachment { get; set;}
    }
}