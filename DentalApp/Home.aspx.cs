using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DentalApp
{
    public partial class Home : System.Web.UI.Page
    {

        List<string> items = new List<string> { "home", "registration", "login" };
        List<string> student_items = new List<string> {"home", "report", "set appointment", "logout"};
        List<string> patient_items = new List<string> {"home", "appointment", "logout"};
        List<string> instructor_items = new List<string> {"home", "student-patient match", "approve student", "review reports", "logout"};
        List<string> admin_items = new List<string> { "home", "users information", "approve instructors", "instructor-patient match", "logout"};
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
            
            if (Request.QueryString["role"] != null) {
                ViewState["role"] = Server.UrlDecode(Request.QueryString["role"]);
                string role = ViewState["role"].ToString();
                if (!IsPostBack)
                {
                    if (role == "Student")
                    {
                        BulletedList1.DataSource = student_items;
                        getstudentinfo();
                    }
                    else if (role == "Instructor")
                    {
                        BulletedList1.DataSource = instructor_items;
                    }
                    else if (role == "Patient")
                    {
                        BulletedList1.DataSource = patient_items;
                    }
                    else if (role == "Admin")
                    {
                        BulletedList1.DataSource = admin_items;
                    }

                }
                    
            } 
                else 
            {
                BulletedList1.DataSource = items;
            }
            
            
                BulletedList1.DataBind();
                
            
        }
        DBConnection conn = new DBConnection();
        string sql = "";
        public void getinstructors ()
        {
            sql = "select Name, Email, approved from instructor";
            SqlCommand command = new SqlCommand(sql, conn.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
        private void ShowMessage(string message)
        {
            string script = $"alert('{message}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessageScript", script, true);
        }

        protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
        {
            if (e.Index == 0)
            {
                Response.Redirect("Home.aspx?role=" + Server.UrlEncode(ViewState["role"].ToString()));
            }
            else
            {
                if (Request.QueryString["role"] != null)
                {
                    switch (ViewState["role"].ToString())
                    {
                        case "Student":
                            if (e.Index == 1)
                                MultiView1.ActiveViewIndex = 4;
                            else if (e.Index == 2)
                                MultiView1.ActiveViewIndex = 5;
                            else if (e.Index == 3)
                                Response.Redirect("login.aspx");
                            break;
                        case "Instructor":
                            if (e.Index == 1)
                                MultiView1.ActiveViewIndex = 6;
                            else if (e.Index == 2)
                                MultiView1.ActiveViewIndex = 7;
                            else if (e.Index == 3)
                                MultiView1.ActiveViewIndex = 8;
                            else if (e.Index == 4)
                                Response.Redirect("login.aspx");
                            break;
                        case "Patient":
                            if (e.Index == 1)
                            {
                                MultiView1.ActiveViewIndex = 9;
                                getAppointments();


                            }
                               
                            else if (e.Index == 2)
                                Response.Redirect("login.aspx"); 
                            break;
                        case "Admin":

                            if (e.Index == 1)
                                MultiView1.ActiveViewIndex = 1;
                            else if (e.Index == 2)
                            {
                                MultiView1.ActiveViewIndex = 2;

                            }
                            else if (e.Index == 3)
                                MultiView1.ActiveViewIndex = 3;
                            else if (e.Index == 4)
                                Response.Redirect("login.aspx");
                            break;
                    }
                }
                else
                {

                    if (e.Index == 1)
                    {
                        Response.Redirect("registration.aspx");
                    }
                    else
                    {
                        Response.Redirect("login.aspx");
                    }
                }

            }
        }

        protected void pGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                LinkButton editButton = e.Row.Cells[0].Controls[0] as LinkButton;

                if (editButton != null && editButton.CommandName == "Edit")
                {
                    editButton.Text = "match"; 
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                LinkButton editButton = e.Row.Cells[0].Controls[0] as LinkButton; 

                if (editButton != null && editButton.CommandName == "Edit")
                {
                    editButton.Text = "dis/ approve";
                }
            }
        }
        SqlCommand cmd = null;
        public void getstudentinfo()
        {
            sql = "SELECT * FROM Student WHERE Email='" + Session["email"].ToString() +"'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn.GetCon());
            DataTable table = new DataTable();
            adapter.Fill(table);
            ViewState["sid"] = table.Rows[0]["Id"];
            ViewState["insid"] = table.Rows[0]["InsID"];
            
        }
        public void pInfoForDate()
        {
            
            sql = "SELECT * FROM Patient WHERE StId = '" + ViewState["sid"]+"'";
            SqlDataAdapter adapter = new SqlDataAdapter( sql, conn.GetCon());
            DataTable table = new DataTable();
            adapter.Fill(table);
            try
            {
                ViewState["pid"] = table.Rows[0]["Id"];
            }
            catch { ShowMessage("you are not connected with a patient."); }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            sql = "INSERT INTO Reports (Content, State, SId, InsId, Title) VALUES (@con, 'not viewed', @sid, @insid, @title)";
            cmd = new SqlCommand(sql, conn.GetCon());
            cmd.Parameters.AddWithValue("@con", TextBox1.Text);
            cmd.Parameters.AddWithValue("@sid", ViewState["sid"]);
            cmd.Parameters.AddWithValue("@insid", ViewState["insid"]);
            cmd.Parameters.AddWithValue("@title", TextBox5.Text);
            try
            {
                conn.OpenCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
                TextBox1.Text = "";
                ShowMessage("Report Submited Successfully.");
            }
            catch (Exception ex) { ShowMessage("Something Went Wrong."); }
            
            
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            pInfoForDate();
            sql = "INSERT INTO Appointments (Date, SId, PId, State) VALUES (@d, @sid, @pid, 'wait')";
            cmd = new SqlCommand(sql, conn.GetCon());
            cmd.Parameters.AddWithValue("@d", Calendar1.SelectedDate);
            cmd.Parameters.AddWithValue("@sid", ViewState["sid"]);
            cmd.Parameters.AddWithValue("pid", ViewState["pid"]);
            try
            {
                conn.OpenCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
                ShowMessage("Appointment Submited Successfully.");
            }
            catch
            {
                ShowMessage("Something Went Wrong.");
            }
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int index = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox2.Text = GridView2.Rows[index].Cells[2].Text;
            ViewState["stid"] = int.Parse(GridView2.Rows[index].Cells[1].Text);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            int index = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            TextBox3.Text = GridView3.Rows[index].Cells[2].Text;
           
        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            sql = "UPDATE Patient SET StId = " + ViewState["stid"];
            cmd = new SqlCommand(sql, conn.GetCon());
            try
            {
                conn.OpenCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
                ShowMessage("Matching Done!");
            }
            catch
            {
                ShowMessage("Somthing Went Wrong.");
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM Reports WHERE SId = " + ListBox1.SelectedValue;
            SqlDataAdapter adapter1 = new SqlDataAdapter(sql,conn.GetCon());
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            
            try
            {
                ListBox3.DataSource = table1;
                ListBox3.DataValueField = "Id";
                ListBox3.DataTextField = "Title";
                ListBox3.DataBind();
            }
        catch {
                ShowMessage("NO Report for this student");
            }
        }
        public void getStudent()
        {

            sql = "SELECT * FROM Patient WHERE Email = '" + Session["email"].ToString() + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn.GetCon());
            DataTable table = new DataTable();
            adapter.Fill(table);
            ViewState["Pid"] = table.Rows[0]["Id"];
            ViewState["Sid"] = table.Rows[0]["StId"];


        }
        public void getAppointments() {


            getStudent();
            sql = "SELECT * FROM Appointments WHERE PId = '" + ViewState["Pid"] + "'";
           
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn.GetCon());
            DataTable table = new DataTable();
            adapter.Fill(table);
            ListBox2.DataSource = table;
            ListBox2.DataTextField = "Date";
            ListBox2.DataValueField = "Id";
            ListBox2.DataBind();
        }
        
        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["AId"] = ListBox2.SelectedValue;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            sql = "UPDATE Appointments SET State = 'Rejected' WHERE Id = '"+ListBox2.SelectedValue+"'";
            cmd = new SqlCommand(sql,conn.GetCon());
            try
            {
                conn.OpenCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
                ListBox2.Items.Remove(ListBox2.SelectedItem);
                ShowMessage("Appointment Rejected.");
            }
            catch { ShowMessage("Something Went Wrong."); }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            sql = "UPDATE Appointments SET State = 'Accepted' WHERE Id = '" + ListBox2.SelectedValue + "'";
            cmd = new SqlCommand(sql, conn.GetCon());
            try
            {
                conn.OpenCon();
                cmd.ExecuteNonQuery();
                conn.CloseCon();
                ShowMessage("Appointment Accepted.");
                ListBox2.Items.Remove(ListBox2.SelectedItem);
            }
            catch { ShowMessage("Something Went Wrong."); }
        }

        protected void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql = "Select Content FROM Reports WHERE Id = '" + ListBox3.SelectedValue+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn.GetCon());
            DataTable table = new DataTable();
            adapter.Fill(table);
            TextBox4.Text = table.Rows[0][0].ToString();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            sql = "SELECT Date, State FROM Appointments WHERE SId = '" + ViewState["sid"] + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn.GetCon());
            DataTable table = new DataTable();
            adapter.Fill(table);
            GridView5.DataSource = table;
            GridView5.DataBind();
        }
    }
}