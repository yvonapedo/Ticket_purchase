using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system
{
    public partial class New_Post : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = Session["uname"].ToString();
            string sql = string.Format(@"select * from users where userID='{0}'", Session["uid"].ToString());
            Button1.Enabled = false;

            DataTable dt = mdb.ExecuteSqlDataTable(sql);
            if (dt != null)
            {
                Image1.ImageUrl = dt.Rows[0][10].ToString();
                Label2.Text = dt.Rows[0][11].ToString();
                Label1.Text = dt.Rows[0][2].ToString();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forum.apsx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Response.Redirect("Login.apsx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                Response.Write("<script>alert('You must input a message');</script>");
            }
            else
            {
                string sql = @"insert into post values(null, @userid, @postSubject, @postContent,  NOW(),@ipAddress)";

                MySqlParameter[] paras =
              {
                    new MySqlParameter("@userid",  Session["uid"].ToString()),
                    new MySqlParameter("@postSubject", TextBox1.Text.Trim()),
                    new MySqlParameter("@postContent", TextBox2.Text.Trim()),
                    new MySqlParameter("@ipAddress", Request.UserHostAddress.ToString())
                };

                if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
                {
                    //Response.Write("<script>alert('Successful');window.location.href('Forum.aspx');</script>");
                    Response.Redirect("Forum.aspx");
                }
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
            }
        }
    }
}