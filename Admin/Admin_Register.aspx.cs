using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system.Admin
{
    public partial class Admin_Register : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO admin VALUES(null,  @username , @pwd );";

            MySqlParameter[] paras =
                {
                    new MySqlParameter("@username", TxtUsername.Text.Trim()),
                    new MySqlParameter("@pwd", TxtPassword.Text.Trim()),
                };


            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {
                Response.Write("<script>alert('register successful');</srcipt>");
                Response.Redirect("Admin_login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_login.aspx");
        }
    }
}