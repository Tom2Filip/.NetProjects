using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using VehicleRepair.BLL;
using System.Data.SqlClient;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;

namespace VehicleRepair
{
    public partial class Vehicles : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            VehiclesGridView.EnableDynamicData(typeof(Vehicle));
            vehicleServicesGridView.EnableDynamicData(typeof(VehicleService));
        }

        protected void Page_Load(object sender, EventArgs e)
        {                       
        }

        protected void AddVehicleLink_Click(object sender, EventArgs e)
        {
           Response.Redirect("AddVehicle.aspx");
        }

        protected void VehiclesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex; // index of the row to delete -> where Delete button clicked 
            string vRegistration = VehiclesGridView.DataKeys[e.RowIndex].Value.ToString();           
            VehicleRepairBL contextBL = new VehicleRepairBL();

            try
            {              
                contextBL.DeleteVehicle2(vRegistration);
                // to refresh the GridView - in case of deletion after filtering vehicles GridView - without next line of code it doesnt remove deleted item (vehicle) from GridView
                VehiclesGridView.DataSourceID = "VehiclesObjectDataSource";
            }
                       
            catch (OptimisticConcurrencyException ocex)
            {
                lblError.Text = ocex.ToString() + " An error occured while deleting vehicle. Make sure that vehicle exists.";
            }                      
             catch (ArgumentNullException)
            {
                lblError.Text = "An error occured while deleting vehicle. Make sure that vehicle exists.";
            }  
            catch (Exception)
            {
                lblError.Text = "An error occured while deleting vehicle. Please try again.";
            }
           

        }

        
        protected void VehiclesGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //int index = VehiclesGridView.SelectedIndex;
            int index = e.NewSelectedIndex;
            GridViewRow selectedRow = VehiclesGridView.Rows[index];
            // gets the value of datakey of selected GridViewRow -> depends of which row was clicked
            string vreg = (VehiclesGridView.DataKeys[selectedRow.RowIndex].Value).ToString();
            // save registration of clicked vehicle to the Viewstate - for rebinding vehicleServicesGridView
            ViewState["vRegistration"] = vreg;
            // gets the name of datakey -> 'registration'
            string reg = VehiclesGridView.DataKeyNames[0].ToString();

            lblRegistration.Text= ": " + vreg.ToUpper();

            try
                {
                 VehicleRepairBL contextBL = new VehicleRepairBL();
                 var queryBL = contextBL.GetServicesByReg(vreg);                           
                 vehicleServicesGridView.DataSource = queryBL.ToList();
                 vehicleServicesGridView.DataBind();
                 // vehicleServicesGridView.HeaderRow.Cells[0].Text = "Services";
                }                     
            catch (Exception)
                {
                lblMessage.Text = "An error occurred while retrieving vehicle services. Please try again.";
                }                              
        }
            
        protected void vehicleServicesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // e.RowIndex -> index of a row to delete
            int vServiceID = Convert.ToInt32(vehicleServicesGridView.DataKeys[e.RowIndex].Value);
            VehicleRepairBL contextBL = new VehicleRepairBL();

            try 
	            {	  
                  contextBL.DeleteService(vServiceID);
	            }	                    
            catch (OptimisticConcurrencyException ocex)
                {
                    lblMessage.Text = ocex.Message.ToString() + " An error occured while deleting vehicle service. Make sure that vehicle service exists.";
                }
            catch (ArgumentNullException)
            {
                lblMessage.Text = "An error occured while deleting vehicle service. Make sure that vehicle service exists.";
            }
            catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString() + " An error occured while deleting vehicle service. Please try again.";
                }

            string vreg = ViewState["vRegistration"].ToString();
            var queryBL = contextBL.GetServicesByReg(vreg);
                                
             // Rebind the vehicleServicesGridView after deletion of service
             vehicleServicesGridView.DataSource = queryBL.ToList();
             vehicleServicesGridView.DataBind(); 
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            if (ViewState["vRegistration"] == null || ViewState["vRegistration"].ToString() == "")
                {
                    Response.Redirect("Vehicles.aspx");
                }
                else
                {
                    string vReg = ViewState["vRegistration"].ToString();
                    Response.Redirect("ServiceAdd.aspx?qs=" + vReg);
                }                                           
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Trim()!= null && SearchTextBox.Text.Trim() != "")
            {
                try
                {
                    VehicleRepairBL context = new VehicleRepairBL();
                    var query = context.FilterVehicles(SearchTextBox.Text.Trim());
                    VehiclesGridView.DataSourceID = null;
                    VehiclesGridView.DataSource = query;
                    VehiclesGridView.DataBind();
                 }
                catch (Exception)
                {
                    lblError.Text = "An error occurred while retrieving vehicles. Please try again.";
                }
                
            }
         }              
        
    }
}