using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Email_System.Pages
{
    public partial class Inbox : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["email"] == null){
                Response.Redirect("~/");
            }
            Label1.Text = (string)Session["user"];
            Label2.Text = (string)Session["email"];
        }
    }
}