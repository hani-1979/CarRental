using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Estimation
    {
        [Key]
        public int EstimationId { get; set; }
        [DisplayName("رقم التقدير")]
        public string EstimationNumber{ get; set; }
        public int AccidentId { get; set; }
        [ValidateNever]
        public Accident Accident { get; set; }
        [DisplayName("تأريخ التقدير")]
        public DateTime EstimationDate { get; set; }
        [DisplayName("جهة التقدير")]
        public string EstimationSide { get; set; }
        [DisplayName("المبلغ المقدر")]
        public decimal EstimationAmount { get; set; }
        [ValidateNever]
        public virtual ICollection<carClaim> carClaims { get; set; }

    }
}
