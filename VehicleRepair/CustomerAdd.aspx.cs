using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using System.Data;
using System.Data.SqlClient;

namespace VehicleRepair
{
    public partial class CustomerAdd : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            AddCustomerDetailsView.EnableDynamicData(typeof(Customer));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCustomerDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            string adress = "";
            string postCode = "";

            string fName = e.Values["firstName"].ToString();
            string lName = e.Values["lastName"].ToString();

            if (e.Values["adress"] != null)
                adress = e.Values["adress"].ToString();
            else
            {
                adress = "";
            }
            //string adress = e.Values["adress"].ToString();

            string city= e.Values["city"].ToString();
            string state = e.Values["state"].ToString();
                    
            if (e.Values["postCode"] != null)
            postCode = e.Values[5].ToString();
            else
            {
               postCode = "";
            }

            string email = e.Values["email"].ToString();
            
            try
            {
                VehicleRepairRepository context = new VehicleRepairRepository();
                context.InsertCustomer(fName, lName, adress, city, state, postCode, email);
               // VehicleRepairBL contextBL = new VehicleRepairBL();
                //contextBL.InsertVehicle(vRegistration, vMake, vModel, vType, vYear);
                lblErrorMessage.Text = "Customer Added: " + e.Values[0] + " " + e.Values[1];
            }

            catch (OptimisticConcurrencyException ocex)
            {
                lblErrorMessage.Text = ocex.ToString();
            }

            catch (UpdateException)
            {
                lblErrorMessage.Text = "An error occured while inserting new customer. Please try again";
                                                       
                // msdn.microsoft.com/en-us/library/system.exception.data%28v=vs.110%29.aspx                        
                //ex.ExceptionHandled = true;
            }
            catch (SqlException exs)
            {
                //lblErrorMessage.Text = e.Exception.InnerException.Message;
                lblErrorMessage.Text = "Error" + "<br/>" + exs.Message.ToString();
                // .ExceptionHandled = true;
            }
            catch (Exception)
            {
                //lblErrorMessage.Text = "Greška!<br/>" + ex.Message.ToString() + "<br/>" + ex.InnerException.Message.ToString();
                lblErrorMessage.Text = "An error occured while inserting new customer. Please try again";   
                                        
            }
        }
            
        protected void AddCustomerDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("CustomerAdd.aspx");
            }
        }
    }
}