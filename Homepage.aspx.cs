using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ticket_purchase_system
{
    public partial class Homepage : System.Web.UI.Page
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
                                or b.destinationid=@destination 
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
        private void QuerySource()
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

        private void QueryDestination()
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
                            where b.DestinationID=@destination  
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
        private void QueryDate()
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
                            where a.flightDate  LIKE '%@flightDate%'
							 order by a.flightid desc");
           
            MySqlParameter[] paras ={
                new MySqlParameter("@source", DropSource.SelectedValue),
                            new MySqlParameter("@destination", DropDestination.SelectedValue),
                             new MySqlParameter("@flightDate", TextBox1.Text.Trim())
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
                 
                if (!IsPostBack)
                {
                    string todayDate = DateTime.Now.ToString();
                    TextBox1.Text = todayDate;

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
                Response.Redirect("Login.aspx");
            }
        }

        protected void DropSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDestination.SelectedIndex >=0)
            {
                QuerySource();
              
            }
            else
            {
                QueryFlight();
            }

        }

        protected void DropDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDestination.SelectedIndex >= 0)
            {
                QueryDestination();

            }
            else
            {
                QueryFlight();
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            QueryDate();
        }
    }
}