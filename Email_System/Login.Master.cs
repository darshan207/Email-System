using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;

namespace Email_System
{
    public partial class Login : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            User u = db.Users.Where(b => b.UserName == username.Text).FirstOrDefault();
            if (u == null)
            {
                User user = new User { UserName = username.Text, UserPass = password.Text };
                db.Users.Add(user);
                db.SaveChanges();
                Session["user"] = user.UserName;
                Response.Redirect("~/Pages/Inbox");
            }
            else
            {
                Response.Redirect("~/");
            }
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            User u = db.Users.Where(b => b.UserName == TextBox1.Text).FirstOrDefault();
            if (u == null)
            {
                Application["user"] = "You have no email accounts here better fiirst make one;";
            }
        }
    }
}