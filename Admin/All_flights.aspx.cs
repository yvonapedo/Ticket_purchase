using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ticket_purchase_system.Admin
{
    public partial class All_flights : System.Web.UI.Page
    {

        MySqlDBHelper sdb = new MySqlDBHelper();

        private void QueryFlight()
        {
            string sql;
            sql = string.Format(@"SELECT a.* , b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
							INNER JOIN airports e
                             on e.Airportid=b.DestinationID	 	
                            where b.sourceid=@source 
                                AND b.destinationid=@destination 
							 order by a.flightid desc");


            MySqlParameter[] paras ={
                new MySqlParameter("@source", DropSource.SelectedValue),
                            new MySqlParameter("@destination", DropDestination.SelectedValue)
                 };
            DataTable dt = sdb.ExecuteSqlDataTable(sql, paras);
            if (dt != null)
            {
                DataList1.DataSource = dt;
                DataList1.DataBind();
            }
        }

        private void ShowList()
        {
            string sql;
            sql = string.Format(@"SELECT a.* , b.SourceID, b.DestinationID, c.MFR, c.MODEL, concat(d.City,' - ', d.Country ) as source, concat(e.City,' - ',  e.Country ) as destination FROM  routes b 
                             INNER JOIN flights a  
                             on a.routeID=b.RouteID
                             INNER JOIN aircrafts c  
                             on a.AircraftID=c.AircraftID
                             INNER JOIN airports d 
                             on d.Airportid=b.sourceid 
							INNER JOIN airports e
                             on e.Airportid=b.DestinationID	 
							 order by a.flightid desc");


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

                if (!IsPostBack)
                {
                    DataTable ds = new DataTable();
                    string sql = "SELECT * FROM airports order by city";
                    ds = sdb.ExecuteSqlDataTable(sql);

                    if (ds != null)
                    {
                        DropSource.DataSource = ds;
                        DropSource.DataMember = "Table";
                        DropSource.DataTextField = "city";
                        DropSource.DataValueField = "AirportId";
                        DropSource.DataBind();
                    }


                    DataTable dt = new DataTable();
                    string sql1 = "SELECT * FROM airports order by city";
                    dt = sdb.ExecuteSqlDataTable(sql1);

                    if (dt != null)
                    {
                        DropDestination.DataSource = dt;
                        DropDestination.DataMember = "Table";
                        DropDestination.DataTextField = "city";
                        DropDestination.DataValueField = "AirportId";
                        DropDestination.DataBind();
                    }
                }

                ShowList();
            }
            else
            {
                Response.Redirect("Admin_login.aspx");
            }
        }

        protected void DropSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryFlight();
        }

        protected void DropDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryFlight();
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Add_flight.aspx");
        }
    }
}