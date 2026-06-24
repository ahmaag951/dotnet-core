using Microsoft.EntityFrameworkCore;

namespace NBuilderAndFaker
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=testEntityFramework;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer
            //    {
            //        Id = 1, EmailAddress = "initial email", FirstName = "fname",
            //        LastName ="lname", TelephoneNumber = "tel"
            //    });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
