using CarRentalApp.Models;
using System.Collections;

namespace CarRentalApp.Services
{
    public interface IInsuranceService
    {
        Task<IEnumerable<Insurance>> GetAllInsuranceAsync();
        Task<Insurance> GetInsuranceByIdAsync(int id);
        Task AddInsurace (Insurance insurance);
        Task UpdateInsurace(Insurance insurance);
        Task DeleteInsuraceAsync(int id);
        Task UpdateInsuranceStatus(int Id);
       
    }
    }
