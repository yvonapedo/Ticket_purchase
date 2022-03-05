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
    public partial class All_tickets : System.Web.UI.Page
    {
        MySqlDBHelper sdb = new MySqlDBHelper();

        private void ShowSaved()
        {
            string sql = string.Format(@"SELECT g.username, a.* ,f.ticketID, f.quantity,  b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
														INNER JOIN airports e
                             on e.Airportid=b.DestinationID
													INNER JOIN tickets f
                             on f.flightId=a.flightId
                            INNER JOIN users g 
                             on g.userid=f.userid 
                        where f.confirm ='saved' order by f.ticketID desc");



            DataTable dt = sdb.ExecuteSqlDataTable(sql);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
        private void ShowBuy()
        {
            string sql = string.Format(@"SELECT g.username, a.* ,f.ticketID, f.quantity,  b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
														INNER JOIN airports e
                             on e.Airportid=b.DestinationID
													INNER JOIN tickets f
                             on f.flightId=a.flightId
                            INNER JOIN users g 
                             on g.userid=f.userid 
                where   f.confirm ='confirmed' order by f.ticketID desc	 ");



            DataTable dt = sdb.ExecuteSqlDataTable(sql);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }

        private void ShowCancel()
        {
            string sql = string.Format(@"SELECT g.username, a.* ,f.ticketID, f.quantity,  b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
														INNER JOIN airports e
                             on e.Airportid=b.DestinationID
													INNER JOIN tickets f
                             on f.flightId=a.flightId
                            INNER JOIN users g 
                             on g.userid=f.userid 
                where   f.confirm ='cancel' order by f.ticketID desc	 ");



            DataTable dt = sdb.ExecuteSqlDataTable(sql);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }

        private void ShowList()
        {
            string sql;

            sql = string.Format(@"SELECT g.username, a.* ,f.ticketID, f.quantity,  b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
														INNER JOIN airports e
                             on e.Airportid=b.DestinationID
													INNER JOIN tickets f
                             on f.flightId=a.flightId
                            INNER JOIN users g
                             on g.userid=f.userid order by f.ticketID desc");


            DataTable dt = sdb.ExecuteSqlDataTable(sql);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["uid"] != null)
            {
                //Label1.Text = Session["uid"].ToString() + "||" + Session["uname"].ToString();
                ShowList();
            }
            else
            {
                Response.Redirect("Admin_login.aspx");
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowList();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ShowSaved();
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            ShowBuy();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            ShowCancel();
        }
    }
}