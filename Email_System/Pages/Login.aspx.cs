using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;
using Email_System.Pages;

namespace Email_System.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            User u = db.Users.Where(b => b.UserName == Uname.Text).FirstOrDefault();
            if (u == null)
            {
                UserNotExistError.Text = "Requested User Not Exist !";
                //Session["user"] = "You have no email accounts here better fiirst make one;";
                //Response.Redirect("~/Pages/Compose");
            }
            else
            {
                if (u.UserPass.Equals(Pass.Text))
                {
                    Session["user"] = u.UserName;
                    Session["email"] = u.UserEmailId;
                    Response.Redirect("~/Pages/Inbox");
                }
                else
                {
                    LoginFailed.Text = "Login Failed ! Please,Try Again .";
                    Pass.Text = "";
                }
            }
        }
    }
}