using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class Pages_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getInventory();
    }

    protected void getInventory()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
        string categoryQuery = "SELECT * FROM itemcategories";
        SqlCommand categoryCommand = new SqlCommand(categoryQuery, con);
        try
        {
            con.Open();
            SqlDataReader reader = categoryCommand.ExecuteReader();
            int categoryNum = 0;
            while (reader.Read())
            {
                //Div listing category - laptop, camera, etc. Gives divs ids of "category1", "category2", etc
                inventoryList.InnerHtml += "<div id='category" + categoryNum + "' runat='server'><h2 id='category" + categoryNum +
               "title'>" + reader["categoryname"].ToString() + "</h2>";
                int itemNum = 0;
                string itemQuery = "SELECT * FROM items WHERE categoryname= @categoryName";
                SqlCommand itemCommand = new SqlCommand(itemQuery, con);
                itemCommand.Parameters.AddWithValue("@categoryName", reader["categoryname"].ToString());
                SqlDataReader itemReader = itemCommand.ExecuteReader();
                while (itemReader.Read())
                {
                    //After each category header, for each item it creates a title div and collapsible description div
                    
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
                    if (itemReader["staffonly"].ToString().Equals(1) || itemReader["staffonly"].ToString().Equals("True"))
                    {
                        staffonly = "(Staff only)";
                    }
                    else
                    {
                        staffonly = "";
                    }

                    //Div to wrap title and item
                    inventoryList.InnerHtml += "<div class='itemcontainer'>";

                    //Title divs are given ids like category1item2title
                    String titleId = "category" + categoryNum + "item" + itemNum + "title";
                    String descriptionId = "category" + categoryNum + "item" + itemNum + "description";

                    //Title div
                    inventoryList.InnerHtml += "<div id='" + titleId + "' class='nav-toggle' href='#" + descriptionId + "' >"
                        + itemReader["name"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class='italic'>" + staffonly + "</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + available + " &#9654;</div>"
                        //Description div
                        + "<div id='" + descriptionId + "' class='descriptionclass' style='display:none'>" 
                            + "<img height='200px' width='200px' src='" + itemReader["imagepath"].ToString() + "'/><br/>"
                            + itemReader["description"].ToString() + "<br/>"
                            + "<button type='button'>Make A Request</button>"
                            + "</div>";

                    inventoryList.InnerHtml += "</div>";
                    itemNum++;
                }

                inventoryList.InnerHtml += "</div>";
                categoryNum++;
            }

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
        }

    }

}