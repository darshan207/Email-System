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
        public int FromUserId { get; set; }
        [Required]
        public int ToUserId { get; set; }
        public string EmailSubject { get; set; }
        [Required]
        public string EmailText { get; set; }
        [Required]
        public Boolean Is_Inbox { get; set; }
        [Required]
        public Boolean Is_Sent { get; set; }
        [Required]
        public Boolean Is_FromUser_Starred { get; set; }
        [Required]
        public Boolean Is_ToUser_Starred { get; set; }
        [Required]
        public Boolean Is_FromUser_Delete { get; set; }
        [Required]
        public Boolean Is_ToUser_Delete { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentType { get; set; }
        public byte[] AttachmentData { get; set; }
    }
}