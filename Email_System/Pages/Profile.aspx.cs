using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;

namespace Email_System.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            string username = Session["user"].ToString();
            User u = db.Users.Where(b => b.UserName == username).FirstOrDefault();
            uname.Text = u.UserName.ToString();
            email.Text = u.UserEmailId.ToString();
            userid.Text = u.Id.ToString();
            fname.Text = u.UserFirstName.ToString();
            lname.Text = u.UserLastName.ToString();
            dob.Text = u.DOB.ToString();
        }
        protected void passChange_Click(object sender, EventArgs e)
        {
            EmailDbContext db1 = new EmailDbContext();
            string s = Session["user"].ToString();
            User user = db1.Users.Where(b => b.UserName == s).FirstOrDefault();

            user.UserPass = password.Text;
            db1.SaveChanges();
        }
    }
}