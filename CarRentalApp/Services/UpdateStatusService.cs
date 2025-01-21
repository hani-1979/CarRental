
using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRentalApp.Services
{
    public class UpdateStatusService : IUpdateStatusService
    {
        private readonly AppDbContext _context;

        public UpdateStatusService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int?> UpdateAccidentStatus(int Id)
        {
            var accident = await _context.Accidents.FindAsync(Id);
            if (accident != null)
            {
                // Set the status to 2
                accident.AccidentStatus = 3; // Assuming Status is a string. If it's an integer, use 1 instead of "1".
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<bool> UpdateStatusAsync(int claimId, int statusCode)
        {
            try
            {
                // Find the CarClaim by ID
                var carClaim = await _context.carClaim
                                              .FirstOrDefaultAsync(cc => cc.carClaimId == claimId);

                if (carClaim == null)
                {
                    throw new KeyNotFoundException($"CarClaim with ID {claimId} not found.");
                }

                // Update the ClaimStatus
                carClaim.ClaimStatus = statusCode;

                // Save changes to the database
                var result = await _context.SaveChangesAsync();

                // Return true if one row was affected
                return result > 0;
            }
            catch (Exception ex)
            {
                // Log the exception (you can log to a file, database, etc.)
                Console.WriteLine($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<int?> UpdatAgreeAccident(int Id)
        {
            var Accident = await _context.Accidents.FindAsync(Id);
            if (Accident != null)
            {
                // Set the status to 2
                Accident.AccidentStatus = 4; // Assuming Status is a string. If it's an integer, use 1 instead of "1".
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
