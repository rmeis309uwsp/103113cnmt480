﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Inventory_overview.aspx.cs" Inherits="Pages_Inventory_overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<<<<<<< HEAD
    <h3>
        Available Items:</h3>
    <h3>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Pages/Inventory_Add.aspx">Add new Item</asp:LinkButton>
</h3>
    <h3>
        &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="itemid" DataSourceID="sds_Items" CellPadding="3" GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" Width="986px" ShowFooter="True">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField HeaderText="itemid" InsertVisible="False" SortExpression="itemid">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("itemid") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("itemid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:TemplateField HeaderText="categoryname" SortExpression="categoryname">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("categoryname") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("categoryname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="description" SortExpression="description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="imagepath" HeaderText="imagepath" SortExpression="imagepath" />
                <asp:TemplateField HeaderText="available" SortExpression="available">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("available") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("available") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="staffonly" SortExpression="staffonly">
                    <EditItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("staffonly") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("staffonly") %>' Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
        <asp:SqlDataSource ID="sds_Items" runat="server" ConnectionString="<%$ ConnectionStrings:Database %>" DeleteCommand="DELETE FROM [items] WHERE [itemid] = @itemid" InsertCommand="INSERT INTO [items] ([name], [categoryname], [description], [imagepath], [available], [staffonly]) VALUES (@name, @categoryname, @description, @imagepath, @available, @staffonly)" SelectCommand="SELECT [itemid], [name], [categoryname], [description], [imagepath], [available], [staffonly] FROM [items]" UpdateCommand="UPDATE [items] SET [name] = @name, [categoryname] = @categoryname, [description] = @description, [imagepath] = @imagepath, [available] = @available, [staffonly] = @staffonly WHERE [itemid] = @itemid">
            <DeleteParameters>
                <asp:Parameter Name="itemid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="categoryname" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="imagepath" Type="String" />
                <asp:Parameter Name="available" Type="Boolean" />
                <asp:Parameter Name="staffonly" Type="Boolean" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="categoryname" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="imagepath" Type="String" />
                <asp:Parameter Name="available" Type="Boolean" />
                <asp:Parameter Name="staffonly" Type="Boolean" />
                <asp:Parameter Name="itemid" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
</h3>
    <h3>
        &nbsp;</h3>
=======
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
>>>>>>> origin/12/19
</asp:Content>

