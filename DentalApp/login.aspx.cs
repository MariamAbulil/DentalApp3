using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalApp
{
    public partial class Welcoming : System.Web.UI.Page
    {
        DBConnection connection = new DBConnection();
        string role;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        string selectQuery = "";


        protected void Loginbtn_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            Session["email"] = email;

            if (DropDownList1.SelectedValue == "Admin")
            {
                if (TextBox1.Text == "admin@aaup.edu" && TextBox2.Text == "admin")
                {
                    Response.Redirect("Home.aspx?role=" + Server.UrlEncode(DropDownList1.SelectedValue));
                }
                
            }
            else 
            {
                
                selectQuery = "SELECT * FROM " + DropDownList1.SelectedValue + " WHERE Email='" + TextBox1.Text + "' AND Password='" + TextBox2.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection.GetCon());
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                
                
                if (table.Rows.Count > 0)
                {
                    if (DropDownList1.SelectedValue == "Student" || DropDownList1.SelectedValue == "Instructor")
                    {
                        if (Convert.ToInt32( table.Rows[0]["approved"]) == 0)
                            ShowMessage("Your account is not approved yet, please try again later.");
                        else
                            Response.Redirect("Home.aspx?role=" + Server.UrlEncode(DropDownList1.SelectedValue));
                    }
                    else
                    Response.Redirect("Home.aspx?role=" + Server.UrlEncode(DropDownList1.SelectedValue));
                }
                else
                {
                    
                    ShowMessage("Wrong email or password, please try again.");
                }
            }
        }
        private void ShowMessage(string message)
        {
            string script = $"alert('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
                Response.Redirect("registration.aspx");
        }


    }
}