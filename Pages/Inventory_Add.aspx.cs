using System;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Security.Cryptography;
using System.Configuration;




public partial class Pages_Inventory_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private void ClearTextFields()
    {

        txtName.Text = "";
        txtCategory.Text = "";
        txtDescription.Text = "";
        CheckBox1.Checked = false;
        CheckBox2.Checked = false;
       
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        FileUpload1.SaveAs(Server.MapPath("~/Images/" + FileUpload1.FileName));
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        con.Open();
        string inse = "insert into items (name, categoryName, description, available, staffOnly, imagePath) values(@name, @categoryName, @description, @available, @staffOnly, @imagePath)"; 
      
        SqlCommand insertuser = new SqlCommand(inse, con);
        insertuser.Parameters.AddWithValue("@name", txtName.Text);
        insertuser.Parameters.AddWithValue("@categoryName", txtCategory.Text);
        insertuser.Parameters.AddWithValue("@description", txtDescription.Text);
        insertuser.Parameters.AddWithValue("@available", CheckBox1.Checked);
        insertuser.Parameters.AddWithValue("@staffOnly", CheckBox2.Checked);
        insertuser.Parameters.AddWithValue("@imagePath", "../Images/" + FileUpload1.FileName);

        try
        {
            insertuser.ExecuteNonQuery();
            lblResult.Text = "Upload succesful!";
            ClearTextFields();
            con.Close();
        }
        catch (Exception)
        {
            lblResult.Text = "Upload fail!";
        }
    }
}

