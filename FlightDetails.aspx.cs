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
    public partial class FlightDetails : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();

        private void ShowDetail()
        {
            string sql = @"SELECT a.* , b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
							INNER JOIN airports e
                             on e.Airportid=b.DestinationID													 
							WHERE a.flightID=@flightId";

            MySqlParameter[] paras =
             {
                    new MySqlParameter("@flightId", Request.QueryString["ID"] )
            };
            DataTable dt1 = mdb.ExecuteSqlDataTable(sql, paras);

            if (dt1 != null)
            {
                LblDate.Text = dt1.Rows[0][1].ToString();
                LblDuration.Text = dt1.Rows[0][2].ToString();
                LblPrice.Text = dt1.Rows[0][4].ToString();
                LblBaggage.Text = dt1.Rows[0][5].ToString();
                LblSeat.Text = dt1.Rows[0][3].ToString();
                LblNum.Text = dt1.Rows[0][6].ToString();
                LblSource.Text = dt1.Rows[0][14].ToString();
                LblDestination.Text = dt1.Rows[0][15].ToString();
                LblMFR.Text = dt1.Rows[0][11].ToString();
                LblModel.Text = dt1.Rows[0][12].ToString();

            }

        }


        /// <summary>
        /// calculating the price of the flight
        /// </summary>
        private void GetPrice()
        {
            string sql = @"select a.price* b.Discount* c.increment 
                            from flights a , passengertypes b, seattypes c 
                            where a.flightID=@flightId and b.PassengerTypeID=@passengerTypeId and c.seatTypeID=@seatTypeId";

            DataTable dt = new DataTable();

            MySqlParameter[] paras =
            {
                    new MySqlParameter("@flightId", Request.QueryString["ID"] ),
                    new MySqlParameter("@passengerTypeId", DropPassenger.SelectedValue),
                    new MySqlParameter("@seatTypeId", DropSeat.SelectedValue )
            };
            dt = mdb.ExecuteSqlDataTable(sql, paras);
            if (dt != null)
            {
                double price = Convert.ToDouble(dt.Rows[0][0].ToString()) * Convert.ToInt32(TxtQuantity.Text); ;
                LblAmount.Text = price.ToString();

            }
        }

        private bool checkQuantity()
        {
            string sql = @"select seat
                            from flights 
                            where flightID=@flightId ";



            MySqlParameter[] paras =
            {
                    new MySqlParameter("@flightId", Request.QueryString["ID"] )
            };
            int seat = Convert.ToInt32(mdb.ExecuteSqlScalar(sql, paras));
            if (seat > Convert.ToInt32(TxtQuantity.Text))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private bool checkCancel()
        {
            string sql = @"select Status from flights  where flightID=@flightID;";

            MySqlParameter[] paras =
            {       new MySqlParameter("@flightID",  Request.QueryString["ID"] )

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

        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (Session["uname"] != null)
            {
                ShowDetail();


                if (!IsPostBack)
                {

                    DataTable ds = new DataTable();
                    string sql = "SELECT * FROM PassengerTypes";
                    ds = mdb.ExecuteSqlDataTable(sql);

                    if (ds != null)
                    {
                        DropPassenger.DataSource = ds;
                        DropPassenger.DataMember = "Table";
                        DropPassenger.DataTextField = "PassengerType";
                        DropPassenger.DataValueField = "PassengerTypeID";
                        DropPassenger.DataBind();
                    }

                    DataTable ds1 = new DataTable();
                    string sql1 = @"select * from seattypes";

                    ds1 = mdb.ExecuteSqlDataTable(sql1);

                    if (ds1 != null)
                    {
                        DropSeat.DataSource = ds1;
                        DropSeat.DataMember = "Table";
                        DropSeat.DataTextField = "seatType";
                        DropSeat.DataValueField = "seatTypeID";
                        DropSeat.DataBind();
                        GetPrice();
                    }

                    if (checkCancel())
                    {
                        Button1.Visible = false;
                        Button2.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            GetPrice();
        }


        protected void DropPassenger_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice();
        }

        protected void DropSeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice();
        }


        /// <summary>
        /// BUY TICKET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = @"insert into tickets 
            VALUES(null, @userid, @flightID, @quantity, @price, @PassengerTypeID, @seatTypeID, 'confirmed');";

            MySqlParameter[] paras =
            {       new MySqlParameter("@userid", Session["uid"].ToString() ),
                    new MySqlParameter("@flightId", Request.QueryString["ID"] ),
                    new MySqlParameter("@quantity",  TxtQuantity.Text.ToString()),
                    new MySqlParameter("@price", LblAmount.Text.ToString() ),
                    new MySqlParameter("@passengerTypeId", DropPassenger.SelectedValue),
                    new MySqlParameter("@seatTypeId", DropSeat.SelectedValue )
            };

            if (checkQuantity())
            {
                if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
                {  
                    Response.Redirect("MyTickets.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Insufficient');</script>");
            }

        }


        /// <summary>
        /// RESERVATION: save ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = @"insert into tickets 
            VALUES(null, @userid, @flightID, @quantity, @price, @PassengerTypeID, @seatTypeID, 'saved');";

            MySqlParameter[] paras =
            {       new MySqlParameter("@userid", Session["uid"].ToString() ),
                    new MySqlParameter("@flightId", Request.QueryString["ID"] ),
                    new MySqlParameter("@quantity",  TxtQuantity.Text.ToString()),
                    new MySqlParameter("@price", LblAmount.Text.ToString() ),
                    new MySqlParameter("@passengerTypeId", DropPassenger.SelectedValue),
                    new MySqlParameter("@seatTypeId", DropSeat.SelectedValue )
            };

            if (checkQuantity())
            {
                if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
                {
                    Response.Write("<script>alert('Ticket reservation SUCCESSFULL');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Insufficient');</script>");
            }

        }
    }
}