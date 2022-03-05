using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ticket_purchase_system.Captcha
{
    public partial class CaptchaPicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Captcha c = new Captcha();
                string code = c.CreateCode(6);
                c.CreateImageOnPage(code, Context);
                Session["checkCode"] = code;
            }
        }
    }
}