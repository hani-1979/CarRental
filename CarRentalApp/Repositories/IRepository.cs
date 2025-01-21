using Microsoft.Build.Framework;

namespace CarRentalApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); // Get by primary key
        Task<IEnumerable<T>> GetAllAsync(); // Get all records
        Task AddAsync(T entity); // Add a new record
        Task UpdateAsync(T entity); // Update an existing record
        Task DeleteAsync(int id); // Delete a record by its ID
        Task<T> GetByInsuranceStatusAsync(int Id);
        Task<T> GetByAccidentStatusAsync(int Id);
        Task<T> UpdateAccidentStatusAsync(int Id);
        
        Task<T> UpdateInsuranceStatusAsync(int Id);
        Task<T> UpdateClaimStatusAsync(int Id);
        Task<T> ChangAccidentStatusStatusAsync(int Id);
        Task<int?> GetCarIdByAccidentIdAsync(int accidentId);
        Task<int?> GetCompanyByAccidentIdAsync(int accidentId);
    }
}
