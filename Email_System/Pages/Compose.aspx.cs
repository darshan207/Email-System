using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Email_System.Pages
{
    public partial class Compose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Compose_Send_Mail_Click(object sender, EventArgs e)
        {

        }

        protected void Compose_Delete_Mail_Click(object sender, EventArgs e)
        {
            Compose_Mail_To.Text = "";
            Compose_Mail_Subject.Text = "";
            Compose_Mail_Body.Text = "";
            Compose_Mail_File = null;
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Message has been deleted successfully.');", true);
        }
    }
}