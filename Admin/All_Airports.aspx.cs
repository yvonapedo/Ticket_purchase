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
    public partial class All_Airports : System.Web.UI.Page
    {
        static int number = 1, page_size;
        static string table = "airports", order = "AirportID";
        MySqlDBHelper sdb = new MySqlDBHelper();

        /// <summary>
        /// Total pages
        /// </summary>
        /// <param name="size">records per page</param>
        /// <returns></returns>
        private int Count(int size)
        {
            MySqlParameter[] paras = {
            new MySqlParameter("?number",size),
            new MySqlParameter("?summary",MySqlDbType.Int32)
        };
            paras[1].Direction = ParameterDirection.Output;
            sdb.ExecuteProcScalar("Pro_Pagecount", paras);
            return Convert.ToInt32(paras[1].Value);
        }

        /// <summary>
        /// call procedure
        /// </summary>
        /// <param name="size"></param>
        /// <param name="num"></param>
        /// <param name="table"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private DataTable pageN(int size, int num, string table, string order)
        {
            MySqlParameter[] paras = {
            new MySqlParameter("?page_size",num),
            new MySqlParameter("?number",size),
            new MySqlParameter("?tablename",table),
            new MySqlParameter("?ordercolumn",order)
        };
            return sdb.ExecuteProcedureDataTable("Pro_Pagenation", paras);
        }

        private void SelectPage(int size, int num, string table, string order)
        {
            DataTable dt = pageN(size, num, table, order);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            Label2.Text = Count(num).ToString();

            Label1.Text = size.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                page_size = Convert.ToInt32(TextBox2.Text);
                SelectPage(number, page_size, table, order);
                LinkButton3.Enabled = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            number = 1;
            SelectPage(number, page_size, table, order);
            LinkButton3.Enabled = false;
            LinkButton4.Enabled = true;
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            number = Count(page_size);
            SelectPage(number, page_size, table, order);
            LinkButton4.Enabled = false;
            LinkButton3.Enabled = true;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            ++number;
            SelectPage(number, page_size, table, order);
            LinkButton3.Enabled = true;
            if (number >= Count(page_size) - 1)
            {
                LinkButton4.Enabled = false;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            --number;
            SelectPage(number, page_size, table, order);
            LinkButton4.Enabled = true;
            if (number <= 1)
            {
                LinkButton3.Enabled = false;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try
            {
                number = Convert.ToInt32(TextBox1.Text);
                SelectPage(number, page_size, table, order);
            }
            catch (Exception)
            {
                Response.Write("<script>alert('it is not interger');</script>");
                TextBox1.Text = "";
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                page_size = Convert.ToInt32(TextBox2.Text);
            }
            catch
            {

            }
        }
    }
}
