<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Inventory_Add.aspx.cs" Inherits="Pages_Inventory_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Add new Item</h3>
    <table cellspacing="15" class="itemTable">
        
        <tr>
            <td style="width: 98px">
                <b>Name:</b>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 98px">
                <b>Category:</b>
            </td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCategory" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 90px;">
                <b>Description:</b>
            </td>
            <td style="height: 90px">
                <asp:TextBox ID="txtDescription" runat="server" Width="300px" Height="66px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 98px">
                <b>Available:</b>
            </td>
            <td>
                <asp:TextBox ID="txtAvailable" runat="server" Width="50px"></asp:TextBox>
               <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAvailable" ErrorMessage="*"></asp:RequiredFieldValidator>-->
            </td>
        </tr>
        <tr>           <td style="width: 98px">
                <b>Staff Only:</b>
            </td>
            <td>
            <!--    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStaff" ErrorMessage="*"></asp:RequiredFieldValidator>-->
                <asp:TextBox ID="txtStaff" runat="server" Width="34px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 63px;">
                <b>Image:</b>
            </td>
            <td style="height: 63px">
                <asp:DropDownList ID="ddlImage" runat="server" Width="300px">
                </asp:DropDownList>
                <br/>
                <asp:FileUpload ID="FileUpload1" runat="server" /> 
                <asp:Button ID="btnUploadImage" runat="server" Text="Upload Image" 
                    onclick="btnUploadImage_Click" CausesValidation="False" /> 
            </td>
            
        </tr>
       
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    
    

</asp:Content>