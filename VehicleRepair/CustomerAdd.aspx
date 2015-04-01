<%@ Page Title="Add New Customer" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="CustomerAdd.aspx.cs" Inherits="VehicleRepair.CustomerAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:DetailsView ID="AddCustomerDetailsView" runat="server" 
                       AutoGenerateRows="False" DefaultMode="Insert" 
        DataKeyNames="customerID" HeaderText="Add New Customer" 
        oniteminserting="AddCustomerDetailsView_ItemInserting" 
        onmodechanging="AddCustomerDetailsView_ModeChanging" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="Beige" Font-Bold="True" ForeColor="#A62900" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
            <asp:DynamicField DataField="firstName" HeaderText="FirstName" />
            <asp:DynamicField DataField="lastName" HeaderText="Last Name" />
            <asp:DynamicField DataField="adress" HeaderText="Adress" />
            <asp:DynamicField DataField="city" HeaderText="City" />
            <asp:DynamicField DataField="state" HeaderText="State" />
            <asp:DynamicField DataField="postCode" HeaderText="Postal Code" />
            <asp:DynamicField DataField="email" HeaderText="Email" />
            <asp:CommandField InsertText="Add" ShowInsertButton="True" />
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>

    <asp:ValidationSummary ID="AddVehiclesDetailsViewValidationSummary" runat="server" ShowSummary="true" 
                                DisplayMode="BulletList"/>

    <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>

</asp:Content>
