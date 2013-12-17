<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Inventory_Add.aspx.cs" Inherits="Pages_Inventory_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3>Add new Item</h3>
    <table cellspacing="15" class="itemTable">
        
        <tr>
            <td style="width: 98px; height: 37px;">
                <b>Name:</b>
            </td>
            <td style="height: 37px">
                <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
                
            </td>
        </tr>
        <tr>
            <td style="width: 98px">
                <b>Category:</b>
            </td>
            <td>
                <asp:TextBox ID="txtCategory" runat="server" Width="300px"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 94px;">
                <b>Description:</b>
            </td>
            <td style="height: 94px">
                <asp:TextBox ID="txtDescription" runat="server" Width="300px" Height="66px" TextMode="MultiLine"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescription" ErrorMessage="*"></asp:RequiredFieldValidator>
              
                <br />
                <br />
              
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 7px;">
                <b>Available:</b>
            </td>
            <td style="height: 7px">
                <asp:CheckBox ID="CheckBox1" runat="server" />
              
                <br />
              
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 7px;">
                <b>Staff Only:</b>
            </td>
            <td style="height: 7px">
                <asp:CheckBox ID="CheckBox2" runat="server" />
              
                <br />
              
            </td>
        </tr>

        <tr>
            <td style="width: 98px; height: 63px;">
                <b>Image:</b>
            </td>
            <td style="height: 63px">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="246px" /> 
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*"></asp:RequiredFieldValidator>
                <br/>
            </td>
            
        </tr>
       
    </table>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click1" />
    
    

</asp:Content>