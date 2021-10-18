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
    public partial class Inbox : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Session["email"] == null){
                Response.Redirect("~/");
            }
            Label1.Text = (string)Session["user"];
            Label2.Text = (string)Session["email"];
            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        private void BindGrid()
        {
            EmailDbContext db = new EmailDbContext();
            string user = Session["user"].ToString();
            User ToUser = db.Users.Where(b => b.UserName == user).FirstOrDefault();
            int ToUserId = ToUser.Id;
            string constr = ConfigurationManager.ConnectionStrings["emaildb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select Id, AttachmentName from Emails where ToUserId =" + ToUserId + " AND AttachmentName !='NULL'";
                    cmd.Connection = con;
                    con.Open();
                    GridView1.DataSource = cmd.ExecuteReader();
                    GridView1.DataBind();
                    con.Close();
                }
            }
        }
        protected void DownloadFile(object sender, EventArgs e)
        {
            int id = int.Parse((sender as LinkButton).CommandArgument);
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
    }
}