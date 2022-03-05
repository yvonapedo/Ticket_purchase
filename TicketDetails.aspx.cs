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
    public partial class TicketDetails : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();

        private void ShowDetail()
        {
            string sql = @"SELECT a.FullName, b.ticketId, c.flightDate, c.duration, b.price, c.flightNum,
                            concat(h.City,' - ', h.Country ) as source, concat(e.City,' - ',  e.Country ) as destination, g.model, g.mfr, 
                            f.passengerType, i.seattype, b.quantity, b.confirm
                            from
                            users a inner join
                            tickets b on a.UserID=b.userid 
                            inner join
                            flights c on c.flightID=b.flightID 
                            inner join
                            routes d on c.routeID=d.RouteID
                            inner join
                            airports e on e.airportid=d.DestinationID 
                             inner join
                            airports h on h.airportid=d.SourceID 
                             inner join
                            aircrafts g on g.AircraftID=c.AircraftID 
                             inner join
                            passengertypes f on f.PassengerTypeID=b.PassengerTypeID 
                            inner join
                            seattypes i on i.seatTypeID=b.seatTypeID 												 
							                            WHERE b.ticketId=@ticketid";

            MySqlParameter[] paras =
             {
                    new MySqlParameter("@ticketId", Request.QueryString["ID"] )
            };
            DataTable dt1 = mdb.ExecuteSqlDataTable(sql, paras);

            if (dt1 != null)
            {
                LblName.Text = dt1.Rows[0][0].ToString();
                LblTicketID.Text = dt1.Rows[0][1].ToString();
                LblDate.Text = dt1.Rows[0][2].ToString();
                LblDuration.Text = dt1.Rows[0][3].ToString();
                LblNum.Text = dt1.Rows[0][5].ToString();
                LblSource.Text = dt1.Rows[0][6].ToString();
                LblDestination.Text = dt1.Rows[0][7].ToString();
                LblMFR.Text = dt1.Rows[0][8].ToString();
                LblModel.Text = dt1.Rows[0][9].ToString();
                LblPassType.Text = dt1.Rows[0][10].ToString();
                LblSeat.Text = dt1.Rows[0][11].ToString();
                LblQuantity.Text = dt1.Rows[0][12].ToString();
                LblConfirm.Text = dt1.Rows[0][13].ToString();
                LblAmount.Text = dt1.Rows[0][4].ToString();

            }

        }
        private bool checkCancel()
        {
            string sql = @"select confirm from tickets  where ticketID=@ticketID;";

            MySqlParameter[] paras =
            {       new MySqlParameter("@ticketID", LblTicketID.Text )

            };

            if (Convert.ToString(mdb.ExecuteSqlScalar(sql, paras)) == "cancel")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool saveCancel()
        {
            string sql = @"select confirm from tickets  where ticketID=@ticketID;";

            MySqlParameter[] paras =
            {       new MySqlParameter("@ticketID", LblTicketID.Text )

            };

            if (Convert.ToString(mdb.ExecuteSqlScalar(sql, paras)) == "saved")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["uname"] != null)
            {
                ShowDetail();
                if (checkCancel())
                {
                    Button2.Visible = false;
                }
                if (saveCancel())
                {
                    Button1.Visible = false;
                }
            }
            else
            {

                Response.Redirect("Login.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = @"update tickets set confirm='cancel' where ticketID=@ticketID;";

            MySqlParameter[] paras =
            {       new MySqlParameter("@ticketID", LblTicketID.Text )
                     
            };
          
                if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
                {
                    //Response.Write("");
                    Response.Redirect("MyTickets.aspx");
                }
             
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = @"update tickets set confirm='confirmed' where ticketID=@ticketID;";

            MySqlParameter[] paras =
            {       new MySqlParameter("@ticketID", LblTicketID.Text )

            };

            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {
                //Response.Write("");
                Response.Redirect("MyTickets.aspx");
            }

        }
    }
}