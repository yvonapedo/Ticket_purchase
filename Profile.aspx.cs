using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;


namespace ticket_purchase_system
{
    public partial class Profile : System.Web.UI.Page
    {
        MySqlDBHelper mdb = new MySqlDBHelper();
        private void ShowProfile()
        {
            string sql = @"SELECT * from users WHERE userid=@userid";

            MySqlParameter[] paras =
             {
                    new MySqlParameter("@userid", Session["uid"].ToString() )
            };
            DataTable dt1 = mdb.ExecuteSqlDataTable(sql, paras);

            if (dt1 != null)
            {
                TxtFullName.Text = dt1.Rows[0][1].ToString();
                TxtUsername.Text = dt1.Rows[0][2].ToString();
                //TxtDob.Text = dt1.Rows[0][4].ToString();
                RadioButtonList1.SelectedIndex = Convert.ToInt32( dt1.Rows[0][5].ToString());
                TxtAddress.Text = dt1.Rows[0][6].ToString();
                TxtPhone.Text = dt1.Rows[0][7].ToString();
                TxtEmail.Text = dt1.Rows[0][8].ToString();
                DropDownList1.SelectedValue =  dt1.Rows[0][9].ToString();
                Image1.ImageUrl = dt1.Rows[0][10].ToString(); ;

            }

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                //Image1.ImageUrl = @"~\Files\users_images\default.png";
               
                DataTable ds = new DataTable();
                string sql = "SELECT * FROM countries";
                ds = mdb.ExecuteSqlDataTable(sql);

                if (ds != null)
                {
                    DropDownList1.DataSource = ds;
                    DropDownList1.DataMember = "Table";
                    DropDownList1.DataTextField = "name";
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataBind();
                }
                ShowProfile();
            }

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string sql = @"Update users  set fullName=@fullName ,username= @username ,  gender=@gender,address= @address, phoneNumber= @phone, email= @email,countryID= @country,profile_picture= @pic where userid=@userid;";

            MySqlParameter[] paras =
                {
                    new MySqlParameter("@fullName", TxtFullName.Text.Trim()),
                    new MySqlParameter("@username", TxtUsername.Text.Trim()), 
                    new MySqlParameter("@gender",  RadioButtonList1.SelectedIndex),
                    new MySqlParameter("@address", TxtAddress.Text.Trim()),
                    new MySqlParameter("@phone", TxtPhone.Text.Trim()),
                    new MySqlParameter("@email", TxtEmail.Text.Trim()),
                    new MySqlParameter("@country",  DropDownList1.SelectedValue),
                    new MySqlParameter("@userid",  Session["uid"].ToString()),
                    new MySqlParameter("@pic", Image1.ImageUrl.Replace(@"\", @"\\"))
                };
            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {

                Response.Redirect("Homepage.aspx");
            }
            else
            {
                Response.Write("<script>alert('FAILED');</srcipt>");

            }
        }



        public void UploadFile()
        {
            if (FileUpload1.HasFile == false)
            {
                lblFile.Text = "The file to be uploaded cannot be empty!";
            }
            else
            {
                string folderPath = Server.MapPath("~/Files/users_images/");


                if (!Directory.Exists(folderPath))
                {

                    Directory.CreateDirectory(folderPath);
                }


                FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));


                lblFile.Text = Path.GetFileName(FileUpload1.FileName) + " has been uploaded.";
                Image1.ImageUrl = @"~\Files\users_images\" + FileUpload1.FileName;
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            UploadFile();
        }
    }
}