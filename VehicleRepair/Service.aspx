<%@ Page Title="Vehicle Service" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="VehicleRepair.Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DetailsView ID="vehicleServiceDetailsView" runat="server" AutoGenerateRows="False" 
                     DefaultMode="Edit" DataKeyNames="id" HeaderText="Service Details"
                        onmodechanging="vehicleServiceDetailsView_ModeChanging" 
        onitemupdating="vehicleServiceDetailsView_ItemUpdating" Height="316px" 
        Width="342px" style="margin-right: 0px" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
                     <AlternatingRowStyle BackColor="White" />
                     <CommandRowStyle BackColor="Beige" Font-Bold="True" ForeColor="#A62900" />
                     <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
                     <Fields>
                      <asp:DynamicField DataField="id" HeaderText="ID" ReadOnly="True" />
                      <asp:DynamicField DataField="registration" HeaderText="Registration" ReadOnly="True" />
                      <asp:DynamicField DataField="odometer" HeaderText="Km" />
                      <asp:DynamicField DataField="subject" HeaderText="Subject" />
                      <asp:TemplateField HeaderText="Description">
                      <EditItemTemplate>
                       <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" 
                              Text='<%# Bind("description") %>' Height="150px" Width="350px"></asp:TextBox>
                      </EditItemTemplate>
                      </asp:TemplateField>

             <asp:TemplateField HeaderText="Date of Service">
                   <InsertItemTemplate>
                        <asp:TextBox ID="serviceDateTextBox" runat="server" Text='<%# Bind("serviceDate", "{0:d}") %>'></asp:TextBox>
                     </InsertItemTemplate>
                      
                <EditItemTemplate>                   
                    <asp:TextBox ID="serviceDateTextBox" runat="server" Text='<%# Bind("serviceDate", "{0:d}") %>' ></asp:TextBox>
                    <asp:ImageButton ID="calendarImage" runat="server" Height="17px"
                        ImageUrl="~/images/calendar_icon.png" onclick="calendarImage_Click" />
                                      <asp:Calendar ID="serviceCalendar" Runat="Server"
                                        VisibleDate='<%# Eval("serviceDate") %>'
                                        SelectedDate='<%# Bind("serviceDate") %>' 
                        onselectionchanged="serviceCalendar_SelectionChanged" Visible="False" />
                         
               </EditItemTemplate>
              </asp:TemplateField>      
                                   

                      <asp:CommandField EditText="Edit" ShowEditButton="true" CancelText="Cancel" ShowCancelButton="true" />
                    </Fields>
                     <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                     <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:ValidationSummary ID="vehicleServiceDetailsViewValidationSummary" runat="server" ShowSummary="true" 
                                DisplayMode="BulletList"/>

    <asp:Label ID="lblMessage" runat="server"></asp:Label>  
    
</asp:Content>
