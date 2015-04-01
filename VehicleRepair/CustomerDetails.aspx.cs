using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using System.Data;
using System.Collections;
using System.Data.Objects;
using System.Data.SqlClient;
    
namespace VehicleRepair
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        public string phoneTypeOld;
        public string phoneNumberOld;
        
        public int CustomerIDfromQueryString;

        protected void Page_Init(object sender, EventArgs e)
        {
             CustomerDetailsView.EnableDynamicData(typeof(Customer));
             insertPhoneDetailsView.EnableDynamicData(typeof(PhoneNumber));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // int CustomerIDfromQueryString;
           if (Request.QueryString["customerID"] == null || Request.QueryString["customerID"] == "")
           {
               Response.Redirect("Customers.aspx");
           }
           else
            {
                 CustomerIDfromQueryString= Convert.ToInt32(Request.QueryString["customerID"]);
            }
         }

        // Get the values on button Edit Click inside phones GridView        
        protected void phonesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
          phoneTypeOld = phonesGridView.DataKeys[e.NewEditIndex].Values[1].ToString();
          phoneNumberOld = phonesGridView.DataKeys[e.NewEditIndex].Values[2].ToString();

            ViewState["phoneTypeOld"] = phoneTypeOld;
            ViewState["phoneNumberOld"] = phoneNumberOld;
         }
        

        protected void phonesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // In this example, the GridView control will not automatically extract 
            // updated values from TemplateField column fields because they are not
            // using a two-way binding expression. So, the updated
            // values must be added manually to the NewValues dictionary.

            // Get the GridViewRow object that represents the row being edited
            // from the Rows collection of the GridView control.
            int index = phonesGridView.EditIndex;
            GridViewRow row = phonesGridView.Rows[index];

            // Get the controls that contain the updated values. In this
            // example, the updated values are contained in the TextBox 
            // controls declared in the EditItemTemplates of the TemplateField 
            // column fields in the GridView control.
            TextBox phoneType = (TextBox)row.FindControl("phoneTypeTextBox");
            TextBox number = (TextBox)row.FindControl("numberTextBox");

            // Add the updated values to the NewValues dictionary. Use the
            // parameter names declared in the parameterized update query 
            // string for the key names.
            e.NewValues["phoneType"] = phoneType.Text;
            e.NewValues["number"] = number.Text;
            
            string phoneTypeNew = phoneType.Text.Trim().ToString();
            string phoneNumberNew = number.Text.Trim().ToString();
                        
            phoneTypeOld = ViewState["phoneTypeOld"].ToString();
            phoneNumberOld = ViewState["phoneNumberOld"].ToString();
                             
            AddPhone(CustomerIDfromQueryString, phoneTypeNew, phoneNumberNew);             
                                            
        }
      
        protected void phonesGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception == null)
            {
               lblAdd.Text = "The update operation succeeded.";
            }
            else
            {
                // The update operation failed. Display an error message.
                // lblAdd.Text += e.AffectedRows.ToString() + " rows updated. " + e.Exception.Message;
                e.ExceptionHandled = true;
            }          
        }

        public void DeletePhone(int custID, string phoneType, string phoneNumber)
        {
            using (var context = new VehicleEntities())
            {
             PhoneNumber queryDelete = new PhoneNumber();
             queryDelete = context.PhoneNumbers.First(p=> p.customerID==custID && p.phoneType==phoneType && p.number==phoneNumber);
                context.DeleteObject(queryDelete);
                context.SaveChanges();                    
            }
        }

        public void AddPhone(int custID, string phoneType, string phoneNumber)
        {
            using (var context = new VehicleEntities())
               {
                 PhoneNumber queryAdd = new PhoneNumber
                    {
                        customerID = custID,
                        phoneType = phoneType,
                        number = phoneNumber
                    };
                    try
                    {
                        context.PhoneNumbers.AddObject(queryAdd);
                        context.SaveChanges();
                        // if context.SaveChanges() succeeded add text to the label Add -> lbl.Add.Text
                       // lblAdd.Text += string.Format("<br/>Added: number {0} of type: {1}", queryAdd.number.ToString(), queryAdd.phoneType);
                        //if context.savechanges() succeded then delete phone only if old values are DIFFERENT then new values
                     // Delete phone !only! if NEW values AREN'T same as OLD values!!
                        phoneTypeOld = ViewState["phoneTypeOld"].ToString();
                        phoneNumberOld = ViewState["phoneNumberOld"].ToString();
                
                        if (phoneType != phoneTypeOld || phoneNumber != phoneNumberOld)
                        {
                            DeletePhone(custID, phoneTypeOld, phoneNumberOld);    
                        }
                
                     }
            catch (OptimisticConcurrencyException ocex)
            {
                // Resolve the concurrency conflict by refreshing the
                // object context before re-saving changes
                context.Refresh(RefreshMode.StoreWins, queryAdd);
              lblAdd.Text = ocex.ToString();
                //throw;
            }
            catch (InvalidOperationException ioex)
            {
                context.Refresh(RefreshMode.StoreWins, queryAdd);
                lblAdd.Text = ioex.ToString();
            }
               
             catch (SqlException sqlexc)
            {
                context.Refresh(RefreshMode.StoreWins, queryAdd);
                lblAdd.Text = sqlexc.ToString();
            }
                            
            catch (Exception)
            {
                if (phoneType == phoneTypeOld && phoneNumber == phoneNumberOld)
                {
                    lblAdd.Text = "";  
                }
                else
                {
                  lblAdd.Text = "Error while trying to update record. The object could not be added." +
                  "Make sure that the same phone does not aleady exist.";      
                }
            }

           }

       }

        protected void insertPhoneDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            // To retrieve values from DynamicControl use --> e.Values
            string pType = e.Values["phoneType"].ToString().Trim();
            string pNumber = e.Values["number"].ToString().Trim();
            
            int customerID = (int)CustomerIDfromQueryString;

            InsertPhone(customerID, pType, pNumber);
            // ReBind phonesGridView to see new phone
            phonesGridView.DataBind();
        }

        protected void insertPhoneDetailsView_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            // Page refresh to refresh/reload ObjectStateManager entries - otherwise OptimisticConcurrencyException is thrown
             Response.Redirect("CustomerDetails.aspx");
        }

        public void InsertPhone(int custID, string phoneType, string phoneNumber)
        {
            using (var context = new VehicleEntities())
            {
                PhoneNumber queryInsert = new PhoneNumber
                {
                    customerID = custID,
                    phoneType = phoneType,
                    number = phoneNumber
                };
                try
                {
                    context.PhoneNumbers.AddObject(queryInsert);
                    context.SaveChanges();
                }

                catch (OptimisticConcurrencyException)
                {
                    // Resolve the concurrency conflict by refreshing the
                    // object context before re-saving changes
                    context.Refresh(RefreshMode.StoreWins, queryInsert);
                    lblInsertPhone.Text = "The phone number you attempted to insert was already inserted by " +
                                            "another user. The insert operation was canceled.";
                }

                catch (UpdateException)
                {
                    lblInsertPhone.Text += "There is already same phone number";
                }

                catch (Exception)
                {
                    lblInsertPhone.Text += "Exception on Inserting New Phone number";
                }
            }
        }

        protected void insertPhoneDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {                       
                insertPhoneDetailsView.Rows[0].Cells[1].Text = null;
                insertPhoneDetailsView.Rows[1].Cells[1].Text = null;
            }
        }

        protected void vehiclesGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            // Page refresh to refresh ObjectStateManager entries - otherwise OptimisticConcurrencyException is thrown
           // Response.Redirect("CustomerDetails.aspx"); -> doesnt retrieve QueryString
           Server.Transfer("~/CustomerDetails.aspx");
           lblError.Text = "Vehicle Deleted!";           
        }

        protected void phonesGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Server.Transfer("CustomerDetails.aspx");
        }

                                            
    }
    }