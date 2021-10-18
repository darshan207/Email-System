using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;
using Email_System.Pages;

namespace Email_System
{
    public partial class Login : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void l_click(Object sender,EventArgs e)
        {
            Response.Redirect("~/Pages/Login.aspx");
        }

        protected void s_click(Object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/SignUp.aspx");
        }

        /*
        protected void Signup_Click(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            User u = db.Users.Where(b => b.UserName == username.Text).FirstOrDefault();
            if (u == null)
            {

                User user = new User { UserName = username.Text, UserPass = password.Text ,UserEmailId=username.Text + "@email.com"};
                db.Users.Add(user);
                db.SaveChanges();
                Session["user"] = user.UserName;
                Response.Redirect("~/Pages/Inbox");
            }
            else
            {
                UserIsExistError.Text = "User Is already exist in Database !";
                password.Text = "";
                c_password.Text = "";
                //Response.Redirect("~/");
            }
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
                if(u.UserPass.Equals(Pass.Text))
                {
                    Session["user"] = u.UserName;
                    Response.Redirect("~/Pages/Inbox");
                }
                else
                {
                    LoginFailed.Text = "Login Failed ! Please,Try Again .";
                    Pass.Text = "";
                }
            }
        }
        */
    }
}