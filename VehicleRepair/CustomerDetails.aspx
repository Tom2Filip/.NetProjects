<%@ Page ViewStateEncryptionMode="Always" Title="Customer Details" Language="C#" MasterPageFile="~/VehicleRepair.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="VehicleRepair.CustomerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lblCount" runat="server"></asp:Label>
    <asp:Label ID="lblError" runat="server"></asp:Label>

    <asp:EntityDataSource ID="CustomerDetailsEntityDataSource" runat="server" 
        ConnectionString="name=VehicleEntities" 
        DefaultContainerName="VehicleEntities" Include="PhoneNumbers"
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
        EnableUpdate="True" EntitySetName="Customers" EntityTypeFilter="" 
        Select="" Where="it.customerID = @Customer">
        <WhereParameters>
            <asp:QueryStringParameter DbType="Int32" Name="Customer" QueryStringField="customerID" />
        </WhereParameters>        
    </asp:EntityDataSource>

    <asp:DetailsView ID="CustomerDetailsView" runat="server" HeaderText="Customer Details" 
        AutoGenerateRows="False" DataKeyNames="customerID" Width="300" 
        DataSourceID="CustomerDetailsEntityDataSource" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
        	 <asp:BoundField DataField="customerID" HeaderText="Customer ID" ReadOnly="True" SortExpression="customerID" />
            <asp:TemplateField HeaderText="First Name" SortExpression="firstName">
                <ItemTemplate>
                    <asp:DynamicControl ID="FirstNameLabel" runat="server" DataField="firstName" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate>
                <asp:DynamicControl ID="FirstNameTextBox" runat="server" DataField="firstName" Mode="Edit" ValidationGroup="custEditGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="FirstNameTextBox" runat="server" DataField="firstName" Mode="Edit" ValidationGroup="custEditGroup"/>
                </InsertItemTemplate>
           </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name" SortExpression="lastName">
                <ItemTemplate>
                    <asp:DynamicControl ID="LastNameLabel" runat="server" DataField="lastName" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DynamicControl ID="LastNameTextBox" runat="server" DataField="lastName" Mode="Edit" ValidationGroup="custEditGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="LastNameTextBox" runat="server" DataField="lastName" Mode="Edit" ValidationGroup="custEditGroup" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adress" SortExpression="adress">
                <ItemTemplate>
                    <asp:DynamicControl ID="AdresssLabel" runat="server" DataField="adress" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DynamicControl ID="AdresssTextBox" runat="server" DataField="adress" Mode="Edit" ValidationGroup="custEditGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="AdresssTextBox" runat="server" DataField="adress" Mode="Edit" ValidationGroup="custEditGroup" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="City" SortExpression="city">
                <ItemTemplate>
                    <asp:DynamicControl ID="CityLabel" runat="server" DataField="city" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DynamicControl ID="CityTextBox" runat="server" DataField="city" Mode="Edit" ValidationGroup="custEditGroup"/>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="CityTextBox" runat="server" DataField="city" Mode="Edit" ValidationGroup="custEditGroup" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="State" SortExpression="state">
                <ItemTemplate>
                    <asp:DynamicControl ID="StateLabel" runat="server" DataField="state" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DynamicControl ID="StateTextBox" runat="server" DataField="state" Mode="Edit" ValidationGroup="custEditGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="StateTextBox" runat="server" DataField="state" Mode="Edit" ValidationGroup="custEditGroup" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Postal Code" SortExpression="postCode">
                <ItemTemplate>
                    <asp:DynamicControl ID="PostCodeLabel" runat="server" DataField="postCode" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DynamicControl ID="PostCodeTextBox" runat="server" DataField="postCode" Mode="Edit" ValidationGroup="custEditGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="PostCodeTextBox" runat="server" DataField="postCode" Mode="Edit" ValidationGroup="custEditGroup" />
                </InsertItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="email">
                <ItemTemplate>
                    <asp:DynamicControl ID="EmailLabel" runat="server" DataField="email" Mode="ReadOnly"/>
                </ItemTemplate>
                <EditItemTemplate> 
                    <asp:DynamicControl ID="EmailTextBox" runat="server" DataField="email" Mode="Edit" ValidationGroup="custEditGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="EmailTextBox" runat="server" DataField="email" Mode="Edit" ValidationGroup="custEditGroup" />
                </InsertItemTemplate>
            </asp:TemplateField>

            <asp:CommandField  ShowEditButton="true" EditText="Edit Record" ItemStyle-BackColor="Beige" ItemStyle-Font-Bold="True" ItemStyle-ForeColor="#A62900"
                                UpdateText="Update Record" ValidationGroup="custEditGroup" />
         </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>
     <asp:ValidationSummary ID="CustomerDetailsViewValidation" runat="server" ValidationGroup="custEditGroup" />
    <br />

    <asp:EntityDataSource ID="vehiclesEntityDataSource" runat="server" 
        ConnectionString="name=VehicleEntities" DefaultContainerName="VehicleEntities" 
        AutoGenerateWhereClause="false" EnableFlattening="False" EnableInsert="false" EnableUpdate="false"
        EnableDelete="true" EntitySetName="Vehicles" Where="it.customerID= @Customer">
        <WhereParameters>
           <asp:QueryStringParameter DbType="Int32" Name="Customer" QueryStringField="customerID" /> 
        </WhereParameters>   
    </asp:EntityDataSource>


    <asp:GridView ID="vehiclesGridView" runat="server" DataSourceID="vehiclesEntityDataSource" 
                  AutoGenerateColumns="False" 
                  DataKeyNames="customerID,registration" EmptyDataText="No vehicles"
                  ShowHeaderWhenEmpty="True" AllowSorting="True" 
                  onrowdeleted="vehiclesGridView_RowDeleted" CellPadding="4" 
                  ForeColor="#333333" GridLines="None" RowStyle-HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ItemStyle-ForeColor="#A62900" ItemStyle-Font-Bold="true"
                                                        ItemStyle-BackColor="Beige"/>
            <asp:BoundField DataField="customerID" HeaderText="Customer ID" />
            <asp:BoundField DataField="registration" HeaderText="Registration" />
            <asp:BoundField DataField="make" HeaderText="Make" />
            <asp:BoundField DataField="model" HeaderText="Model" />
            <asp:BoundField DataField="type" HeaderText="Type" />
            <asp:BoundField DataField="year" HeaderText="Year" />
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
    
    <br />
    
    <asp:EntityDataSource ID="phonesEntityDataSource" runat="server"
        ConnectionString="name=VehicleEntities" AutoGenerateWhereClause="false"
        DefaultContainerName="VehicleEntities" EnableFlattening="False" 
        EntitySetName="PhoneNumbers" Where="it.customerID= @Customer" EnableDelete="True" 
        EnableUpdate="True" EnableInsert="true">
        <WhereParameters>
           <asp:QueryStringParameter DbType="Int32" Name="Customer" QueryStringField="customerID" /> 
        </WhereParameters>   
      </asp:EntityDataSource>
     
                            
      <asp:GridView ID="phonesGridView" runat="server" AutoGenerateColumns="False"
                 DataSourceID="phonesEntityDataSource"
                 DataKeyNames="customerID,phoneType,number"
                 ShowHeaderWhenEmpty="True" AllowSorting="True" 
        onrowediting="phonesGridView_RowEditing" 
        onrowupdating="phonesGridView_RowUpdating" 
        onrowupdated="phonesGridView_RowUpdated" 
        onrowdeleted="phonesGridView_RowDeleted" CellPadding="4" 
        ForeColor="#333333" GridLines="None" HorizontalAlign="NotSet" 
        RowStyle-HorizontalAlign="Center">
                 <EmptyDataTemplate>
                  <p>No phone numbers.</p>
                  </EmptyDataTemplate>
                 <AlternatingRowStyle BackColor="White" />
          <Columns>
              <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="False"
               ValidationGroup="phonesGridViewGroup" ItemStyle-ForeColor="#A62900" ItemStyle-Font-Bold="true" ItemStyle-BackColor="Beige" />
                 <asp:TemplateField HeaderText="Customer ID" SortExpression="customerID">
                  <EditItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Eval("customerID") %>'></asp:Label>
                    </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" Text='<%# Bind("customerID") %>'></asp:Label>
                  </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField HeaderText="Phone Type" SortExpression="phoneType">
                  <EditItemTemplate>
                      <asp:TextBox ID="phoneTypeTextBox" runat="server" Text='<%# Eval("phoneType") %>'></asp:TextBox>
                       <asp:RequiredFieldValidator ID="phoneTypeValidator" runat="server" ControlToValidate="phoneTypeTextBox"
                            Display="Dynamic" ValidationGroup="phonesGridViewGroup" ErrorMessage="Phone Type is required" Text="*" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate = "phoneTypeTextBox" ValidationGroup="phonesGridViewGroup" Text="*"
                         ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{4,20}$" runat="server" ErrorMessage="Phone type has to be minimum 4 and maximum 20 characters long.">
                        </asp:RegularExpressionValidator>
                  </EditItemTemplate>                     
                  <ItemTemplate>
                      <asp:Label ID="Label1" runat="server" Text='<%# Bind("phoneType") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                     <asp:TextBox ID="footerTextBox1" runat="server"></asp:TextBox>
                   </FooterTemplate>
              </asp:TemplateField>
                 <asp:TemplateField HeaderText="Number" SortExpression="number">
                  <EditItemTemplate>
                      <asp:TextBox ID="numberTextBox" runat="server" Text='<%# Eval("number") %>'></asp:TextBox>
                      <asp:RequiredFieldValidator ID="phoneNumberValidator" runat="server" ControlToValidate="numberTextBox" ValidationGroup="phonesGridViewGroup"
                                 Display="Dynamic" ErrorMessage="Phone number is required" Text="*" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate = "numberTextBox" ValidationGroup="phonesGridViewGroup"
                         ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{4,20}$" runat="server" ErrorMessage="Phone number hast to be minimum 4 and maximum 20 characters long." Text="*">
                        </asp:RegularExpressionValidator>
                       
                  </EditItemTemplate>
                  <ItemTemplate>
                      <asp:Label ID="Label2" runat="server" Text='<%# Eval("number") %>'></asp:Label>
                  </ItemTemplate>
                  <FooterTemplate>
                     <asp:TextBox ID="footerTextBox2" runat="server"></asp:TextBox>
                   </FooterTemplate>
              </asp:TemplateField>
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
        <asp:ValidationSummary ID="phonesGridViewValidationSummary" runat="server" ValidationGroup="phonesGridViewGroup" />
                     
        <p><asp:Label ID="lblAdd" runat="server"></asp:Label></p>                    
        <br /><br />

        
    <asp:DetailsView ID="insertPhoneDetailsView" runat="server" AutoGenerateRows="False" 
        DefaultMode="Insert" HeaderText="Insert New Phone"
        DataKeyNames="phoneType,number,customerID" oniteminserting="insertPhoneDetailsView_ItemInserting" 
        onmodechanging="insertPhoneDetailsView_ModeChanging" 
        oniteminserted="insertPhoneDetailsView_ItemInserted" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
        <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
        <Fields>
             <asp:TemplateField HeaderText="PhoneType" SortExpression="phoneType">
                <EditItemTemplate>
                   <asp:DynamicControl ID="insertPhoneTypeTextBox" runat="server" DataField="phoneType" Mode="Edit" ValidationGroup="insertPhoneGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                     <asp:DynamicControl ID="insertPhoneTypeTextBox" EnableViewState="true" runat="server" DataField="phoneType" Mode="Insert" ValidationGroup="insertPhoneGroup" />
                 </InsertItemTemplate>
                <ItemTemplate>
                    <asp:DynamicControl ID="insertPhoneTypeLabel" runat="server" DataField="phoneType" Mode="ReadOnly" ValidationGroup="insertPhoneGroup" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone Number" SortExpression="number">
                <EditItemTemplate>
                    <asp:DynamicControl ID="insertPhoneNumberTextBox" runat="server" DataField="number" Mode="Edit" ValidationGroup="insertPhoneGroup" />
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DynamicControl ID="insertPhoneNumberTextBox" EnableViewState="true" runat="server" DataField="number" Mode="Insert" ValidationGroup="insertPhoneGroup" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:DynamicControl ID="insertPhoneNumberLabel" runat="server" DataField="number" Mode="ReadOnly" ValidationGroup="insertPhoneGroup" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="true" ShowCancelButton="true" ValidationGroup="insertPhoneGroup"
                                       ItemStyle-BackColor="Beige" ItemStyle-Font-Bold="True" ItemStyle-ForeColor="#A62900" />           
        </Fields>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
    </asp:DetailsView>
    <asp:ValidationSummary ID="InsertPhoneDetailsViewValidation" runat="server" ValidationGroup="insertPhoneGroup" />
    
    <asp:Label ID="lblInsertPhone" runat="server"></asp:Label>
        
</asp:Content>
