using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class InsuranceViewModel
    {
        [Key]
        public int InsuranceId { get; set; }
        public int CompanyId { get; set; }
        [ValidateNever]
        public List<Company> companies { get; set; }
        [ValidateNever]
        public Company company  { get; set; }
        public int CarId { get; set; }
        public string PolicyNumber { get; set; }
        public DateOnly BDPolicyNumber { get; set; }
        public DateTime EDPolicyNumber { get; set; }
        [ValidateNever]
        public IFormFile Photo { get; set; }


    }
}
