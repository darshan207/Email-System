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
        private string UserEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["email"] == null){
                Response.Redirect("~/");
            }
            UserEmail = (string)Session["email"];
        }

        protected void StarMail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            id = int.Parse(btn.CommandArgument.ToString());
            EmailDbContext db = new EmailDbContext();
            email = db.Emails.Where(b => b.Id == id).FirstOrDefault();
            if (email.ToUserEmailId == UserEmail)
            {
                if (email.Is_ToUser_Starred == true)
                {
                    email.Is_ToUser_Starred = false;
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been Unstarred.');", true);
                }
                else
                {
                    email.Is_ToUser_Starred = true;
                    email.Is_Inbox = true;
                    email.Is_ToUser_Delete = false;
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been Starred.');", true);
                }
                db.SaveChanges();
            }
            Response.Redirect("~/Pages/Inbox");
        }

        protected void DeleteMail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            id = int.Parse(btn.CommandArgument.ToString());
            EmailDbContext db = new EmailDbContext();
            email = db.Emails.Where(b => b.Id == id).FirstOrDefault();
            if (email.ToUserEmailId == UserEmail)
            {
                email.Is_ToUser_Delete = true;
                email.Is_ToUser_Starred = false;
                email.Is_Inbox = false;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been deleted.');", true);
                db.SaveChanges();
            }
            Response.Redirect("~/Pages/Inbox");
        }

        protected void ViewMail_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            id = int.Parse(btn.CommandArgument.ToString());
            Session["ViewMailId"] = id;
            Response.Redirect("~/Pages/ViewMail");
        }
    }
}