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
    public partial class Storeproccrud : System.Web.UI.Page
    {
        // private string connectiostring = "data source=PRADEEP-SAHOO56\\MSSQLSERVER1; Initial catalog=FamilyDB; Integrated Security=True ";

       private string connectiostring = "data source=PRADEEP-SAHOO56\\MSSQLSERVER1; Initial catalog=FamilyDB; Integrated Security=True ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  BindGrindView();
            }
        }

        private void BindGrindView()
        {
            try
            {
                using (SqlConnection  con= new SqlConnection(connectiostring))
                {
                    SqlCommand cmd = new SqlCommand("sp_Get ", con);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                     DataTable dt= new DataTable();
                    sqlDataAdapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception   ex)
            {
                 Console.WriteLine(ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectiostring = "data source=PRADEEP-SAHOO56\\MSSQLSERVER1; Initial catalog=FamilyDB; Integrated Security=True ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectiostring))
                {
                  SqlCommand sqlCommand = new SqlCommand("sp_Insert", conn);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Empid", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Name", txtName.Text);
                    sqlCommand .Parameters.AddWithValue("@Age",txtAge.Text);
                    sqlCommand.Parameters.AddWithValue("@Country",txtCountry.Text); 


                    conn.Open();
                    int z = sqlCommand.ExecuteNonQuery();
                    if (z != 0)
                    {
                        Response.Write("<script>alert (' Data Inserted ' )</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert (' Data failed to Inserted ' )</script>");
                    }


                }
            }
            catch (Exception ex) 
            {
                 Console.WriteLine(ex.Message);
            }
            BindGrindView();

            ClearClontrols();

        }

        private void ClearClontrols()
        {
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectiostring))
                {
                    SqlCommand cmd = new SqlCommand("sp_Update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpId", Session["id"]);
                    cmd.Parameters.AddWithValue("@Name", Convert.ToString(txtName.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Age", Convert.ToString(txtAge.Text.Trim()));
                    cmd.Parameters.AddWithValue("@Country", Convert.ToString(txtCountry.Text.Trim()));
                    con.Open();

                    int result= cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Response.Write("<script>alert ('Record updated... !!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert ('Record  failed to updated... !!')</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            GridView1.EditIndex = -1;
            BindGrindView();
            ClearClontrols();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearClontrols();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;

            int rowindex = e.NewEditIndex;

            string empid = GridView1.Rows[rowindex].Cells[0].Text; 
            Session["id"] = empid;


            
            txtName.Text = ((Label)GridView1.Rows[rowindex].FindControl("txtName")).Text;
            txtAge.Text = ((Label)GridView1.Rows[rowindex].FindControl("txtAge")).Text;
            txtCountry.Text = ((Label)GridView1.Rows[rowindex].FindControl("txtCountry")).Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string empid = GridView1.DataKeys[e.RowIndex].Value.ToString();


            using (SqlConnection conn = new SqlConnection( connectiostring))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_Delete", conn);
                sqlCommand.CommandType= CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empid);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                BindGrindView();

            }
        }

       
    }
}