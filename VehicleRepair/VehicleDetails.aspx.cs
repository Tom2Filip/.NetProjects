using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using VehicleRepair.BLL;
using System.Web.DynamicData;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;

namespace VehicleRepair
{
    public partial class VehicleDetails : System.Web.UI.Page
    {
        
        public string vehRegistration;
        //private int registration;

        protected void Page_Init(object sender, EventArgs e)
        {
            vehicleDetailsView.EnableDynamicData(typeof(Vehicle));             
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // check QueryString not null OR empty - if null OR empty redirect to Vehicles.aspx
            if (Request.QueryString["registration"] == null || Request.QueryString["registration"] == "")
            {
                Response.Redirect("Vehicles.aspx");
            }

            vehRegistration = Convert.ToString(Request.QueryString["registration"]).Trim();
            
            if (!IsPostBack)
            {             
                VehicleRepairBL contextBL = new VehicleRepairBL();
                                               
                try
                {
                    IQueryable<Vehicle> queryBL = contextBL.GetVehicleByRegistration(vehRegistration);
                    vehicleDetailsView.DataSource = queryBL;
                    vehicleDetailsView.DataBind();
                   
                }
                catch (Exception)
                {
                    lblMessage.Text = "An error occurred. Please try again.";
                }


                try
                {
                    VehicleRepairBL context = new VehicleRepairBL();
                    var queryBL = context.GetVehicleByRegistration(vehRegistration);
                    // get the ID of Customer
                    // if there's no vehicle owner -> customerID field is empty/NULL then Exception will be thrown
                    int cID = (int)queryBL.FirstOrDefault().customerID;                  
                    // get Customer by ID
                    var cust = context.GetCustomerByID(cID).FirstOrDefault();

                    string fName;
                    string Lname;

                    fName = cust.firstName;
                    Lname = cust.lastName;

                    vehicleDetailsView.Rows[1].Cells[1].Text = fName + " " + Lname;
                    
                }
                catch (Exception)
                {
                    lblMessage.Text = "Vehicle has no owner";
                }


                                     
            }   
         }

        protected void vehicleDetailsView_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
           if (e.CommandName=="Cancel")
            {
                // retrieve value from DetailsView with "Dictionary" -> IOrderedDictionary
                IOrderedDictionary valuesDictionary = new OrderedDictionary();
                DataControlFieldCell vMakeCell = (DataControlFieldCell)vehicleDetailsView.Rows[4].Cells[1];
                  vMakeCell.ContainingField.ExtractValuesFromCell(valuesDictionary, vMakeCell, DataControlRowState.Edit, true);
               // vMakeCell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);

                //string make1 = valuesDictionary["year"].ToString();
                
            }
        }

                
        protected void vehicleDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
           if (e.CancelingEdit)
            {
               // Button Cancel Click in DetailsView
                Response.Redirect("Vehicles.aspx");
            }
        }

        protected void vehicleDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            string vRega = e.Keys[0].ToString();
            string vrega = e.Keys["registration"].ToString();
            string vMake = e.NewValues["make"].ToString();
            string vModel = e.NewValues["model"].ToString();
            string vType = e.NewValues["type"].ToString();
            string vYear1 = e.NewValues["year"].ToString();
            Int16 vYear2 = Convert.ToInt16(vYear1);

            string vColor = null;
            if (e.NewValues["color"] == null || e.NewValues["color"].ToString() == "")
            {
                vColor = string.Empty;
            }
            else
            {
                vColor = e.NewValues["color"].ToString().Trim();
            }

            string vVin = null;
            if (e.NewValues["vin"] == null || e.NewValues["vin"].ToString() == "")
            {
                vVin = string.Empty;
            }
            else
            {
                vVin = e.NewValues["vin"].ToString().Trim();
            }

            string vCapacity = null;
            if (e.NewValues["capacity"] == null || e.NewValues["capacity"].ToString() == "")
            {
                vCapacity = string.Empty;
            }
            else
            {
                vCapacity = e.NewValues["capacity"].ToString().Trim();
            }

            string vFuelType = null;
            if (e.NewValues["fuelType"] == null || e.NewValues["fuelType"].ToString() == "")
            {
                vFuelType = string.Empty;
            }
            else
            {
                vFuelType = e.NewValues["fuelType"].ToString().Trim();
            }
                                                              
           VehicleRepairBL contextBL = new VehicleRepairBL();

            try
            {
                contextBL.UpdateVehicleByRegistration(vrega, vMake, vModel, vType, vYear2, vColor, vVin, vCapacity, vFuelType);
                lblUpdateVehicle.Text = "Vehicle updated.";
            }
            catch (OptimisticConcurrencyException)
            {
                lblMessage.Text = "Error while updating vehicle. Original data was changed since you retrieved it";
            }

            catch (UpdateException)
            {
                lblMessage.Text = "Error while updating vehicle.";
            }

            catch (Exception ex)
            {
                if (ex.InnerException is UpdateException)
                 lblMessage.Text = "Error while updating vehicle. Please try again.";
            }
                                
        }
        // Change vehicle owner - button clcik
        protected void btnOwner_Click(object sender, EventArgs e)
        {
            VehicleRepairBL contextBL = new VehicleRepairBL();
            try
            {
                var queryCustomers = contextBL.GetCustomers();
                CustomersGridView.DataSource = queryCustomers;
                CustomersGridView.DataBind();
            }
            catch (Exception ex)
            {
               throw ex;
            }
         }

        protected void CustomersGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridViewRow row = CustomersGridView.Rows[index];
            int customerID = Convert.ToInt32(CustomersGridView.DataKeys[row.RowIndex].Value);
            ViewState["owner"]= customerID;
            string customerName = row.Cells[2].Text;
            string customerLastName = row.Cells[3].Text;
            lblCustomer.Text = customerID + " " + customerName + " " + customerLastName;
            btnNewOwner.Visible = true;
        }

        // Select New Owner - button click
        protected void btnNewOwner_Click(object sender, EventArgs e)
        {
            int owner = (int)ViewState["owner"];
            string reg = Convert.ToString(Request.QueryString["registration"]).Trim();
            try
            {
                VehicleRepairBL contextBL = new VehicleRepairBL();
                contextBL.UpdateVehicleOwner(reg, owner);
                // Refresh Page to see New Owner in vehicleDetailsView
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            catch (OptimisticConcurrencyException)
            {
                lblMessage.Text = "Error while changing owner of a vehicle.";
            }

            catch (UpdateException)
            {
                lblMessage.Text = "Error while changing owner of a vehicle.";
            }

            catch (Exception ex)
            {
                if (ex.InnerException is UpdateException)
                    lblMessage.Text = "Error while changing owner of a vehicle. Please try again.";
            }
            
          }
                            
    }
}