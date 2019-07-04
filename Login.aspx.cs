using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication5
{
    public partial class Login : System.Web.UI.Page
    {
        public string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            string username = TextBox1.Text;
            string pwd = TextBox2.Text;
            con.Open();
            string qry = "Select * from Signup where Username='" + username + "' and password='" + pwd + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write("Sorry you are not registered in the database");

            }
            con.Close();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }
    }
}