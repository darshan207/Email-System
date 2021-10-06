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

        protected void signup_Click(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            User user = new User { uname=username.Text,pass=password.Text};
            db.Users.Add(user);
            db.SaveChanges();

            Response.Redirect("~/Pages/Inbox");
        }
    }
}