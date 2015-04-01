using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleRepair.DAL
{
    [MetadataType(typeof(PhoneNumberMetaData))]
    public partial class PhoneNumber
    {
    }

    public class PhoneNumberMetaData
    {
        [Key]
        [Column(Order=1)]
        [Display(Name = "Phone number")]
        [StringLength(20, ErrorMessage = "Phone number must be 20 characters or less in length.", MinimumLength = 4)]
        [Required(AllowEmptyStrings=false , ErrorMessage = "Phone number is required.")]
        public String number { get; set; }

        [Key]
        [Column(Order = 2)]
        [Display(Name = "Phone type")]
        [StringLength(20, ErrorMessage = "Phone type must be 20 characters or less in length.", MinimumLength = 4)]
        [Required(AllowEmptyStrings = false , ErrorMessage = "Phone type is required.")]
        public String phoneType { get; set; }

        [Key]
        [ForeignKey("Customer")]
        [Column(Order=3)]
        public int customerID { get; set; }
    }

}