using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CarRentalApp.Models
{
   
        public class Accident
        {
            [Key]
            public int AccidentId { get; set; }
            public int CarId { get; set; }
            public int CompanyId { get; set; }
            public int TrafficreportId { get; set; }
            public int BranchId { get; set; }
            public string AccidentNumber { get; set; }
            public decimal Percentage { get; set; }
            public string Description { get; set; }
            public DateTime AccidentDate { get; set; }
            public string? DriverName { get; set; }
            public string? DriveLicence { get; set; }
            public string? DriverIdentity { get; set; }
        public string? DriverNameOther { get; set; }
        public string? DriveLicenceOther { get; set; }
        public string? DriverIdentityOther { get; set; }
        public string? DriverCompanyOther { get; set; }
        [Display(Name = "Percentage")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100.")]
      
        public int  AccidentStatus { get; set; }
           
            [ValidateNever]
            public Company company { get; set; }
        [ValidateNever]
        public Trafficreport Trafficreport { get; set; }
        [ValidateNever]
        public Branch Branch { get; set; }

        [ValidateNever]
             public ICollection<AccidentAttachment> accidentAttachment { get; set; } = new List<AccidentAttachment>();
        [ValidateNever]
        public ICollection<AccidentPicAttachment> accidentPicAttachment { get; set; } = new List<AccidentPicAttachment>();


    }
    }

