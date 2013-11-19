<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Items.aspx.cs" Inherits="Pages_Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        select a c<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sds_category" DataTextField="categoryname" DataValueField="categoryname">
        </asp:DropDownList>
        <asp:SqlDataSource ID="sds_category" runat="server" ConnectionString="Data Source=cnmtsrv1.uwsp.edu;Initial Catalog=CNMTInventory;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [itemcategories] ORDER BY [categoryname]"></asp:SqlDataSource>
        ategory
    </p>
    <p id="lblOutput">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>
</asp:Content>

