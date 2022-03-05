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
    public partial class Post_Details : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();

        private void ShowDetail()
        {
            string sql = string.Format(@"select a.*, b.Post_Time, b.Post_Subject, b.Post_Content from users a inner join post b 
                  on a.userid = b.userid
                where Post_ID='{0}'", Request.QueryString["ID"]);


            string sql2 = string.Format(@"select   a.UserName, b.* from users a inner join reply b 
                  on a.userid = b.userid
            where Post_ID='{0}'", Request.QueryString["ID"]);

            DataTable dt1 = mdb.ExecuteSqlDataTable(sql);

            if (dt1 != null)
            {
                Label1.Text = dt1.Rows[0][1].ToString();
                Image1.ImageUrl = dt1.Rows[0][10].ToString(); 

                Label3.Text = dt1.Rows[0]["Post_subject"].ToString();
                Label4.Text = dt1.Rows[0]["Post_Time"].ToString();
                Label5.Text = dt1.Rows[0]["Post_Content"].ToString();
                //Label2.Text = dt1.Rows[0][5].ToString();

            }

            DataTable dt2 = mdb.ExecuteSqlDataTable(sql2);
            if (dt2 != null)
            {
                DataList1.DataSource = dt2;
                DataList1.DataBind();
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Enabled = false;
            if (Session["uname"] != null)
            {
                ShowDetail();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


        }

        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CheckBox1.Checked == true)
        //    {
        //        Button1.Enabled = true;
        //    }
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format(@"insert into reply
                    values(null,'{0}','{1}','{2}',NOW(),'{3}')", Request.QueryString["ID"], TextBox1.Text, TextBox2.Text, Session["uid"].ToString());


            if (mdb.ExecuteSqlNonQuery(sql) > 0)
            {
                //Response.Write("<script>alert('reply successful')</srcipt>");
                ShowDetail();
                TextBox1.Text = "";
                TextBox2.Text = "";

            }
        }
    }
}