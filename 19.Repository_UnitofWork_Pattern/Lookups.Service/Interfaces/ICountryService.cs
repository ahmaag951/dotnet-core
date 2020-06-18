using Common.Infrastructure;
using Lookups.Service.Dto;
using Lookups.Service.FilterDto;
using System;
using System.Collections.Generic;

namespace Lookups.Service.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetAll();
        PagedListDto<CountryDto> GetAllPaged(CountryFilterDto filteringDto, PagingSortingDto pagingSortingDto);
        
        CountryDto Get(Guid id);
        string Add(CountryDto countryDto);
        string Update(CountryDto countryDto);
        void Delete(Guid id);
    }
}
