using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRepair.DAL
{
    [MetadataType(typeof(VehicleServiceMetaData))]
    public partial class VehicleService
    {
    }
    
    public class VehicleServiceMetaData
    {
        [Display(Name = "ID")]
        public int id { get; set; } 

        [Display(Name = "Subject")]
        [StringLength(30, ErrorMessage = "Subject must be 30 characters or less in length.")]
        [Required(ErrorMessage = "Subject is required.")]
        public String subject { get; set; }

        [Display(Name = "Description")]
        [StringLength(1000, ErrorMessage = "Description must be 1000 characters or less in length.")]
        public String description { get; set; }

        [Display(Name = "Odometer")]
        public int odometer { get; set; }

        [Display(Name = "ServiceDate")]
        // Display date data field in the format 11/12/2008. 
        // Also, apply format in edit mode
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        public DateTime serviceDate { get; set; }               
    }

}