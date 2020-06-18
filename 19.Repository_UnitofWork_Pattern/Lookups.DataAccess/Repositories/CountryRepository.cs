using Common.Infrastructure;
using Lookups.Data;
using Lookups.Data.Entities;
using Lookups.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lookups.DataAccess.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context) : base(context)
        {
        }
    }
}
