using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Optimization;

namespace SimpleCrudOperation
{
    public partial class WebFormCruPage : System.Web.UI.Page
    {
        private string connectionString = "Data Source=PRADEEP-SAHOO56\\MSSQLSERVER1;Initial Catalog=FamilyDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employee", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=PRADEEP-SAHOO56\\MSSQLSERVER1;Initial Catalog=FamilyDB;Integrated Security=True";
            using (SqlConnection con= new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employee (Name, Age, Country) VALUES (@Name, @Age, @Country)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                con.Open();
               int i= cmd.ExecuteNonQuery();
                if (i != 0)
                {
                   // Response.Write("Data Inserted");
                    Response.Write("<script>alert ('Data Inserted.. !!')</script>");

                }
                else
                {
                    Response.Write("Data  Failed to Insertted ..!!");
                   

                }
            }
            BindGridView();
            txtName .Text="";
            txtAge.Text = "";
            txtCountry.Text = "";

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Retrieve the EmpId from DataKeys
                int empId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

                // Retrieve updated values from the GridView row
                string name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName")).Text;
                string age = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAge")).Text;
                string country = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtCountry")).Text;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Query with WHERE clause to update the specific row
                    string query = "UPDATE Employee SET Name = @Name, Age = @Age, Country = @Country WHERE EmpId = @EmpId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@EmpId", empId);

                    // Open the connection and execute the query
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Provide feedback
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Updated successfully!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Update failed!');</script>");
                    }
                }

                // Reset edit index and rebind the grid
                GridView1.EditIndex = -1;
                BindGridView();
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully
                Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
            }

        }
        

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex= -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int empid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "delete from Employee where EmpId = @EmpId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpId", empid);
                con.Open();
                int record = cmd.ExecuteNonQuery();
                if (record > 0)
                {
                    Response.Write("<script> alert('Deleted Sucessfully..!!')</script>");
                }
                else
                {
                    Response.Write("<script> alert('Deleted Failed... !!')</script>");
                }
            }

            BindGridView();

        }
    }
}