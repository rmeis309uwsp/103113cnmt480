<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Viewcheckout.aspx.cs" Inherits="Pages_Viewcheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="checkoutId" DataSourceID="sds_viewcheckout" Height="228px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1018px">
        <Columns>
            <asp:CheckBoxField DataField="agreementSigned" HeaderText="Agreement" SortExpression="agreementSigned">
            <HeaderStyle Font-Size="Small" />
            <ItemStyle Font-Size="Smaller" />
            </asp:CheckBoxField>
            <asp:BoundField DataField="fine" HeaderText="Fine" SortExpression="fine">
            <HeaderStyle Font-Size="Small" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Requested For Date" SortExpression="requestedForDate">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("requestedForDate") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("requestedForDate") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Font-Size="Small" />
                <ItemStyle Font-Size="Small" />
            </asp:TemplateField>
            <asp:BoundField DataField="requestSentDate" HeaderText="Request Sent Date" SortExpression="requestSentDate">
            <ControlStyle Font-Size="Small" />
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="checkInDate" HeaderText="Check In Date" SortExpression="checkInDate">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="checkOutDate" HeaderText="Check Out Date" SortExpression="checkOutDate">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="dueDate" HeaderText="Due Date" SortExpression="dueDate">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="personLName" HeaderText="Last Name" SortExpression="personLName">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="personFName" HeaderText="First Name" SortExpression="personFName">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="personPhone" HeaderText="Phone" SortExpression="personPhone">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="personEmail" HeaderText="Email" SortExpression="personEmail">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="personRole" HeaderText="Role" SortExpression="personRole">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="personUwspId" HeaderText="Uwsp ID" SortExpression="personUwspId">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="itemId" HeaderText="Item ID" SortExpression="itemId">
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
            <asp:BoundField DataField="checkoutId" HeaderText="Check Out ID" InsertVisible="False" ReadOnly="True" SortExpression="checkoutId">
            <FooterStyle Font-Size="Smaller" />
            <HeaderStyle Font-Size="Smaller" />
            <ItemStyle Font-Size="Smaller" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sds_viewcheckout" runat="server" ConnectionString="<%$ ConnectionStrings:CNMTInventoryConnectionString %>" SelectCommand="SELECT [agreementSigned], [fine], [requestedForDate], [requestSentDate], [checkInDate], [checkOutDate], [dueDate], [personLName], [personFName], [personPhone], [personEmail], [personRole], [personUwspId], [itemId], [checkoutId] FROM [checkout] ORDER BY [dueDate]"></asp:SqlDataSource>
</asp:Content>

