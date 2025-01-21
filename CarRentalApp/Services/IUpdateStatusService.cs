using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface IUpdateStatusService
    {
        Task<int?> UpdateAccidentStatus(int Id);
        Task<bool> UpdateStatusAsync(int claimId, int statusCode);
        Task<int?> UpdatAgreeAccident(int Id);

        



    }
}
