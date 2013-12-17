using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

public partial class Pages_Items : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }
    private void FillPage()
    {
        ArrayList inventoryList = new ArrayList();

        if (!IsPostBack)
        {
            inventoryList = ConnectionClass.GetInventoryByType("%");
        }
        else
        {
            inventoryList = ConnectionClass.GetInventoryByType(DropDownList1.SelectedValue);
        }

        StringBuilder sb = new StringBuilder();

        foreach (Items items in inventoryList)
        {
            sb.Append(
                string.Format(
                    @"<table class='itemTable'>
            <tr>
                <th rowspan='2' width='150px'><img runat='server' src='{2}' /></th>
                <th width='50px'>Name: </td>
                <td>{0}</td>
            </tr>

            <tr>
                <th>Category: </th>
                <td>{1}</td>
            </tr>

            <tr>
                <th>Description: </th>
                <td>{2} </td>
            </tr>
            <tr>
                <th>Description: </th>
                <td>{2} </td>
            </tr>
                   
            
           </table>",
                    items.name, items.categoryname, items.description /*items.available, items.staffonly,  items.imagepath*/));
            
            Label1.Text = sb.ToString();
        }
    
    }
  
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FillPage();
    }
}