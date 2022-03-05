using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system.Admin
{
    public partial class Admin_login : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string sql1 = string.Format(@"select adminID from admin where username= '{0}' and password='{1}'", TxtUsername.Text.Trim(), TxtPassword.Text.Trim());


            string sql1 = @"select adminID from admin where username= @username and password=@pwd;";

            MySqlParameter[] paras =
              {
                    new MySqlParameter("@username", TxtUsername.Text.Trim()),
                    new MySqlParameter("@pwd", TxtPassword.Text.Trim())
            };

            int id = Convert.ToInt32(mdb.ExecuteSqlScalar(sql1,paras));
            if (id <= 0)
            {
                Response.Redirect("Admin_login.aspx");
            }
            else
            {
                Session["uid"] = id;
                Session["uname"] = TxtUsername.Text.Trim();
                Response.Redirect("All_flights.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}