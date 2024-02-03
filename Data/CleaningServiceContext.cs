using CSMS.Models.DomainModels;
using CSMS.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CSMS.Data
{
    public class CleaningServiceContext : DbContext
    {
        public CleaningServiceContext() { }

        public CleaningServiceContext(DbContextOptions<CleaningServiceContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CleaningOffer> CleaningOffers { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<CleanUp> CleanUps { get; set; }
        public DbSet<DeepClean> DeepCleans { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Insert database connection");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ManagerConfiguration());
            builder.ApplyConfiguration(new CleanerConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new WarehouseConfiguration());
            builder.ApplyConfiguration(new CleaningOfferConfiguration());
            builder.ApplyConfiguration(new ApartmentConfiguration());
            builder.ApplyConfiguration(new FacilityConfiguration());
            builder.ApplyConfiguration(new CleanUpConfiguration());
            builder.ApplyConfiguration(new DeepCleanConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
