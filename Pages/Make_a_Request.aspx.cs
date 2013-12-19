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
        
        if (categoryList.Items.Count == 0)
        {
            loadItemCategories();
        }
        if (itemList.Items.Count == 0)
        {
            loadItems();
        }
    }

   //load "category" dropdown
    protected void loadItemCategories()
    {
        requestConfirm.InnerHtml = "";
        
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
        catch (SqlException)
        {
            requestConfirm.InnerHtml += "Error loading categories.<br/>";
        }
        finally
        {
            conn.Close();
            loadItems();
        }
    }

    //load "Items" dropdown for selected category
    protected void loadItems()
    {

        itemNums = new List<int>();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string loadItems = "SELECT itemId, name, description, available, staffOnly FROM items WHERE categoryName = @selectedCategory";
        SqlCommand itemsCommand = new SqlCommand(loadItems, conn);
        itemsCommand.Parameters.AddWithValue("@selectedCategory", categoryList.SelectedValue);

        try
        {

            conn.Open();
            SqlDataReader reader = itemsCommand.ExecuteReader();

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
                Page.Session["itemNumList"] = itemNums;
                if (Page.Session["selectedItemIndex"] == null)
                {
                    Page.Session["selectedItemIndex"] = 0;
                }
            }
        }
        catch (SqlException)
        {
            requestConfirm.InnerHtml += "Error loading items.<br/>";
        }
        finally
        {
            conn.Close();
            changeItemId();
        }
    }
    
    //"Save Request" button is clicked
    protected void saveRequest_Click(object sender, EventArgs e)
    {
        requestConfirm.InnerHtml = "";
        itemNums = (List<int>)Page.Session["itemNumList"];
        if (itemList.SelectedIndex == -1)
        {
            itemId = itemNums[0];
        }
        else
        {
            itemId = itemNums[itemList.SelectedIndex];
        }

        string personUwspId;
        personUwspId = uwspIdTb.Text;
        string personRole = roleButtons.SelectedValue;
        string personEmail;
        personEmail = emailTb.Text;
        string personPhone = phoneNumTb.Text;
        string personFName = firstNameTb.Text;
        string personLName = lastNameTb.Text;
        string purpose = purposeTb.Text;
        DateTime? dueDate = null;
        DateTime? checkOutDate = null;
        DateTime? checkInDate = null;
        DateTime requestSentDate = DateTime.Now;
        decimal fine = 0;
        
        DateTime requestedForDate;
            requestedForDate = DateTime.Parse(requestedForDateTb.Text);

        bool agreementSigned = false;
        bool activeCheckout = false;
        bool activeRequest = true;

        Checkout newRequest = new Checkout(itemId, personUwspId, personRole, personEmail, personPhone,
            personFName, personLName, purpose, dueDate, checkOutDate, checkInDate, requestSentDate,
            requestedForDate, agreementSigned, activeCheckout, activeRequest, fine);

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string requestQuery = "INSERT INTO checkout VALUES (@itemId, @personUwspId, @personRole, @personEmail, @personPhone, @personFName, " +
               "@personLName, @purpose, @dueDate, @checkOutDate, @checkInDate, @requestSentDate, @requestedForDate, @agreementSigned, " +
               "@activeCheckout, @activeRequest, @fine);";
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
        requestCommand.Parameters.AddWithValue("@fine", fine);

        try
        {
            conn.Open();
            requestCommand.ExecuteNonQuery();
            firstNameTb.Text = "";
            lastNameTb.Text = "";
            emailTb.Text = "";
            phoneNumTb.Text = "";
            uwspIdTb.Text = "";
            requestedForDateTb.Text= "";
            purposeTb.Text = "";
            loadItems();
            requestConfirm.InnerHtml = "Request submitted successfully.";
        }
        catch (SqlException)
        {
            requestConfirm.InnerHtml += "Error submitting request.<br/>";
        }
        finally
        {
            conn.Close();
        }
    }

    //new category is selected in dropdown
    protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        while (itemList.Items.Count > 0)
        {
            itemList.Items.RemoveAt(0);
        }
        loadItems();
    }

    //new item is selected in dropdown
    protected void itemList_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeItemId();
        Page.Session["selectedItemIndex"] = itemList.SelectedIndex;
    }
   
    //Determines what the ID of the selected item is.
    //ItemNums is a list of integers that stores the id numbers of the current items in the list.
    //itemId becomes currently selected item's id by looking in the list at the same index as the currently selected item.
    protected void changeItemId()
    {
        itemNums = (List<int>)Page.Session["itemNumList"];
        if (Page.Session["selectedItemIndex"] == null)
        {
            Page.Session["selectedItemIndex"] = 0;
        }
        else
        {
            Page.Session["selectedItemIndex"] = itemList.SelectedIndex;
        }
        itemId = itemNums[(int)Page.Session["selectedItemIndex"]];
    }

    
}