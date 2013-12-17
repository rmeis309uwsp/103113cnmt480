using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class Pages_Make_a_Request : System.Web.UI.Page
{
    public int itemId;
    List<int> itemNums;

    protected void Page_Load(object sender, EventArgs e)
    {
        itemNums = new List<int>();
        if(!IsPostBack){
        while (itemList.Items.Count > 0)
        {
            itemList.Items.RemoveAt(0);
        }
        if (categoryList.Items.Count == 0)
        {
            loadItemCategories();
        }
        }
    }

    protected void loadItemCategories()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string loadCategoriesQuery = "SELECT * FROM itemcategories";
        SqlCommand categoryCommand = new SqlCommand(loadCategoriesQuery, conn);

        try
        {

            conn.Open();
            SqlDataReader reader = categoryCommand.ExecuteReader();

            while (reader.Read())
            {
                categoryList.Items.Add(reader["categoryName"].ToString());
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
            loadItems();
        }
    }

    protected void saveRequest_Click(object sender, EventArgs e)
    {
     //   Match uwspIdRegEx = Regex.Match(uwspIdTb.Text, @"[0-9]{8}");
        string personUwspId;
     //   if (uwspIdRegEx.Success)
      //  {
            personUwspId = uwspIdTb.Text;
      //  }
        
        string personRole = roleButtons.SelectedValue;

       // Match uwspEmailRegEx = Regex.Match(emailTb.Text, @"[0-9a-zA-Z]{1,}");
        string personEmail;
      //  if (uwspEmailRegEx.Success)
       // {
            personEmail = emailTb.Text;
       // }

        string personPhone = phoneNumTb.Text;

        string personFName = firstNameTb.Text;
        string personLName = lastNameTb.Text;
        string purpose = purposeTb.Text;
        DateTime? dueDate = null;
        DateTime? checkOutDate = null;
        DateTime? checkInDate = null;
        DateTime requestSentDate = DateTime.Now;
        
     //   Match requestedForDateRegEx = Regex.Match(requestedForDateTb.Text, @"((0[1-9])|([12][0-9])|(3[01]))/\d{4}");
        DateTime requestedForDate;
      //  if (requestedForDateRegEx.Success)
     //   {
            requestedForDate = DateTime.Parse(requestedForDateTb.Text);
     //   }

        bool agreementSigned = false;
        bool activeCheckout = false;
        bool activeRequest = true;

        Checkout newRequest = new Checkout(itemId, personUwspId, personRole, personEmail, personPhone,
            personFName, personLName, purpose, dueDate, checkOutDate, checkInDate, requestSentDate,
            requestedForDate, agreementSigned, activeCheckout, activeRequest);

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string requestQuery = "INSERT INTO checkout VALUES (@itemId, @personUwspId, @personRole, @personEmail, @personPhone, @personFName, " +
               "@personLName, @purpose, @dueDate, @checkOutDate, @checkInDate, @requestSentDate, @requestedForDate, @agreementSigned, " +
               "@activeCheckout, @activeRequest);";
        SqlCommand requestCommand = new SqlCommand(requestQuery, conn);

        requestCommand.Parameters.AddWithValue("@itemId", newRequest.itemId);
        requestCommand.Parameters.AddWithValue("@personUwspId", newRequest.personUwspId);
        requestCommand.Parameters.AddWithValue("@personRole", newRequest.personRole);
        requestCommand.Parameters.AddWithValue("@personEmail", newRequest.personEmail);
        requestCommand.Parameters.AddWithValue("@personPhone", newRequest.personPhone);
        requestCommand.Parameters.AddWithValue("@personFName", newRequest.personFName);
        requestCommand.Parameters.AddWithValue("@personLName", newRequest.personLName);
        requestCommand.Parameters.AddWithValue("@purpose", newRequest.purpose);
        requestCommand.Parameters.AddWithValue("@dueDate", DBNull.Value);
        requestCommand.Parameters.AddWithValue("@checkOutDate", DBNull.Value);
        requestCommand.Parameters.AddWithValue("@checkInDate", DBNull.Value);
        requestCommand.Parameters.AddWithValue("@requestSentDate", newRequest.requestSentDate);
        requestCommand.Parameters.AddWithValue("@requestedForDate", newRequest.requestedForDate);
        requestCommand.Parameters.AddWithValue("@agreementSigned", newRequest.agreementSigned);
        requestCommand.Parameters.AddWithValue("@activeCheckout", newRequest.activeCheckout);
        requestCommand.Parameters.AddWithValue("@activeRequest", newRequest.activeRequest);

        try
        {
            conn.Open();
            requestCommand.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
        }
    }
    protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadItems();
    }

    protected void loadItems()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string loadItems = "SELECT itemId, name, description, available, staffOnly FROM items WHERE categoryName = @selectedCategory";
        SqlCommand itemsCommand = new SqlCommand(loadItems, conn);
        itemsCommand.Parameters.AddWithValue("@selectedCategory", categoryList.SelectedValue);

        try
        {

            conn.Open();
            SqlDataReader reader = itemsCommand.ExecuteReader();
          //  itemNums = new List<int>();

            while (reader.Read())
            {
                string staffOnlyString = "";
                string availableString = "";
                if (reader["staffOnly"].Equals(true))
                {
                    staffOnlyString = "(Staff Only)";
                }
                if (reader["available"].Equals(true))
                {
                    availableString = "(Available)";
                }
                else
                {
                    availableString = "(Not Available)";
                }
                itemList.Items.Add(reader["name"].ToString() + " " + availableString + " " + staffOnlyString);
                itemNums.Add(Convert.ToInt32(reader["itemId"].ToString()));
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            conn.Close();
            changeItemId();
        }
    }

    protected void itemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeItemId();
    }

    protected void changeItemId()
    {
        itemId = itemNums[itemList.SelectedIndex];
    }
}