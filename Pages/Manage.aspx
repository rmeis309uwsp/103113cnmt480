<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Manage.aspx.cs" Inherits="Pages_Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="inventoryList" runat="server"></div>
    <script src="../JavaScript/jquery-2.0.3.min.js" type="text/javascript"></script>
    <script src="../JavaScript/Home.js" type="text/javascript"></script>

    <h3><a id="A1" href="~/Pages/Inventory_Overview.aspx" runat="server">Manage Items</a></h3>
        <h3><a id="A2" href="~/Pages/Inventory_Add.aspx" runat="server">Add Items</a></h3>
        <h3><a id="A3" href="~/Pages/Checkout.aspx" runat="server">Checkout Item</a></h3>
         <h3><a id="A4" href="~/Pages/Viewcheckout.aspx" runat="server">View Currents Checkouts</a></h3>
         <h3><a id="A5" href="~/Pages/Fines.aspx" runat="server">Fines</a></h3>
</asp:Content>
