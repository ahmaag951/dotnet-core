using Common.Infrastructure;
using Lookups.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lookups.Data
{
    public class LookupsContext : DbContext
    {
        public LookupsContext(DbContextOptions<LookupsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

    }
}
