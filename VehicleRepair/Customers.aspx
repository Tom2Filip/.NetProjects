<%@ Page Title="Customers" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="VehicleRepair.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <h2>Customers by Name</h2>
        Enter a customer name
        <asp:TextBox ID="SearchTextBox" runat="server" ></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btnLink"/>
    <br/><br/>
    
    <asp:EntityDataSource ID="CustomerEntityDataSource" runat="server" 
        ConnectionString="name=VehicleEntities" DefaultContainerName="VehicleEntities" 
        EnableDelete="True" EnableFlattening="False"
        EntitySetName="Customers">
    </asp:EntityDataSource>

    <asp:QueryExtender ID="SearchQueryExtender" runat="server" TargetControlID="CustomerEntityDataSource">
        <asp:SearchExpression SearchType="Contains" DataFields="firstName,lastName">
           <asp:ControlParameter ControlID="SearchTextBox"/>
        </asp:SearchExpression>
        
        <asp:OrderByExpression DataField="firstName" Direction="Ascending">
            <asp:ThenBy DataField="lastName" Direction="Ascending"/>
         </asp:OrderByExpression>
      </asp:QueryExtender>

     <asp:GridView ID="CustomersGridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="customerID" 
       DataSourceID="CustomerEntityDataSource" ForeColor="#333333" SelectedRowStyle-BackColor="Yellow"
        GridLines="None"
         EmptyDataText="There are no customers" 
            onrowdeleted="CustomersGridView_RowDeleted" 
            RowStyle-HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="false" ShowEditButton="false" 
                ShowCancelButton="true" ShowDeleteButton="True" ItemStyle-ForeColor="#A62900" ItemStyle-BackColor="Beige" ItemStyle-Font-Bold="true" />
            <asp:BoundField DataField="customerID" HeaderText="Customer ID" 
                SortExpression="customerID" ReadOnly="True" />
            <asp:BoundField DataField="firstName" HeaderText="First Name" 
                SortExpression="firstName" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" 
                SortExpression="lastName" />
            <asp:BoundField DataField="adress" HeaderText="Adress" 
                SortExpression="adress" />
            <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
            <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                       
            <asp:HyperLinkField DataNavigateUrlFields="customerID" HeaderText="Details"
                DataNavigateUrlFormatString="CustomerDetails.aspx?customerid={0}" 
                Text="View Details..." />    
        </Columns>  
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" Font-Underline="false" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
     
    <p><asp:LinkButton ID="AddCustomerLink" runat="server"  Visible="true" Enabled="true" CausesValidation="false"
             Text="Add New Customer" onclick="AddCustomerLink_Click" CssClass="btnLink" ForeColor="#A62900"></asp:LinkButton></p>

  </asp:Content>