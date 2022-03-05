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
    public partial class Register : System.Web.UI.Page
    {

        MySqlDBHelper mdb = new MySqlDBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;                  
            
            TxtAddress.Attributes.Add("placeholder", "Address");
            string Password = TxtPassword.Text;
            string Pwd = TextBox4.Text;
            TxtPassword.Attributes.Add("value", Password);
            TextBox4.Attributes.Add("value", Pwd);
           

            BtnSave.Enabled = false;
            if (!IsPostBack)
            {
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
            }

        }


        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.Items.Clear();
        }
             


        protected void Button1_Click1(object sender, EventArgs e)
        {
           
            string sql = @"INSERT INTO users VALUES(null, @fullName , @username , @pwd , @dob , @gender, @address, @phone, @email, @country,null, NOW());";
                        
            MySqlParameter[] paras =
                {
                    new MySqlParameter("@fullName", TxtFullName.Text.Trim()),
                    new MySqlParameter("@username", TxtUsername.Text.Trim()),
                    new MySqlParameter("@pwd", TxtPassword.Text.Trim()),
                    new MySqlParameter("@dob", TxtDob.Text.Trim()),
                    new MySqlParameter("@gender",  RadioButtonList1.SelectedIndex),
                    new MySqlParameter("@address", TxtAddress.Text.Trim()),
                    new MySqlParameter("@phone", TxtPhone.Text.Trim()),
                    new MySqlParameter("@email", TxtEmail.Text.Trim()),
                    new MySqlParameter("@country",  DropDownList1.SelectedValue), 
                };


            if (mdb.ExecuteSqlNonQuery(sql, paras) > 0)
            {
                
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Write("<script>alert('register FAILED');</srcipt>");

            }
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                BtnSave.Enabled = true;
            }
            else
            {
                BtnSave.Enabled = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
      
    }
}
