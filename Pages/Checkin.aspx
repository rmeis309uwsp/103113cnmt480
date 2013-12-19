<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkin.aspx.cs" Inherits="Pages_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../JavaScript/jquery-2.0.3.min.js" type="text/javascript"></script>
<script src="../JavaScript/jquery-ui.js" type="text/javascript"></script>
<script src="../JavaScript/Datepicker.js" type="text/javascript"></script>
<link rel="stylesheet" href="../Css/JQueryUI/jquery.ui.datepicker.css"/>
<link rel="Stylesheet" href="../Css/JQueryUI/jquery-ui.css" />
<link rel="Stylesheet" href="../Css/JQueryUI/jquery.ui.base.css" />

<h3>Check Out an Item</h3>
<h3 id="checkoutConfirm" runat="server" style="font-style:italic;"></h3><br />
<table cellspacing="15" class="itemTable" id="requestForm" runat="server">
        
   <tr>
       <td style="width:98px;">
           <b>Current Checkouts:</b>
       </td>
       <td>
           <asp:DropDownList ID="checkoutList" runat="server" OnSelectedIndexChanged="checkoutList_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled" width="400px"/>
       </td>
    </tr>
    <tr>
       <td style="width:98px;"></td>
       <td>
           <asp:Button ID="checkInBtn" runat="server" Text="Check In Selected Item" OnClick="checkInBtn_Click" CausesValidation="False"/>
       </td>
   </tr>
    </table>
</asp:Content>
