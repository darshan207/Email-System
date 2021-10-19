using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;

namespace Email_System.Pages
{
    public partial class Inbox : Page
    {
        private int id;
        private Email email;
        private string UserName;
        private string UserEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["email"] == null){
                Response.Redirect("~/");
            }
            UserName = (string)Session["user"];
            UserEmail = (string)Session["email"];
        }

        protected void StarMail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            id = int.Parse(btn.CommandArgument.ToString());
            EmailDbContext db = new EmailDbContext();
            email = db.Emails.Where(b => b.Id == id).FirstOrDefault();
            if (email.FromUserEmailId == UserEmail)
            {
                if (email.Is_FromUser_Starred == true)
                {
                    email.Is_FromUser_Starred = false;
                }
                else
                {
                    email.Is_FromUser_Starred = true;
                    email.Is_Sent = true;
                    email.Is_FromUser_Delete = false;
                }
            }
            else if (email.ToUserEmailId == UserEmail)
            {
                if (email.Is_ToUser_Starred == true)
                {
                    email.Is_ToUser_Starred = false;
                }
                else
                {
                    email.Is_ToUser_Starred = true;
                    email.Is_Inbox = true;
                    email.Is_ToUser_Delete = false;
                }
            }
            db.SaveChanges();
            Response.Redirect("~/Pages/Inbox");
        }

        protected void DeleteMail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            id = int.Parse(btn.CommandArgument.ToString());
            EmailDbContext db = new EmailDbContext();
            email = db.Emails.Where(b => b.Id == id).FirstOrDefault();
            if (email.FromUserEmailId == UserEmail)
            {
                email.Is_FromUser_Delete = true;
                email.Is_Sent = false;
                email.Is_FromUser_Starred = false;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been deleted.');", true);
            }
            else if (email.ToUserEmailId == UserEmail)
            {
                email.Is_ToUser_Delete = true;
                email.Is_ToUser_Starred = false;
                email.Is_Inbox = false;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been deleted.');", true);
            }
            db.SaveChanges();
            Response.Redirect("~/Pages/Inbox");
        }
    }
}