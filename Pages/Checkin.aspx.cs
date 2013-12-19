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

public partial class Pages_Checkout : System.Web.UI.Page
{
    protected int itemId;
    protected int requestId;
    List<int> itemNums;
    List<int> requestNums;
    bool wasRequested = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (checkoutList.Items.Count==0)
        {
            loadCheckouts();
        }
    }

    //load existing requests into dropdown
    protected void loadCheckouts()
    {
        requestNums = new List<int>();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string loadRequestsQuery = "SELECT * FROM checkout WHERE activeRequest='true' AND activeCheckout='false' ORDER BY personLName ASC";
        SqlCommand requestsCommand = new SqlCommand(loadRequestsQuery, conn);

         try
        {

            conn.Open();
            SqlDataReader reader = requestsCommand.ExecuteReader();
            string currentRequestText = "";

            while (reader.Read())
            {
                currentRequestText = reader["personLName"].ToString() + ", " + reader["personFName"].ToString() + "      ";

                string requestedItemQuery = "SELECT itemId, name FROM items WHERE itemId=@requestedItemId";
                SqlCommand requesteditemCommand = new SqlCommand(requestedItemQuery, conn);
                requesteditemCommand.Parameters.AddWithValue("@requestedItemId", reader["itemId"].ToString());
                SqlDataReader requesteditemReader = requesteditemCommand.ExecuteReader();

                while (requesteditemReader.Read())
                {
                    currentRequestText += requesteditemReader["name"].ToString();
                }
                requestList.Items.Add(currentRequestText);
                requestNums.Add(Convert.ToInt32(reader["checkoutId"].ToString()));
                Page.Session["requestNumList"] = requestNums;
            }
        }
        catch (SqlException)
        {
            checkoutConfirm.InnerHtml = "Error loading request.<br/>";
        }
        finally
        {
            conn.Close();
            Page.Session["requestNumList"] = requestNums;
            if (Page.Session["selectedRequestIndex"] == null)
            {
                Page.Session["selectedRequestIndex"] = 0;
            }
            changeRequestId();
        }
    }

    //load "category" dropdown
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
        catch (SqlException)
        {
            checkoutConfirm.InnerHtml = "Error loading categories.<br/>";
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
            checkoutConfirm.InnerHtml = "Error loading items.<br/>";
        }
        finally
        {
            conn.Close();
            changeItemId();
        }
    }

    protected void saveCheckout_Click(object sender, EventArgs e)
    {
        itemNums = (List<int>)Page.Session["itemNumList"];
        if (itemList.SelectedIndex == -1)
        {
            itemId = itemNums[0];
        }
        else
        {
            itemId = itemNums[itemList.SelectedIndex];
        }
        string personUwspId= uwspIdTb.Text;
        string personRole = roleButtons.SelectedValue;
        string personEmail = emailTb.Text;
        string personPhone = phoneNumTb.Text;
        string personFName = firstNameTb.Text;
        string personLName = lastNameTb.Text;
        string purpose = purposeTb.Text;
        DateTime? dueDate = DateTime.Parse(dueDateTb.Text);
        DateTime? checkOutDate = DateTime.Now;
        DateTime? checkInDate = null;
        DateTime? requestSentDate = null;
        DateTime? requestedForDate = null ;
        bool agreementSigned = agreementBox.Checked;
        bool activeCheckout = true;
        bool activeRequest = false;
        decimal fine = 0;

        Checkout newCheckout = new Checkout(itemId, personUwspId, personRole, personEmail, personPhone,
            personFName, personLName, purpose, dueDate, checkOutDate, checkInDate, requestSentDate,
            requestedForDate, agreementSigned, activeCheckout, activeRequest, fine);

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string requestQuery = "INSERT INTO checkout VALUES (@itemId, @personUwspId, @personRole, @personEmail, @personPhone, @personFName, " +
               "@personLName, @purpose, @dueDate, @checkOutDate, @checkInDate, @requestSentDate, @requestedForDate, @agreementSigned, " +
               "@activeCheckout, @activeRequest, @fine);";
        SqlCommand requestCommand = new SqlCommand(requestQuery, conn);

        requestCommand.Parameters.AddWithValue("@itemId", newCheckout.itemId);
        requestCommand.Parameters.AddWithValue("@personUwspId", newCheckout.personUwspId);
        requestCommand.Parameters.AddWithValue("@personRole", newCheckout.personRole);
        requestCommand.Parameters.AddWithValue("@personEmail", newCheckout.personEmail);
        requestCommand.Parameters.AddWithValue("@personPhone", newCheckout.personPhone);
        requestCommand.Parameters.AddWithValue("@personFName", newCheckout.personFName);
        requestCommand.Parameters.AddWithValue("@personLName", newCheckout.personLName);
        requestCommand.Parameters.AddWithValue("@purpose", newCheckout.purpose);
        requestCommand.Parameters.AddWithValue("@dueDate", newCheckout.dueDate);
        requestCommand.Parameters.AddWithValue("@checkOutDate", newCheckout.checkOutDate);
        requestCommand.Parameters.AddWithValue("@checkInDate", DBNull.Value);
        requestCommand.Parameters.AddWithValue("@requestSentDate", DBNull.Value);
        requestCommand.Parameters.AddWithValue("@requestedForDate", DBNull.Value);
        requestCommand.Parameters.AddWithValue("@agreementSigned", newCheckout.agreementSigned);
        requestCommand.Parameters.AddWithValue("@activeCheckout", newCheckout.activeCheckout);
        requestCommand.Parameters.AddWithValue("@activeRequest", newCheckout.activeRequest);
        requestCommand.Parameters.AddWithValue("@fine", newCheckout.fine);

        string itemCheckedOutQuery = "UPDATE items SET available='false' WHERE itemId = @itemId";
        SqlCommand itemCheckedOutCommand = new SqlCommand(itemCheckedOutQuery, conn);
        itemCheckedOutCommand.Parameters.AddWithValue("@itemId", itemId);
        try
        {
            conn.Open();
            requestCommand.ExecuteNonQuery();
            itemCheckedOutCommand.ExecuteNonQuery();
            checkoutConfirm.InnerHtml = "Checkout successful.";
            loadItems();
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

    //A different item category is selected
    protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        while (itemList.Items.Count > 0)
        {
            itemList.Items.RemoveAt(0);
        }
        loadItems();
    }

    //A different item is selected
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
        itemId = itemNums[(int)Page.Session["selectedItemIndex"]];
    }

    //A different request in the request list is selected
    protected void requestList_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeRequestId();
        Page.Session["selectedRequestIndex"] = requestList.SelectedIndex;
    }

    //User wants to import selected request into the form
    protected void importRequestBtn_Click(object sender, EventArgs e)
    {
        wasRequested = true;
        requestNums = (List<int>)Page.Session["requestNumList"];
        requestId = requestNums[requestList.SelectedIndex];
        if (requestNums.Count > 0)
        {
            checkoutConfirm.InnerHtml = "";
            requestNums = (List<int>)Page.Session["requestNumList"];
            requestId = requestNums[requestList.SelectedIndex];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            string selectedRequestQuery = "SELECT * FROM checkout WHERE requestID=@requestedItemId";
            SqlCommand selectedRequestCommand = new SqlCommand(selectedRequestQuery, conn);
            selectedRequestCommand.Parameters.AddWithValue("@requestedItemId", requestId);

            try
            {
                conn.Open();
                SqlDataReader selectedRequestReader = selectedRequestCommand.ExecuteReader();
                while (selectedRequestReader.Read())
                {
                    string selectedRequestitemQuery = "SELECT itemId, categoryName FROM items WHERE itemId=@itemId";
                    SqlCommand selectedRequestitemCommand = new SqlCommand(selectedRequestitemQuery, conn);
                    selectedRequestitemCommand.Parameters.AddWithValue("@itemId", selectedRequestReader["itemId"]);
                    SqlDataReader selectedRequestItemReader = selectedRequestitemCommand.ExecuteReader();

                    while (selectedRequestItemReader.Read())
                    {
                        categoryList.SelectedValue = selectedRequestItemReader["categoryName"].ToString();
                        loadItems();
                        itemList.SelectedIndex = (int)selectedRequestItemReader["itemId"];
                    }

                    firstNameTb.Text = selectedRequestItemReader["personFName"].ToString();
                    lastNameTb.Text = selectedRequestItemReader["personLName"].ToString();
                    uwspIdTb.Text = selectedRequestItemReader["personUwspId"].ToString();
                    emailTb.Text = selectedRequestItemReader["personEmail"].ToString();
                    phoneNumTb.Text = selectedRequestItemReader["personPhone"].ToString();
                    purposeTb.Text = selectedRequestItemReader["purpose"].ToString();
                    dueDateTb.Text = selectedRequestItemReader["requestedForDate"].ToString();
                }
            }
            catch (SqlException)
            {
                checkoutConfirm.InnerHtml = "Error importing request.<br/>";
            }
            finally
            {
                conn.Close();
            }
        }

        else
        {
            checkoutConfirm.InnerHtml = "No requests to import.";
        }
    }

    //Determines what the ID of the selected request is.
    //RequestNums is a list of integers that stores the id numbers of the current requests/checkouts in the list.
    //RequestId becomes currently selected request's id by looking in the list at the same index as the currently selected item.
    protected void changeRequestId()
    {
        requestNums = (List<int>)Page.Session["requestNumList"];
        if (Page.Session["selectedRequestIndex"] == null)
        {
            Page.Session["selectedRequestIndex"] = 0;
        }
        else
        {
            Page.Session["selectedRequestIndex"] = itemList.SelectedIndex;
        }
        if (requestNums.Count > 0)
        {
            if (requestList.SelectedIndex == -1)
            {
                requestId = requestNums[0];
            }
            else
            {
                requestId = requestNums[requestList.SelectedIndex];
            }
            requestId = requestNums[(int)Page.Session["selectedRequestIndex"]];
        }
    }

    //"Delete Request" button turns request inactive and removes it from the list
    protected void deleteRequestBtn_Click(object sender, EventArgs e)
    {
        if (requestNums.Count > 0)
        {
            requestNums = (List<int>)Page.Session["requestNumList"];
            requestId = requestNums[requestList.SelectedIndex];
            checkoutConfirm.InnerHtml = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            string deleteRequestQuery = "UPDATE checkout SET activeRequest='false' WHERE checkoutId=@requestId";
            SqlCommand deleteRequestCommand = new SqlCommand(deleteRequestQuery, conn);
            deleteRequestCommand.Parameters.AddWithValue("@requestId", requestId);
            try
            {
                conn.Open();
                deleteRequestCommand.ExecuteNonQuery();
                while (requestList.Items.Count > 0)
                {
                    requestList.Items.RemoveAt(0);
                }
                loadItems();
                loadRequests();
                checkoutConfirm.InnerHtml += "Request deleted successfully.<br/>";
            }
            catch (SqlException)
            {
                checkoutConfirm.InnerHtml += "Error deleting request.<br/>";
            }
            finally
            {

            }
        }
        else
        {
            checkoutConfirm.InnerHtml = "No requests to delete.";
        }
    }
}