using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Email_System
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Label12.Text = (string)Session["user"];
            }
        }

        protected void User_Logged_Out(object sender, EventArgs e)
        {
            Session.Remove("user");
        }
    }
}