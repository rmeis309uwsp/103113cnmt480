<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Pages_Checkout" %>

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
           <b>Existing Requests:</b>
       </td>
       <td>
           <asp:DropDownList ID="requestList" runat="server" OnSelectedIndexChanged="requestList_SelectedIndexChanged" AutoPostBack="true" ViewStateMode="Enabled" width="400px"/>
       </td>
    </tr>
    <tr>
       <td style="width:98px;"></td>
       <td>
           <asp:Button ID="importRequestBtn" runat="server" Text="Import Selected Request" OnClick="importRequestBtn_Click" CausesValidation="False"/>
       </td>
   </tr>
   <tr>
       <td style="width:98px;"></td>
       <td>
           <asp:Button ID="deleteRequestBtn" runat="server" Text="Delete Selected Request" OnClick="deleteRequestBtn_Click" CausesValidation="False"/>
        </td>
   </tr>
    <tr>
        <td style="width:98px">
            <b>Select a category:</b>
        </td>
        <td>
            <asp:DropDownList ID="categoryList" runat="server" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width:98px">
            <b>Select an item:</b>
        </td>
        <td>
            <asp:DropDownList ID="itemList" runat="server" OnSelectedIndexChanged="itemList_SelectedIndexChanged"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>First Name:</b>
        </td>
        <td>
            <asp:TextBox ID="firstNameTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="firstNameRequired" runat="server" ControlToValidate="firstNameTb" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>Last Name:</b>
        </td>
        <td>
            <asp:TextBox ID="lastNameTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="lastNameRequired" runat="server" ControlToValidate="lastNameTb" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>Email:</b>
        </td>
        <td>
            <asp:TextBox ID="emailTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="emailTb" ErrorMessage="*"></asp:RequiredFieldValidator>
            <!-- Add email format validator -->
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>Phone #:</b>
        </td>
        <td>
            <asp:TextBox ID="phoneNumTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="phoneNumRequired" runat="server" ControlToValidate="phoneNumTb" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px;">
            <b>8-digit UWSP ID Number:</b>
        </td>
        <td style="height: 90px">
            <asp:TextBox ID="uwspIdTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="uwspIdRequired" runat="server" ControlToValidate="uwspIdTb" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width:98px;"><b>Role:</b></td>
        <td>
            <asp:RadioButtonList ID="roleButtons" runat="server">
                   <asp:ListItem runat="server" text="Student" />
                   <asp:ListItem runat="server" text="Faculty"/>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="roleRequired" runat="server" ControlToValidate="roleButtons" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 150px">
            <b>Due Date/Time:</b>
        </td>
        <td>
            <asp:TextBox ID="dueDateTb" class="datepicker" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="dueDateRequired" runat="server" ControlToValidate="dueDateTb" ErrorMessage="*"></asp:RequiredFieldValidator>
<%--            <asp:DropDownList ID="hourList" runat="server" AutoPostBack="true" ViewStateMode="Enabled">
                <asp:ListItem>12:00 AM</asp:ListItem>
                <asp:ListItem>01:00 AM</asp:ListItem>
                <asp:ListItem>02:00 AM</asp:ListItem>
                <asp:ListItem>03:00 AM</asp:ListItem>
                <asp:ListItem>04:00 AM</asp:ListItem>
                <asp:ListItem>05:00 AM</asp:ListItem>
                <asp:ListItem>06:00 AM</asp:ListItem>
                <asp:ListItem>07:00 AM</asp:ListItem>
                <asp:ListItem>08:00 AM</asp:ListItem>
                <asp:ListItem>09:00 AM</asp:ListItem>
                <asp:ListItem>10:00 AM</asp:ListItem>
                <asp:ListItem>11:00 AM</asp:ListItem>
                <asp:ListItem>12:00 PM</asp:ListItem>
                <asp:ListItem>01:00 PM</asp:ListItem>
                <asp:ListItem>02:00 PM</asp:ListItem>
                <asp:ListItem>03:00 PM</asp:ListItem>
                <asp:ListItem>04:00 PM</asp:ListItem>
                <asp:ListItem>05:00 PM</asp:ListItem>
                <asp:ListItem>06:00 PM</asp:ListItem>
                <asp:ListItem>07:00 PM</asp:ListItem>
                <asp:ListItem>08:00 PM</asp:ListItem>
                <asp:ListItem>09:00 PM</asp:ListItem>
                <asp:ListItem>10:00 PM</asp:ListItem>
                <asp:ListItem>11:00 PM</asp:ListItem>
            </asp:DropDownList>--%>
        </td>
    </tr>
    <tr>
        <td style="width:98px;">
            <b>Agreement form signed?</b>
        </td>
        <td>
            <asp:CheckBox ID="agreementBox" runat="server"/>
        </td>
    </tr>
    <tr>           
        <td style="width: 98px">
            <b>Purpose for checkout:</b>
        </td>
        <td>
            <asp:TextBox ID="purposeTb" runat="server" Width="400px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="purposeRequired" runat="server" ControlToValidate="purposeTb" ErrorMessage="*"></asp:RequiredFieldValidator>
            
        </td>
    </tr>       
</table>
<asp:Button ID="saveRequest" runat="server" Text="Make Request" onclick="saveCheckout_Click"/><br />
</asp:Content>
