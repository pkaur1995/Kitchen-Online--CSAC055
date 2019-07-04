using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;



namespace WebApplication5
{
    public partial class sign_up : System.Web.UI.Page
    {
        public string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security = True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);

            con.Open();
            bool correct = CaptchaBox.Validate(txtCaptcha.Text);
            txtCaptcha.Text = null;
            if (correct)
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    string insert = "INSERT INTO Signup(first_name, last_name, Username, password)values('" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "','" + TextBox3.Text.ToString() + "','" + TextBox5.Text.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Response.Write("Please enter all the details");
                }
            }
            else
            {
                Response.Write("Invalid captcha");
            }
        }
    }
}