using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using VehicleRepair.BLL;
using System.Data.Entity.Core;

namespace VehicleRepair
{
    public partial class Service : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            vehicleServiceDetailsView.EnableDynamicData(typeof(VehicleService));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // check QueryString not null OR empty - if null OR empty redirect to Vehicles.aspx
            if (Request.QueryString["id"] == null || Request.QueryString["id"] == "")
            {
                Response.Redirect("Vehicles.aspx");
            }
            
            int id = Convert.ToInt16(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                try
                {
                    VehicleRepairBL contextBL = new VehicleRepairBL();
                    var queryBL = contextBL.GetServiceByID(id);
                    vehicleServiceDetailsView.DataSource = queryBL.ToList();
                    vehicleServiceDetailsView.DataBind();
                }
                catch (Exception)
                {
                    lblMessage.Text = "An error occurred while retrieving vehicle service. Please try again.";
                }
                                
            }
        }

        protected void vehicleServiceDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit==true)
            {
                Response.Redirect("Vehicles.aspx");
            }
        }

        protected void vehicleServiceDetailsView_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(e.Keys["id"]);

            try
            {
                VehicleRepairBL contextBL = new VehicleRepairBL();
                var serviceBL = contextBL.GetServiceByID(id).FirstOrDefault();

                TextBox serviceDateTextBox = (TextBox)vehicleServiceDetailsView.FindControl("serviceDateTextBox");
                DateTime serviceDate2 = Convert.ToDateTime(serviceDateTextBox.Text);
                //DateTime serviceDate = Convert.ToDateTime(e.NewValues["serviceDate"]);
                // e.NewValues - doesn't get KeyField values -> in this case can't retrieve 'id' and 'registration'
                int odometer = Convert.ToInt32(e.NewValues["odometer"]);
                //int odometer = Convert.ToInt32(e.NewValues[0]);
                string subject = e.NewValues["subject"].ToString();

                string description = null;

                if (e.NewValues["description"] == null)
                { description = ""; }
                else
                {
                 description = e.NewValues["description"].ToString();
                }
                                            
                contextBL.UpdateServiceByID(id, serviceDate2, odometer, subject, description);
                lblMessage.Text = "Service updated!";
            }
            catch (OptimisticConcurrencyException)
            {
                lblMessage.Text = "Vehicle service information changed since you retrieved it. Please try again.";
            }
            catch (UpdateException)
            {
                lblMessage.Text = "An error occurred while updating vehicle service. Please try again.";
            }
            catch (ArgumentNullException)
            {
                lblMessage.Text = "An error occurred while updating vehicle service. Make sure that vehicle service exists.";
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occurred while updating vehicle service. Please try again.";
            }
                       
        }

        protected void calendarImage_Click(object sender, ImageClickEventArgs e)
        {
            Calendar cal = (Calendar)vehicleServiceDetailsView.FindControl("serviceCalendar");
            cal.Visible = true;
        }

        protected void serviceCalendar_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)vehicleServiceDetailsView.FindControl("serviceCalendar");
            TextBox serviceDateTextBox = (TextBox)vehicleServiceDetailsView.FindControl("serviceDateTextBox");
            serviceDateTextBox.Text = calendar.SelectedDate.ToShortDateString();
            calendar.Visible = false;
            
        }
          
    }
}