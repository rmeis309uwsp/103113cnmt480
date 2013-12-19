<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory_overview.aspx.cs" Inherits="Pages_Inventory_overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="itemId" DataSourceID="sds_Inventory_Overview">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True">
            <ItemStyle Font-Size="Smaller" />
            </asp:CommandField>
            <asp:BoundField DataField="itemId" HeaderText="Item ID" InsertVisible="False" ReadOnly="True" SortExpression="itemId">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="categoryName" HeaderText="Category" SortExpression="categoryName">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="imagePath" HeaderText="Image Path" SortExpression="imagePath">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="available" HeaderText="Available" SortExpression="available">
            <FooterStyle Font-Size="Smaller" />
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="staffOnly" HeaderText="Staff" SortExpression="staffOnly">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sds_Inventory_Overview" runat="server" ConnectionString="<%$ ConnectionStrings:CNMTInventoryConnectionString %>" DeleteCommand="DELETE FROM [items] WHERE [itemId] = @itemId" InsertCommand="INSERT INTO [items] ([name], [categoryName], [description], [imagePath], [available], [staffOnly]) VALUES (@name, @categoryName, @description, @imagePath, @available, @staffOnly)" SelectCommand="SELECT [itemId], [name], [categoryName], [description], [imagePath], [available], [staffOnly] FROM [items]" UpdateCommand="UPDATE [items] SET [name] = @name, [categoryName] = @categoryName, [description] = @description, [imagePath] = @imagePath, [available] = @available, [staffOnly] = @staffOnly WHERE [itemId] = @itemId">
        <DeleteParameters>
            <asp:Parameter Name="itemId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="categoryName" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="imagePath" Type="String" />
            <asp:Parameter Name="available" Type="Boolean" />
            <asp:Parameter Name="staffOnly" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="categoryName" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="imagePath" Type="String" />
            <asp:Parameter Name="available" Type="Boolean" />
            <asp:Parameter Name="staffOnly" Type="Boolean" />
            <asp:Parameter Name="itemId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

