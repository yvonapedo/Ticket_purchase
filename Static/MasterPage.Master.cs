using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system.Static
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql1 = @"select username from users where userid=@userid;";

            MySqlParameter[] paras =
              {
                     new MySqlParameter("@userid", Session["uid"].ToString() )
            };

            string name = Convert.ToString(mdb.ExecuteSqlScalar(sql1, paras));
            if (name != "")
            {
                Label1.Text = name;
            }
            //Label1.Text = Session["uname"].ToString();

        }
         

        protected void AdRotator2_AdCreated(object sender, AdCreatedEventArgs e)
        {

        }
    }
}