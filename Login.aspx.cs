using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system
{
    public partial class Login : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string sql = string.Format(@"select count(*) from users where username= '{0}' and password='{1}'", TextBox1.Text.Trim(), TextBox2.Text.Trim());
            string sql1 =  @"select userID from users where username= @username and password=@pwd;";

            MySqlParameter[] paras =
              {
                    new MySqlParameter("@username", TxtUsername.Text.Trim()),
                    new MySqlParameter("@pwd", TxtPassword.Text.Trim())
            };

            int id = Convert.ToInt32(mdb.ExecuteSqlScalar(sql1, paras));
            if (id <=0)
            {
                Response.Redirect("Register.aspx");
            }
            else
            {
                Session["uid"] = id;
                Session["uname"] = TxtUsername.Text.Trim();
                Response.Redirect("Homepage.aspx");
            }
        }
    }
}