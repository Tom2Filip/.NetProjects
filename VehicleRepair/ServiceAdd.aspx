<%@ Page Title="Add New Service" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="ServiceAdd.aspx.cs" Inherits="VehicleRepair.ServiceAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:DetailsView ID="vehicleServiceDetailsView" runat="server" AutoGenerateRows="False" 
                     DefaultMode="Insert" DataKeyNames="id" HeaderText="Add New Service" 
                     oniteminserting="vehicleServiceDetailsView_ItemInserting" 
                     onmodechanging="vehicleServiceDetailsView_ModeChanging" 
        CellPadding="4" ForeColor="#333333" GridLines="None" >
                     <AlternatingRowStyle BackColor="White" />
                     <CommandRowStyle BackColor="Beige" Font-Bold="True" ForeColor="#A62900" />
                     <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
                     <Fields>
                      <asp:DynamicField DataField="registration" HeaderText="Registration"  ReadOnly="true"/>
                      <asp:DynamicField DataField="odometer" HeaderText="Km" />
                      <asp:DynamicField DataField="subject" HeaderText="Subject" />
                      <asp:TemplateField HeaderText="Description">
                      <InsertItemTemplate>
                       <asp:TextBox ID="descriptionTextBox" runat="server" TextMode="MultiLine" Height="150px" 
                        Width="350px"></asp:TextBox>
                      </InsertItemTemplate>
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="Date of Service">
                         <ItemTemplate> 
                          <asp:Label ID="BirthDateLabel" Runat="Server" 
                                     Text='<%# Eval("serviceDate", "{0:d}") %>' />
                        </ItemTemplate>
                        <InsertItemTemplate>
                        <asp:TextBox ID="serviceDateTextBox" runat="server" Text='<%# Bind("serviceDate", "{0:d}") %>' ></asp:TextBox>
                    <asp:ImageButton ID="calendarImage" runat="server" Height="17px" 
                        ImageUrl="~/images/calendar_icon.png" onclick="calendarImage_Click" />
                            <asp:Calendar ID="serviceCalendar" runat="server" Height="22px" Visible="False"
                                ImageUrl="~/images/calendar_icon.png" 
                                SelectedDate='<%# Bind("serviceDate") %>' 
                          onselectionchanged="serviceCalendar_SelectionChanged"></asp:Calendar>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                           <asp:TextBox ID="serviceDateTextBox" runat="server" Text='<%# Bind("serviceDate", "{0:d}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>                    
                      <asp:CommandField ShowInsertButton="true" InsertText="Insert Service" CancelText="Cancel" ShowCancelButton="true" />
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
