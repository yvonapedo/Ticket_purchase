using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text.Trim() != TextBox3.Text.Trim())
            {
                Response.Write("<script>alert('Confirm pwd is not same as the 1st'); </script>");
            }
            else
            {
                string sql =  @"select count(*) from users where username=@uname and  password=@password";
                MySqlParameter[] paras =
                        {
                         new MySqlParameter("@uname", Session["uname"].ToString() ),
                         new MySqlParameter("@password", TextBox1.Text.Trim() )
                         };


                int number = Convert.ToInt32(mdb.ExecuteSqlScalar(sql, paras));

                if (number <= 0)
                {
                    Response.Write("<script>alert('The old password is wrong'); </script>");
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                }
                else
                {
                    string change =  @" update users set  password=@password where username=@uname " ;

                     
                    MySqlParameter[] paras1 =
                            {
                         new MySqlParameter("@uname", Session["uname"].ToString()),
                         new MySqlParameter("@password", TextBox2.Text.Trim() )
                         };
                    if (mdb.ExecuteSqlNonQuery(change, paras1) > 0)
                    {
                        Response.Write("<script>alert('Successful, REMEMBER YOUR NEW PASSWORD');window.location.href('Login.aspx');</script>");
                        //Response.Write("<script>alert('Successful, REMEMBER YOUR NEW PASSWORD'); </script>");
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }
    }
}