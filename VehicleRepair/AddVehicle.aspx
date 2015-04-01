<%@ Page Title="Add Vehicle" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="AddVehicle.aspx.cs" Inherits="VehicleRepair.AddVehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>Add Vehicle</h2>
    
    <asp:DetailsView ID="AddVehicleDetailsView" runat="server" HeaderText="Add New Vehicle"
                       AutoGenerateRows="False" DefaultMode="Insert" DataKeyNames="Registration"
                       oniteminserting="AddVehicleDetailsView_ItemInserting" 
                       onmodechanging="AddVehicleDetailsView_ModeChanging" 
        CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="Beige" Font-Bold="True" ForeColor="#A62900" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
            <asp:DynamicField DataField="registration" HeaderText="Registration" />
            <asp:DynamicField DataField="make" HeaderText="Make" />
            <asp:DynamicField DataField="model" HeaderText="Model" />
            <asp:DynamicField DataField="type" HeaderText="Type" />
            <asp:DynamicField DataField="year" HeaderText="Year" />
            <asp:DynamicField DataField="color" HeaderText="Color" />
            <asp:DynamicField DataField="vin" HeaderText="Vin #" />
            <asp:DynamicField DataField="capacity" HeaderText="Capacity" />
            <asp:DynamicField DataField="fuelType" HeaderText="Fuel Type" />
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
