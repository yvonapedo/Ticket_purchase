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
    public partial class Admin_FlightDetails : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();

        private void ShowTickets()
        {
            string sql = string.Format(@"select b.fullname,a.ticketID,a.userid,a.flightId,a.quantity,a.price,a.passengertypeID as 'passType',a.seatTypeId as 'seatType',a.confirm,b.PhoneNumber as 'phone', b.gender, b.dob from tickets a inner join users b on 
                                                a.userid=b.userid where a.flightid=@flightid");
            MySqlParameter paras = new MySqlParameter("@flightid", Request.QueryString["ID"].ToString());

            DataTable ds = new DataTable();
            ds = mdb.ExecuteSqlDataTable(sql, paras);

            if (ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

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
                LblSource.Text = dt1.Rows[0][13].ToString();
                LblDestination.Text = dt1.Rows[0][14].ToString();
                LblMFR.Text = dt1.Rows[0][11].ToString();
                LblModel.Text = dt1.Rows[0][12].ToString();

            }

        }

        private int insertNewUser()
        {
            string sql = @"insert into users  
            VALUES(null, @fullname,@username, null, @dob, @gender, null, @phone, null, null, null,  NOW());";

            MySqlParameter[] paras =
            {       new MySqlParameter("@fullname", TxtUser.Text.Trim() ),
                    new MySqlParameter("@username", TxtUser.Text.Trim() ),
                    new MySqlParameter("@dob",  TxtDob.Text.Trim()),
                    new MySqlParameter("@gender", RadioButtonList1.SelectedIndex ),
                    new MySqlParameter("@phone", TxtPhone.Text.Trim())
            };

            int newID = 0;

            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {
                string getID = @"select userID from users where userName = @user_Name and DOB = @dob";

                MySqlParameter[] para = {
                        new MySqlParameter("@user_Name",TxtUser.Text.Trim()),
                         new MySqlParameter("@dob",TxtDob.Text.Trim())
                         };
                 

                newID = Convert.ToInt32(mdb.ExecuteSqlScalar(getID, para));

            }

            return newID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uname"] != null)
            {
                ShowDetail();
                ShowTickets();

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

                }
            }
            else
            {
                Response.Redirect("Admin_login.aspx");
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = @"update  flights set status='cancel' where flightid=@flightId ;";

            MySqlParameter[] paras =
            {       new MySqlParameter("@userid", Session["uid"].ToString() ),
                    new MySqlParameter("@flightId", Request.QueryString["ID"] )
            };

            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {
                Response.Write("<script>alert('FLIGHT CANCELLED');</script>");
            }
        }


        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql = @"insert into tickets 
            VALUES(null, @userid, @flightID, @quantity, null, @PassengerTypeID, @seatTypeID, @confirm);";

            MySqlParameter[] paras =
            {       new MySqlParameter("@userid",  insertNewUser() ),
                    new MySqlParameter("@flightId", Request.QueryString["ID"] ),
                    new MySqlParameter("@quantity",  TxtQuantity.Text.ToString()),
                    new MySqlParameter("@passengerTypeId", DropPassenger.SelectedValue),
                    new MySqlParameter("@confirm", DropConfirm.SelectedValue),
                    new MySqlParameter("@seatTypeId", DropSeat.SelectedValue )
            };

            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {
                //Response.Write("");
                Response.Redirect("All_tickets.aspx");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string update = @"update tickets set quantity=@quantity, passengerTypeID=@passengerTypeId, seatTypeID=@seatTypeId, confirm=@confirm where ticketID=@ticketID ;";

            MySqlParameter[] paras =
           {   
                    new MySqlParameter("@ticketID",LblTicketID.Text.ToString()),
                    new MySqlParameter("@quantity",  TxtQuantity.Text.ToString()),
                    new MySqlParameter("@passengerTypeId",  DropPassenger.SelectedValue),
                    new MySqlParameter("@confirm", DropConfirm.SelectedValue.ToString()),
                    new MySqlParameter("@seatTypeId", DropSeat.SelectedValue)
            };

            if (mdb.ExecuteSqlNonQuery(update, paras) > 0)
            {
                Response.Write("<script>alert('successful');</script>");
                ShowTickets();
            }
            else
            {
                Response.Write("<script>alert('failed');</script>");
            }
        }



        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.Rows[GridView1.SelectedIndex];
            LblTicketID.Text = row.Cells[2].Text;
            TxtUser.Text = row.Cells[1].Text;
            TxtQuantity.Text = row.Cells[5].Text;
            DropPassenger.SelectedValue = row.Cells[7].Text;
            DropSeat.SelectedValue = row.Cells[8].Text;
            DropConfirm.SelectedValue = row.Cells[9].Text;
            //b.PhoneNumber, b.gender, b.dob
            TxtPhone.Text = row.Cells[10].Text;
            RadioButtonList1.SelectedValue = row.Cells[11].Text;
            TxtDob.Text = row.Cells[12].Text;
        }
    }
}