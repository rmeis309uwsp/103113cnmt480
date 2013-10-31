﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory.aspx.cs" Inherits="Pages_Coffee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Select a type:
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="sds_type" DataTextField="type" DataValueField="type" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="sds_type" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Database %>" 
        SelectCommand="SELECT DISTINCT [type] FROM [coffee] ORDER BY [type]" ProviderName="System.Data.SqlClient">
    </asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
</p>
</asp:Content>

