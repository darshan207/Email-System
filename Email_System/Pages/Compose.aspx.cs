using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;

namespace Email_System.Pages
{
    public partial class Compose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Compose_Send_Mail_Click(object sender, EventArgs e)
        {
            if (Compose_Mail_To == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You have to add email where you want to send');", true);
                Response.Redirect("~/Pages/Inbox");
            }
            else if (Compose_Mail_Body == null && !(Compose_Mail_File.HasFile))
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('You have to write or attach something');", true);
                Response.Redirect("~/Pages/Inbox");
            }

            EmailDbContext db = new EmailDbContext();
            User ToUser = db.Users.Where(b => b.UserEmailId == Compose_Mail_To.Text).FirstOrDefault();
            if (ToUser == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email you want to sned is not found');", true);
                Response.Redirect("~/Pages/Compose");
            }
            else
            {
                int FromUserId, ToUserId;
                string user = Session["user"].ToString();
                ToUserId = ToUser.Id;
                User FromUser = db.Users.Where(b => b.UserName == user).FirstOrDefault();
                FromUserId = FromUser.Id;
                Email email = new Email { };
                email.FromUserId = FromUserId;
                email.ToUserId = ToUserId;
                email.EmailSubject = Compose_Mail_Subject.Text;
                email.EmailText = Compose_Mail_Body.Text;
                email.Is_Inbox = true;
                email.Is_Sent = true;
                email.Is_FromUser_Starred = false;
                email.Is_ToUser_Starred = false;
                email.Is_FromUser_Delete = false;
                email.Is_ToUser_Delete = false;
                if (Compose_Mail_File.HasFile)
                {
                    string FileType = Compose_Mail_File.PostedFile.ContentType;
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('has attachment.');", true);
                    byte[] FileByte = Compose_Mail_File.FileBytes;
                    string FileName = Compose_Mail_File.FileName;
                    email.AttachmentName = FileName;
                    email.AttachmentData = FileByte;
                    email.AttachmentType = FileType;
                }
                db.Emails.Add(email);
                db.SaveChanges();
            }
        }

        protected void Compose_Delete_Mail_Click(object sender, EventArgs e)
        {
            Compose_Mail_To.Text = "";
            Compose_Mail_Subject.Text = "";
            Compose_Mail_Body.Text = "";
            Compose_Mail_File = null;
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been deleted successfully.');", true);
        }

    }
}