using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Email_System.Models;

namespace Email_System.Pages
{
    public partial class ViewMail : System.Web.UI.Page
    {
        private int id;
        private User FromUser;
        private Email email;
        private string UserName;
        private string UserEmail;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["email"] == null)
            {
                Response.Redirect("~/");
            }
            UserName = (string)Session["user"];
            UserEmail = (string)Session["email"];
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("~/Pages/Inbox");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["Id"]);
                EmailDbContext db = new EmailDbContext();
                email = db.Emails.Where(b => b.Id == id).FirstOrDefault();
                FromUser = db.Users.Where(b => b.UserEmailId == email.FromUserEmailId).FirstOrDefault();
                Mail_From_User.Text = FromUser.UserFirstName + " " + FromUser.UserLastName;
                Mail_From_User_Email.Text = FromUser.UserEmailId;
                Mail_Subject.Text = email.EmailSubject;
                Mail_Body.Text = email.EmailText;
                if (email.AttachmentName == null)
                {
                    Mail_File.Text = "No File";
                }
                else
                {
                    Mail_File.Text = email.AttachmentName;
                }
            }
        }
        protected void Mail_File_Download_Click(object sender, EventArgs r)
        {
            if (email.AttachmentName == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Has not any attachment.');", true);
                return;
            }
            byte[] filebytes;
            string fileName, fileType;
            string constr = ConfigurationManager.ConnectionStrings["emaildb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select AttachmentName,AttachmentType, AttachmentData from Emails where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        filebytes = (byte[])sdr["AttachmentData"];
                        fileType = sdr["AttachmentType"].ToString();
                        fileName = sdr["AttachmentName"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = fileType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(filebytes);
            Response.Flush();
            Response.End();
        }

        protected void Delete_Mail_Click(object sender, EventArgs e)
        {
            EmailDbContext db = new EmailDbContext();
            email = db.Emails.Where(b => b.Id == id).FirstOrDefault();
            if (email.FromUserEmailId == UserEmail)
            {
                email.Is_FromUser_Delete = true;
                email.Is_Sent = false;
                email.Is_FromUser_Starred = false;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been deleted.');", true);
            }
            else if (email.ToUserEmailId == UserEmail)
            {
                email.Is_ToUser_Delete = true;
                email.Is_ToUser_Starred = false;
                email.Is_Inbox = false;
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email has been deleted.');", true);
            }
            db.SaveChanges();
            Response.Redirect("~/Pages/Inbox");
        }
    }
}