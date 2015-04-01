using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleRepair.DAL;
using System.Data;

namespace VehicleRepair
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomersGridView.EnableDynamicData(typeof(Customer));
        }
          
        protected void CustomersGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                if (e.Exception is OptimisticConcurrencyException)
                {
                    lblErrorMessage.Text = "The record you attempted to delete was modified by another " +
                    "user after you got the original value. The delete operation was canceled.";
                    e.ExceptionHandled = true;
                }
                else
                {
                    lblErrorMessage.Text = e.Exception.Message;
                    e.ExceptionHandled = true;
                }
                
            }
        }

        protected void AddCustomerLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerAdd.aspx");
        }
        
    }
}