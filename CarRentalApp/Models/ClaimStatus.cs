using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class ClaimStatus
    {
        public int Id { get; set; }
        public int carClaimId { get; set; }  
        public int StatusCode { get; set; }
        [DisplayName("إضافة تعليق")]  
        public string Comment { get; set; }
    }
}
