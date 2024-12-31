using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;
using CarRentalApp.ViewModels;
//using CarRentalApp.ViewModels;

namespace CarRentalApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        public DbSet<Colour> Colour { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manufactorer> Manufactorers { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Modeel> Modeels { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cascade delete for ManufacturerId relationship
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Manufactorer)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ManufactorerId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete for ManufacturerId

            // Avoid multiple cascade paths by setting Restrict or SetNull for ModelId relationship
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Modeel)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModeelId)
                .OnDelete(DeleteBehavior.Restrict);  // Avoid cascade delete for ModelId
                 modelBuilder.Entity<InsuranceViewModel>().Ignore(i => i.Photo);
        }
        public DbSet<CarRentalApp.ViewModels.InsuranceViewModel> InsuranceViewModel { get; set; } = default!;
       

    }
   
}
