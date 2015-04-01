using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using VehicleRepair.BLL;

namespace VehicleRepair
{
    public partial class ServiceAdd : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            vehicleServiceDetailsView.EnableDynamicData(typeof(VehicleService));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["qs"] == null || Request.QueryString["qs"] == "")
                {
                    Response.Redirect("Vehicles.aspx");
                }
                else
                {
                    ViewState["reg"] = Request.QueryString["qs"];
                }
            }

        }

        protected void vehicleServiceDetailsView_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            TextBox textBoxDesc = (TextBox)(vehicleServiceDetailsView.FindControl("descriptionTextBox"));
            string desc = textBoxDesc.Text;
                        
            string registration = ViewState["reg"].ToString();
          //  DateTime serviceDate1 = Convert.ToDateTime(e.Values["seviceDate"]);
          //  DateTime serviceDate2 = Convert.ToDateTime(e.Values[0]);
            
            TextBox serviceDateTextBox = (TextBox)vehicleServiceDetailsView.FindControl("serviceDateTextBox");
            DateTime serviceDate3 = Convert.ToDateTime(serviceDateTextBox.Text);
            
            int odometer = Convert.ToInt32(e.Values["odometer"]);
            string subject = e.Values["subject"].ToString();
            
            try
            {
                VehicleRepairBL contextBL = new VehicleRepairBL();
                contextBL.AddServiceByReg(registration, serviceDate3, odometer, subject, desc);
                lblMessage.Text = "Service added!";
            }
            catch (Exception)
            {
                lblMessage.Text = "An error occured while inserting new service. Please try again. ";
                                           
            }
            
        }

        protected void vehicleServiceDetailsView_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            if (e.CancelingEdit)
            {
                Response.Redirect("Vehicles.aspx"); 
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