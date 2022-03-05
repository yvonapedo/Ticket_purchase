using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ticket_purchase_system.Static
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["uname"].ToString();

        }


        protected void AdRotator2_AdCreated(object sender, AdCreatedEventArgs e)
        {

        }
    }
}
