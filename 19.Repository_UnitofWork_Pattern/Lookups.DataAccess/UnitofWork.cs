using Common.Infrastructure;
using Lookups.Data;
using Lookups.DataAccess.Interfaces;
using Lookups.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Lookups.DataAccess
{
    public class UnitofWork : IUnitofWork
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DbContext _context;
        public UnitofWork(DbContext context, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }
        public ICountryRepository CountryRepository
        {
            get
            {
                return _serviceProvider.GetRequiredService<ICountryRepository>();
            }
        }
       
    public void Dispose()
        {
            _context.Dispose();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
