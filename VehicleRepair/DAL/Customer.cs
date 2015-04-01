using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRepair.DAL
{
    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
    }


    public class CustomerMetaData
    {

        [Display(Name = "First name")]
        [StringLength(20, ErrorMessage = "First name must be 20 characters or less in length.")]
        [Required(ErrorMessage = "First name is required.")]
        public String firstName { get; set; }

        // Allow up to 20 uppercase and lowercase characters. Use custom error.
        // [RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$", ErrorMessage = "Special characters and numbers are not allowed.")]
        [Display(Name = "Last name")]
        [StringLength(20, ErrorMessage = "Last name must be 20 characters or less in length.")]
        [Required(ErrorMessage = "Last name is required.")]
        public String lastName { get; set; }

        [Display(Name = "Adress")]
        [StringLength(30, ErrorMessage = "Adress must be 30 characters or less in length.")]
        // [Required(ErrorMessage = "Adress is required.")]
        public String adress { get; set; }

        [Display(Name = "City")]
        [StringLength(20, ErrorMessage = "City must be 20 characters or less in length.")]
        [Required(ErrorMessage = "City is required.")]
        public String city { get; set; }

        [Display(Name = "State")]
        [StringLength(30, ErrorMessage = "State must be 30 characters or less in length.")]
        [Required(ErrorMessage = "State is required.")]
        public String state { get; set; }

        [Display(Name = "Post code")]
        [StringLength(16, ErrorMessage = "Post code must be 16 characters or less in length.")]
        // [Required(ErrorMessage = "Post Code is required.")]
        public String postCode { get; set; }

        [Display(Name = "Email")]
        // [EmailAddress(ErrorMessage = "Not a valid Email Address")]
        // is already included in System.ComponentModel.DataAnnotations.dll
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(30, ErrorMessage = "Email must be 30 characters or less in length.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" , ErrorMessage="Must be a valid e-mail address.")]
        public String email { get; set; }

    }

}