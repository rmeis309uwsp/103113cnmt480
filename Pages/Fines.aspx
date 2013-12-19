<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Fines.aspx.cs" Inherits="Pages_Fines" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="checkoutId" DataSourceID="sbs_Fines">
        <Columns>
            <asp:CommandField ShowDeleteButton="True">
            <ItemStyle Font-Size="Smaller" />
            </asp:CommandField>
            <asp:BoundField DataField="checkoutId" HeaderText="Checkout ID" InsertVisible="False" ReadOnly="True" SortExpression="checkoutId">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="fine" HeaderText="Fine" SortExpression="fine">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="activeCheckout" HeaderText="Active Checkout" SortExpression="activeCheckout">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="activeRequest" HeaderText="Active Request" SortExpression="activeRequest">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:CheckBoxField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sbs_Fines" runat="server" ConnectionString="<%$ ConnectionStrings:CNMTInventoryConnectionString %>" DeleteCommand="DELETE FROM [checkout] WHERE [checkoutId] = @checkoutId" InsertCommand="INSERT INTO [checkout] ([fine], [activeCheckout], [activeRequest]) VALUES (@fine, @activeCheckout, @activeRequest)" SelectCommand="SELECT [fine], [activeCheckout], [activeRequest], [checkoutId] FROM [checkout] ORDER BY [fine] DESC" UpdateCommand="UPDATE [checkout] SET [fine] = @fine, [activeCheckout] = @activeCheckout, [activeRequest] = @activeRequest WHERE [checkoutId] = @checkoutId">
        <DeleteParameters>
            <asp:Parameter Name="checkoutId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="fine" Type="Decimal" />
            <asp:Parameter Name="activeCheckout" Type="Boolean" />
            <asp:Parameter Name="activeRequest" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="fine" Type="Decimal" />
            <asp:Parameter Name="activeCheckout" Type="Boolean" />
            <asp:Parameter Name="activeRequest" Type="Boolean" />
            <asp:Parameter Name="checkoutId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

