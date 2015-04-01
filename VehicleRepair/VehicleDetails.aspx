<%@ Page Title="Vehicle Details" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="VehicleDetails.aspx.cs" Inherits="VehicleRepair.VehicleDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
       <asp:DetailsView ID="vehicleDetailsView" runat="server" HeaderText="Vehicle Details" 
        AutoGenerateRows="False" DefaultMode="Edit" DataKeyNames="registration" 
        onitemcommand="vehicleDetailsView_ItemCommand" 
        onitemupdating="vehicleDetailsView_ItemUpdating" 
        onmodechanging="vehicleDetailsView_ModeChanging" CellPadding="4" 
           ForeColor="#333333" GridLines="None" >
           <AlternatingRowStyle BackColor="White" />
           <CommandRowStyle BackColor="Beige" Font-Bold="True" ForeColor="#A62900" />
           <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>        
            <asp:DynamicField DataField="registration" HeaderText="Registration" ReadOnly="true" />
            <asp:BoundField HeaderText="Owner" ReadOnly="True" />
            <asp:DynamicField DataField="make" HeaderText="Make"/>
            <asp:DynamicField DataField="model" HeaderText="Model" />
            <asp:DynamicField DataField="type" HeaderText="Type" />
            <asp:DynamicField DataField="year" HeaderText="Year" />
            <asp:DynamicField DataField="color" HeaderText="Color" />
            <asp:DynamicField DataField="vin" HeaderText="Vin #" />
            <asp:DynamicField DataField="capacity" HeaderText="Capacity" />
            <asp:DynamicField DataField="fuelType" HeaderText="Fuel Type" />
            <asp:CommandField InsertText="Add" ShowInsertButton="True" EditText="Edit" ShowEditButton="true"
                                 CancelText="Cancel" ShowCancelButton="true" />
         </Fields>
           <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
           <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:ValidationSummary ID="VehicleDetailsViewValidationSummary" runat="server" ShowSummary="true" 
                                DisplayMode="BulletList"/>
           
    <p><asp:Label ID="lblUpdateVehicle" runat="server"></asp:Label></p>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>

    <p>
    <asp:Button ID="btnOwner" runat="server" Text="Change vehicle owner" 
           onclick="btnOwner_Click" CssClass="btnLink" />
           </p>

    <asp:GridView ID="CustomersGridView" runat="server" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="customerID" 
        ForeColor="#333333" SelectedRowStyle-BackColor="#FF3300"
        GridLines="None" EmptyDataText="There are no customers" 
           onselectedindexchanging="CustomersGridView_SelectedIndexChanging" RowStyle-HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" ItemStyle-ForeColor="#A62900" ItemStyle-Font-Bold="true" ItemStyle-BackColor="Beige" />
            <asp:BoundField DataField="customerID" HeaderText="Customer ID" SortExpression="customerID" ReadOnly="True" />
            <asp:BoundField DataField="firstName" HeaderText="First Name" SortExpression="firstName" />
            <asp:BoundField DataField="lastName" HeaderText="Last Name" SortExpression="lastName" />                     
            <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
         </Columns>  
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />

<SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

        <p>
        <asp:Button ID="btnNewOwner" runat="server" Text="Select New Owner" 
                    onclick="btnNewOwner_Click" Visible="False" CssClass="btnLink" />
        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
        </p>
    
</asp:Content>
