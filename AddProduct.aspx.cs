using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace WebApplication5
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public string connect = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security = True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Edit product.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);

            con.Open();

            if (con.State == System.Data.ConnectionState.Open)
            {
                string edit = "INSERT INTO AddProduct (Product_name, Sales_price, Available_quantity, Brand, product_id)values('" + TextBox4.Text.ToString() + "','" + TextBox3.Text.ToString() + "','" + DropDownList2.SelectedItem + "','" + DropDownList1.SelectedItem + "','" + TextBox5.Text.ToString() + "')";
                SqlCommand cmd = new SqlCommand(edit, con);
                cmd.ExecuteNonQuery();
                Response.Redirect("ProductPage.aspx");
            }
            else
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}