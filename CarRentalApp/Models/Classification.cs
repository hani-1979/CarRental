using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace CarRentalApp.Models
{
    public class Classification
    {
       
        public int classificationId { get; set; }
        [DisplayName("إسم التصنيف")]
        public string classificationName { get; set; }
       
    }
}
