<%@ Page Title="Vehicles" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="Vehicles.aspx.cs" Inherits="VehicleRepair.Vehicles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       
    <asp:Label ID="lblError" runat="server" ></asp:Label>
    <asp:ObjectDataSource ID="VehiclesObjectDataSource" runat="server" 
                     TypeName="VehicleRepair.BLL.VehicleRepairBL"
                     SelectMethod="GetVehicles" DeleteMethod="DeleteVehicle"
                     OldValuesParameterFormatString="v{0}" >
                     </asp:ObjectDataSource>
     

     <h2>Vehicles by Registration</h2>
        Enter a vehilce registration
        <asp:TextBox ID="SearchTextBox" runat="server" ></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btnLink" 
        onclick="SearchButton_Click"/>
    <br/><br/>
    
                        
      <asp:GridView ID="VehiclesGridView" runat="server" AutoGenerateColumns="False" 
                    DataSourceID="VehiclesObjectDataSource" DataKeyNames="registration" 
                    onrowdeleting="VehiclesGridView_RowDeleting" 
                    EmptyDataText="There is no vehicles"
                    onselectedindexchanging="VehiclesGridView_SelectedIndexChanging" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" 
                    RowStyle-HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
              <asp:CommandField ShowDeleteButton="True" ShowSelectButton="true" ItemStyle-ForeColor="#A62900" ItemStyle-Font-Bold="true" ItemStyle-BackColor="Beige" />
              <asp:DynamicField DataField="registration" HeaderText="Registration" />
              <asp:DynamicField DataField="Make" HeaderText="Make" />
              <asp:DynamicField DataField="Model" HeaderText="Model" />
              <asp:DynamicField DataField="Type" HeaderText="Type" />
              <asp:DynamicField DataField="Year" HeaderText="Year" />
              <asp:HyperLinkField DataNavigateUrlFields="registration" HeaderText="Details"
                DataNavigateUrlFormatString="VehicleDetails.aspx?registration={0}" 
                Text="View Details..." />
          </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>

        <p><asp:LinkButton ID="AddVehicleLink" runat="server"  Visible="true" Enabled="true"
             Text="Add Vehicle" onclick="AddVehicleLink_Click" CssClass="btnLink" ForeColor="#A62900"></asp:LinkButton></p>

            <asp:label ID="lblServices" runat="server">Services for vehicle</asp:label>
            <asp:Label ID="lblRegistration" runat="server"></asp:Label>

             <asp:GridView ID="vehicleServicesGridView" runat="server" AutoGenerateColumns="False"
                            ShowHeaderWhenEmpty="True" EmptyDataText="There are no services for selected vehicle"
                            DataKeyNames="id"
                            onrowdeleting="vehicleServicesGridView_RowDeleting" CellPadding="4" 
                            ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center">                               
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                      <asp:CommandField ShowDeleteButton="True" ItemStyle-ForeColor="#A62900" ItemStyle-Font-Bold="true" ItemStyle-BackColor="Beige" />
                      <asp:DynamicField DataField="id" HeaderText="ID" ReadOnly="True" /> 
                      <asp:DynamicField DataField="odometer" HeaderText="KM" />
                      <asp:DynamicField DataField="subject" HeaderText="Subject" />
                      <asp:DynamicField DataField="serviceDate" HeaderText="Date" ApplyFormatInEditMode="True" />
                                           
                      <asp:HyperLinkField DataNavigateUrlFields="id" HeaderText="Details"
                            DataNavigateUrlFormatString="Service.aspx?id={0}" 
                            Text="View Details..." />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
             </asp:GridView>

             <p><asp:Label ID="lblMessage" runat="server"></asp:Label></p>

             <asp:LinkButton ID="btnAddService" runat="server" Text="Add Service" 
                              onclick="btnAddService_Click" CausesValidation="False" Height="15" CssClass="btnLink" ForeColor="#A62900"></asp:LinkButton>
                      
</asp:Content>
    