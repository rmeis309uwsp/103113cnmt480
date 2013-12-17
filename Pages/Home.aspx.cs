using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class Pages_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (inventoryList.InnerHtml == "")
        {
            getInventory();
        }
    }

    protected void getInventory()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string categoryQuery = "SELECT * FROM itemcategories";
        SqlCommand categoryCommand = new SqlCommand(categoryQuery, conn);

        try
        {
            
            conn.Open();
            SqlDataReader reader = categoryCommand.ExecuteReader();
            int categoryNum = 0;
            inventoryList.InnerHtml += "<a href='Make_a_Request.aspx' runat='server'><h2>Request an Item</h2></a>";

            while (reader.Read())
            {
                //Div listing category - laptop, camera, etc. Gives divs ids of "category1", "category2", etc
                inventoryList.InnerHtml += "<div id='category" + categoryNum + "' runat='server'><h2 id='category" + categoryNum +
               "title'>" + reader["categoryName"].ToString() + "</h2>";

                string itemQuery = "SELECT * FROM items WHERE categoryName= @categoryName";
                SqlCommand itemCommand = new SqlCommand(itemQuery, conn);
                itemCommand.Parameters.AddWithValue("@categoryName", reader["categoryName"].ToString());
                SqlDataReader itemReader = itemCommand.ExecuteReader();

                int itemNum = 0;

                while (itemReader.Read())
                {
                    //For each item:
                    
                    String available;
                    if (itemReader["available"].ToString().Equals(1) || itemReader["available"].ToString().Equals("True"))
                    {
                        available = "Available";
                    }
                    else
                    {
                        available = "Not available";
                    }

                    String staffonly;
                    if (itemReader["staffOnly"].ToString().Equals(1) || itemReader["staffOnly"].ToString().Equals("True"))
                    {
                        staffonly = "(Staff only)";
                    }
                    else
                    {
                        staffonly = "";
                    }

                    //For each item it creates a title div and collapsible description div
                    //Div to wrap title and item
                    inventoryList.InnerHtml += "<div class='itemcontainer'>";

                    //Title divs are given ids like category1item2title
                    String titleId = "category" + categoryNum + "item" + itemNum + "title";
                    String descriptionId = "category" + categoryNum + "item" + itemNum + "description";
                    String imagesrc = itemReader["imagePath"].ToString();
                    if (imagesrc == "")
                    {
                        imagesrc = "../Images/default.png";
                    }

                    //Title div
                    inventoryList.InnerHtml += "<div id='" + titleId + "' class='nav-toggle' href='#" + descriptionId + "' >"
                        + itemReader["name"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class='italic'>" + staffonly + "</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + available + " &#9654;</div>"
                        //Description div
                        + "<div id='" + descriptionId + "' class='descriptionclass' style='display:none'>" 
                            + "<img height='200px' width='260px' src='" + imagesrc + "'/><br/>"
                            + itemReader["description"].ToString() + "<br/>"
                          //  + "<button type='button' id='" + itemReader["itemId"].ToString() + "' onClientClick='makeRequest(" + itemReader["itemId"] + ", " + itemReader["name"] + ")'>Make A Request</button>"
                            + "</div>";

                    inventoryList.InnerHtml += "</div>";
                  //  itemAt.Add(itemReader["itemId"].ToString(), itemReader["itemName"].ToString());
                    itemNum++;
                }

                inventoryList.InnerHtml += "</div>";
                categoryNum++;
            }

        }
        catch (SqlException ex)
        {
           throw ex;
           // inventoryList.InnerHtml = "<h2>Server currently unavailable.</h2>";
        }
        finally
        {
            conn.Close();
        }

    }

    //public void makeRequest(string idnum, string itemname)
    //{
    //    inventoryList.InnerHtml += "<p>" + idnum + " " + itemname + "</p>";
    //}

}