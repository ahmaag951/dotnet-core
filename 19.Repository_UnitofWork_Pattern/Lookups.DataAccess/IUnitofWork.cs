using Lookups.DataAccess.Interfaces;
using System;

namespace Lookups.DataAccess
{
    public interface IUnitofWork : IDisposable
    {
        ICountryRepository CountryRepository { get; }
        
        int SaveChanges();
    }
}