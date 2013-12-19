<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Make_a_Request.aspx.cs" Inherits="Pages_Make_a_Request" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../JavaScript/jquery-2.0.3.min.js" type="text/javascript"></script>
<script src="../JavaScript/jquery-ui.js" type="text/javascript"></script>
<script src="../JavaScript/Datepicker.js" type="text/javascript"></script>
<link rel="stylesheet" href="../Css/JQueryUI/jquery.ui.datepicker.css"/>
<link rel="Stylesheet" href="../Css/JQueryUI/jquery-ui.css" />
<link rel="Stylesheet" href="../Css/JQueryUI/jquery.ui.base.css" />

<h3>Make a Request</h3><br />
<h3 id="requestConfirm" runat="server" style="font-style:italic;"></h3><br />
<table cellspacing="15" class="itemTable" id="requestForm" runat="server">
        
    <tr>
        <td style="width:98px">
            <b>Select a category:</b>
        </td>
        <td>
            <asp:DropDownList ID="categoryList" runat="server" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </td>
        <td style="width:98px">
            <b>Select an item:</b>
        </td>
        <td>
            <asp:DropDownList ID="itemList" runat="server" OnSelectedIndexChanged="itemList_SelectedIndexChanged" AutoPostBack="true"  ViewStateMode="Enabled"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>First Name:</b>
        </td>
        <td>
            <asp:TextBox ID="firstNameTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="firstNameRequired" runat="server" ControlToValidate="firstNameTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>Last Name:</b>
        </td>
        <td>
            <asp:TextBox ID="lastNameTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="lastNameRequired" runat="server" ControlToValidate="lastNameTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>Email:</b>
        </td>
        <td>
            <asp:TextBox ID="emailTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="emailTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="emailRegEx" runat="server"
            ErrorMessage="Email must be in the form of address@uwsp.edu." ControlToValidate="emailTb" ForeColor="Red"
            ValidationExpression="[0-9A-Za-z]{3,}@^uwsp$\.^edu$"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px">
            <b>Phone #:</b>
        </td>
        <td>
            <asp:TextBox ID="phoneNumTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="phoneNumRequired" runat="server" ControlToValidate="phoneNumTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 98px;">
            <b>8-digit UWSP ID Number:</b>
        </td>
        <td style="height: 90px">
            <asp:TextBox ID="uwspIdTb" runat="server" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="uwspIdRequired" runat="server" ControlToValidate="uwspIdTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="uwspIdExp" runat="server"
            ErrorMessage="Must be an 8-digit number." ControlToValidate="uwspIdTb" ForeColor="Red" ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width:98px;"><b>Role:</b></td>
        <td>
            <asp:RadioButtonList ID="roleButtons" runat="server">
                   <asp:ListItem runat="server" text="Student" />
                   <asp:ListItem runat="server" text="Faculty"/>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="roleRequired" runat="server" ControlToValidate="roleButtons" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 150px">
            <b>Date item is being requested for:</b>
        </td>
        <td>
            <asp:TextBox ID="requestedForDateTb" class="datepicker" runat="server" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requestedForDateRequired" runat="server" ControlToValidate="requestedForDateTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>           
        <td style="width: 98px">
            <b>Purpose for checkout:</b>
        </td>
        <td>
            <asp:TextBox ID="purposeTb" runat="server" Width="400px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="purposeRequired" runat="server" ControlToValidate="purposeTb" ErrorMessage="* Required"></asp:RequiredFieldValidator>
            
        </td>
    </tr>       
</table>
<asp:Button ID="saveRequest" runat="server" Text="Make Request" onclick="saveRequest_Click"/><br />
</asp:Content>