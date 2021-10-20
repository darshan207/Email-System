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
    public partial class SignUp : System.Web.UI.Page
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

                User user = new User { UserName = username.Text, UserFirstName=fname.Text, UserLastName=lname.Text, DOB=DateTime.Parse(dob.Text), UserPass = password.Text, UserEmailId = username.Text + "@email.com" };
                db.Users.Add(user);
                db.SaveChanges();
                Session["user"] = user.UserName;
                Session["email"] = user.UserEmailId;
                Response.Redirect("~/Pages/Inbox");
            }
            else
            {
                UserIsExistError.Text = "User Is already exist !";
                password.Text = "";
                c_password.Text = "";
                //Response.Redirect("~/");
            }
        }
    }
}