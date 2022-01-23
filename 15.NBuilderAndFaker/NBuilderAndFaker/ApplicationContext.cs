using Microsoft.EntityFrameworkCore;

namespace NBuilderAndFaker
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.3.250\\sqlserver2017;Database=TestFakeData;User ID=sa;Password=P@ssw0rd;Trusted_Connection=False;ConnectRetryCount=0");
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
