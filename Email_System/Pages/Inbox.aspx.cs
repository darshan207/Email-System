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
            Label1.Text = (string)Application["user"];
        }
    }
}