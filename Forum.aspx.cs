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
    public partial class Forum : System.Web.UI.Page
    {
        MySqlDBHelper sdb = new MySqlDBHelper();

        private void ShowList()
        {
            string sql;
            if (DropDownList1.SelectedIndex == 0)
            {
                sql = string.Format(@"select a.*,b.username, b.fullname, b.profile_picture, b.regsitrationDate  from post a inner join users b
                    on a.Userid= b.Userid  order by a.post_time desc");

            }
            else
            {
                sql = string.Format(@"select a.*,b.username, b.fullname, b.profile_picture, b.regsitrationDate  from post a inner join users b
                    on a.Userid= b.Userid where b.Userid ='{0}'  order by a.post_time desc", Session["uid"]);
            }


            DataTable dt = sdb.ExecuteSqlDataTable(sql);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] != null)
            {
                
                ShowList();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowList();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("New_Post.aspx");
        }
         
    }
}