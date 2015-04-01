using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleRepair.DAL
{

    [MetadataType(typeof(VehicleMetaData))]
    public partial class Vehicle
    {
    }

    public class VehicleMetaData
    {

        [Display(Name = "Registration")]
        [StringLength(20, ErrorMessage = "Registration must be 20 characters or less in length.")]
        [Required(ErrorMessage = "Registration is required.")]
        public String registration { get; set; }

        [Display(Name = "Make")]
        [StringLength(20, ErrorMessage = "Make must be 20 characters or less in length.")]
        [Required(ErrorMessage = "Make is required.")]
        public String make { get; set; }

        [Display(Name = "Model")]
        [StringLength(10, ErrorMessage = "Model must be 10 characters or less in length.")]
        [Required(ErrorMessage = "Model is required.")]
        public String model { get; set; }

        [Display(Name = "Type")]
        [StringLength(10, ErrorMessage = "Type must be 10 characters or less in length.")]
        [Required(ErrorMessage = "Type is required.")]
        public String type { get; set; }

        [Display(Name = "Year")]
        [Range(1900, UInt16.MaxValue, ErrorMessage = "Year must be greater than 1900")]
        [Required(ErrorMessage = "Year is required and in YYYY format")]
        public UInt16 year { get; set; }

        [Display(Name = "Color")]
        [StringLength(20, ErrorMessage = "Color must be 20 characters or less in length.")]
        public String color { get; set; }

        [Display(Name = "Vin")]
        [StringLength(20, ErrorMessage = "Vin must be 20 characters or less in length.")]
        public String vin { get; set; }

        [Display(Name = "Capacity")]
        [StringLength(10, ErrorMessage = "Capacity must be 10 characters or less in length.")]
        public String capacity { get; set; }

        [Display(Name = "Fuel type")]
        [StringLength(10, ErrorMessage = "Fuel type must be 10 characters or less in length.")]
        public String fuelType { get; set; }

    }

}