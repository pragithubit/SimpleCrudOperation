using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SimpleCrudOperation
{
    public partial class WebAppcrudtwoTable : System.Web.UI.Page
    {
        private string connectiostring = "data source=PRADEEP-SAHOO56\\MSSQLSERVER1; Initial catalog=FamilyDB; Integrated Security=True ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  
            {
                
                BindGridView();
                LoadCountries();
            }

        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectiostring))
            {
                string query = "SELECT e.EmpId, e.EmpName, e.Salary, e.CountryId, c.CountryName FROM Employee_s e " +
                               "INNER JOIN Country_s c ON e.CountryId = c.CountryId";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void LoadCountries()
        {
            using (SqlConnection conn = new SqlConnection(connectiostring))
            {
                string query = "SELECT * FROM Country_s";
                SqlCommand command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    ddlCountryName.DataSource = reader; 
                    ddlCountryName.DataTextField = "CountryName"; 
                    ddlCountryName.DataValueField = "CountryId";  
                    ddlCountryName.DataBind(); 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); 
                }
            }

            // Add a default item after data binding
            ddlCountryName.Items.Insert(0, new ListItem("..Select Country..", "0"));
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            using (SqlConnection con= new SqlConnection(connectiostring))
            {
                string query = "Insert into Employee_s (Empname, Salary, CountryId) values (@Empname, @Salary, @CountryId)";
                SqlCommand cmd = new SqlCommand(query, con );
                cmd.Parameters.AddWithValue("@EmpName", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
                cmd.Parameters.AddWithValue("@CountryId", ddlCountryName.SelectedValue);

                con.Open();
               int z= cmd.ExecuteNonQuery();
                if (z != 0)
                {
                    Response.Write("<script>alert (' Data Inserted ' )</script>");
                }
                else
                {
                    Response.Write("<script>alert (' Data failed to Inserted ' )</script>");
                }

            }
            BindGridView();


            txtEmpName.Text = " ";
            txtSalary.Text = string.Empty;
            ddlCountryName.SelectedIndex = 0;

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
            

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
          
                  int empId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string empname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmpName")).Text;
            string salary = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtSalary")).Text;
            string ddlcountry = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("ddlCountryname")).Text;


            using (SqlConnection con = new SqlConnection(connectiostring))
            {
                string query = " Update Employee_s set EmpName=@EmpName , Salary=@Salary, CountryId=@CountryId  where  EmpId=@EmpId";
                SqlCommand cmd = new SqlCommand( query, con);
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.AddWithValue("@EmpName", empname);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd .Parameters.AddWithValue("@CountryId", ddlcountry);

                con.Open();
                int record=cmd.ExecuteNonQuery();
                if(record > 0)
                {
                    Response.Write("<script>alert (' Record Updated ' )</script>");
                }
                else
                {
                    Response.Write("<script>alert ('  Record failed to Updated ' )</script>");
                }
            }

            GridView1.EditIndex = -1;
            BindGridView();


        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }
    }
}