using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {
            // will make sure that the db exists before it makes any calls to it
            // and if it's not exist, it will create it
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Department from seed" });
            base.OnModelCreating(modelBuilder);
        }

    }
}
