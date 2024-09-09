using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalApp
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["BodyClass"] = "style1";
                MultiView1.ActiveViewIndex = 0;
                fillinstructorddl();
            }
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                Label2.Visible = true;
            }
            else
            {
                
                Session["Bodyclass"] = "style2";
                ViewState["role"] = DropDownList1.SelectedValue;
                MultiView1.ActiveViewIndex++;
                rolelbl.Text = "<h1>" + DropDownList1.SelectedValue + " Regestraion </h1>";
                if (DropDownList1.SelectedValue == "Student")
                {
                    stdemail.Visible = true;
                    stdemail.Enabled = true;
                    DropDownList2.Visible = true;
                    DropDownList3.Visible = true;
                    RequiredFieldValidator2.Enabled = true;
                    RequiredFieldValidator3.Enabled = true;
                    DropDownList2.Enabled = true;
                    DropDownList3.Enabled = true;
                }
                else if (DropDownList1.SelectedValue == "Patient")
                {
                    txtEmail.Visible = true;
                    txtEmail.Enabled = true;
                }
                else
                {
                    insemail.Visible = true;
                    insemail.Enabled = true;
                }
            }
        }
        public void fillinstructorddl()
        {
            sql = "SELECT * FROM Instructor WHERE approved = 1";
            SqlCommand command = new SqlCommand(sql, conn.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
             DropDownList3.DataSource = table;
             DropDownList3.DataTextField = "Name";
             DropDownList3.DataValueField = "Id";
             DropDownList3.DataBind();
             DropDownList3.Items.Insert(0, "My Instructor");


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            Response.Redirect("Welcoming.aspx");
        }
        DBConnection conn = new DBConnection();
        string sql = "";
        SqlCommand cmd = new SqlCommand();
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            conn.OpenCon();

            try
            {
            if (ViewState["role"].ToString() == "Student")
            {
                sql = "INSERT INTO Student (Name, phone, Acadamic_Year, Email, BirthDate, gender, InsId, approved, password) VALUES (@name, @phone, @Acadamic_Year, @Email, @bd, @gender, @InsId, '0', @password )";
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", stdemail.Text);
                cmd.Parameters.AddWithValue("@bd", txtBirthDate.Text);
                cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@InsId", DropDownList3.SelectedValue);
                cmd.Parameters.AddWithValue("@Acadamic_Year", DropDownList2.SelectedValue);
                cmd.CommandText = sql;
                cmd.Connection = conn.GetCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
            }
            else if (ViewState["role"].ToString() == "Instructor")
            {
                sql = "INSERT INTO Instructor (Name, phone, Email, BirthDate, gender, approved, password) VALUES (@name, @phone, @Email, @bd, @gender, 0, @password)";

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", insemail.Text);
                cmd.Parameters.AddWithValue("@bd", txtBirthDate.Text);
                cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.CommandText = sql;
                cmd.Connection = conn.GetCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
            }
            else if (ViewState["role"].ToString() == "Patient")
            {
                sql = "INSERT INTO Patient (Name, phone, Email, BirthDate, gender, password) VALUES (@name, @phone, @Email, @bd, @gender, @password)";
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@bd", txtBirthDate.Text);
                cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.CommandText = sql;
                cmd.Connection = conn.GetCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
            }
                Response.Redirect("login.aspx");
                
                
        }
            catch (Exception ex) 
            {
                ShowMessage(ex.Message);
            }
        }
        private void ShowMessage(string message)
        {
            string script = $"alert('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessageScript", script, true);
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            
            if ((txtName.Text.Trim().Split().Length) == 3 )
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;
        }


    }
}