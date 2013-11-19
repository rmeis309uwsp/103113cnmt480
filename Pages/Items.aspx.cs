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

        foreach (Coffee coffee in inventoryList)
        {
            sb.Append(
                string.Format(
                    @"<table class='coffeeTable'>
            <tr>
                <th rowspan='6' width='150px'><img runat='server' src='{6}' /></th>
                <th width='50px'>Name: </td>
                <td>{0}</td>
            </tr>

            <tr>
                <th>Type: </th>
                <td>{1}</td>
            </tr>

            <tr>
                <th>Price: </th>
                <td>{2} $</td>
            </tr>

            <tr>
                <th>Roast: </th>
                <td>{3}</td>
            </tr>

            <tr>
                <th>Origin: </th>
                <td>{4}</td>
            </tr>

            <tr>
                <td colspan='2'>{5}</td>
            </tr>           
            
           </table>",
                    coffee.name, coffee.type, coffee.price, coffee.roast, coffee.country, coffee.review, coffee.image));

            lblOuput.Text = sb.ToString();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPage();
    }
}