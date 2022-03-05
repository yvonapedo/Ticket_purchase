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
    public partial class Add_flight : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["uname"] == null)
            {
                Response.Redirect("Admin_login.aspx");
            }
            else
            {

                if (!IsPostBack)
                {

                    DataTable ds = new DataTable();
                    string sql = "SELECT * FROM aircrafts";
                    ds = mdb.ExecuteSqlDataTable(sql);

                    if (ds != null)
                    {
                        DropDownList1.DataSource = ds;
                        DropDownList1.DataMember = "Table";
                        DropDownList1.DataTextField = "MFR";
                        DropDownList1.DataValueField = "AircraftID";
                        DropDownList1.DataBind();
                    }

                    DataTable ds1 = new DataTable();
                    string sql1 = string.Format(@"select a.RouteID, CONCAT(b.city,' - ',b.Country, '  TO ',c.city,' - ',c.Country) as source from routes a
                    INNER JOIN airports b
                        on a.SourceID = b.AirportID
                        INNER JOIN airports c
                        on a.DestinationID = c.AirportID ");

                    ds1 = mdb.ExecuteSqlDataTable(sql1);

                    if (ds1 != null)
                    {
                        DropDownList2.DataSource = ds1;
                        DropDownList2.DataMember = "Table";
                        DropDownList2.DataTextField = "source";
                        DropDownList2.DataValueField = "RouteID";
                        DropDownList2.DataBind();
                    }


                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string flightDay = TxtDate.Text.Trim() + " " + TxtTime.Text.Trim() + ":00";
            string sql = @"INSERT INTO flights VALUES(null, @flightDay , @duration , @seat, @price , @baggage , @num, @aircraft,'Available', @route );";

            //MySqlParameter 
            MySqlParameter[] paras =
           {
                    new MySqlParameter("@flightDay", flightDay),
                    new MySqlParameter("@duration", TxtDuration.Text.Trim()),
                    new MySqlParameter("@price", TxtPrice.Text.Trim()),
                    new MySqlParameter("@seat", TxtSeat.Text.Trim()),
                    new MySqlParameter("@baggage", TxtBaggage.Text.Trim()),
                    new MySqlParameter("@num",  TxtNum.Text.Trim()),
                    new MySqlParameter("@aircraft",  DropDownList1.SelectedValue),
                    new MySqlParameter("@route", DropDownList2.SelectedValue)
                };


            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {

                Response.Write("<script>alert('register successful');</srcipt>");
                Response.Redirect("All_flights.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("All_flights.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TxtDuration.Text = "";
            TxtPrice.Text = "";
            TxtBaggage.Text = "";
            TxtNum.Text = "";
        }
    }
}