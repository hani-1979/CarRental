namespace CarRentalApp.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); // Get by primary key
        Task<IEnumerable<T>> GetAllAsync(); // Get all records
        Task AddAsync(T entity); // Add a new record
        Task UpdateAsync(T entity); // Update an existing record
        Task DeleteAsync(int id); // Delete a record by its ID
    }
}
