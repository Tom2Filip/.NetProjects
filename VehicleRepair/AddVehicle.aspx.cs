using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using VehicleRepair.BLL;
using System.Data.SqlClient;
using System.Data.Entity.Core;

namespace VehicleRepair
{
    public partial class AddVehicle : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            AddVehicleDetailsView.EnableDynamicData(typeof(Vehicle));
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void AddVehicleDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            string vRegistration = e.Values["registration"].ToString();
            string vMake = e.Values["make"].ToString();
            string vModel = e.Values["model"].ToString();
            string vType = e.Values["type"].ToString();
            short vYear = Convert.ToInt16(e.Values["year"]);

            string vColor = null;
            if (e.Values["color"] == null || e.Values["color"].ToString() == "")
            {
                vColor = string.Empty;
            }
            else
            {
                vColor = e.Values["color"].ToString().Trim();
            }

            string vVin = null;
            if (e.Values["vin"] == null || e.Values["vin"].ToString() == "")
            {
                vVin = string.Empty;
            }
            else
            {
                vVin = e.Values["vin"].ToString().Trim();
            }

            string vCapacity = null;
            if (e.Values["capacity"] == null || e.Values["capacity"].ToString() == "")
            {
                vCapacity = string.Empty;
            }
            else
            {
                vCapacity = e.Values["capacity"].ToString().Trim();
            }
            
            string vFuelType = null;
            if (e.Values["fuelType"] == null || e.Values["fuelType"].ToString() == "")
            {
                vFuelType = string.Empty;
            }
            else
            {
                vFuelType = e.Values["fuelType"].ToString().Trim();
            }
                       
            ViewState["vRegistration"] = vRegistration;

            try
            {
                VehicleRepairBL contextBL = new VehicleRepairBL();
                contextBL.InsertVehicle(vRegistration, vMake, vModel, vType, vYear, vColor, vVin, vCapacity, vFuelType);
                lblErrorMessage.Text = "Vehicle Added: " + e.Values[0];
            }
                
            catch (OptimisticConcurrencyException ocex)
            {
                lblErrorMessage.Text = ocex.ToString();
            }
            
            catch (UpdateException ex)
               {
                    lblErrorMessage.Text = "An error occured on inserting new vehicle. There is already vehicle " +
                                           "with the Registration: " + ViewState["vRegistration"] + "<br/>"
                                           + ex.Message.ToString();
                    //   "<br/>Data count:" +  e.Exception.InnerException.InnerException.Data.Count.ToString();
                    // e.Exception.InnerException.Data.Keys.ToString() + "<br/>" +
                    //e.Exception.InnerException.Message +
                    //e.Exception.InnerException.InnerException.Message;
                    //e.Exception.InnerException.Message;

                    // msdn.microsoft.com/en-us/library/system.exception.data%28v=vs.110%29.aspx                        
                    //ex.ExceptionHandled = true;
                }
                catch (SqlException exs)
                {
                    //lblErrorMessage.Text = e.Exception.InnerException.Message;
                    lblErrorMessage.Text = "Greška - duplicate registration" + "<br/>"
                                           + exs.Message.ToString(); ;
                     // .ExceptionHandled = true;
                }
               catch (Exception) 
                {
                    //lblErrorMessage.Text = "Greška!<br/>" + ex.Message.ToString() + "<br/>" + ex.InnerException.Message.ToString();
                    lblErrorMessage.Text = "An error occured on inserting new vehicle. There is already vehicle " +
                                            "with the Registration: " + ViewState["vRegistration"];
                }
                      
            
        }
        
        protected void AddVehicleDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("Vehicles.aspx");
            }
         }

        
        
  }
}