using AutoMapper;
using Common.Infrastructure;
using Lookups.Data.Entities;
using Lookups.DataAccess;
using Lookups.Service.Dto;
using Lookups.Service.FilterDto;
using Lookups.Service.Interfaces;
using Lookups.Service.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Lookups.Service.Services
{
    public class CountryService : BaseServices, ICountryService
    {
        public CountryService(IMapper mapper, IUnitofWork unitofWork)
             : base(mapper, unitofWork) { }

        public IEnumerable<CountryDto> GetAll()
        {
            var list = _unitofWork.CountryRepository.GetAll(source => source
                                                            .Include(c => c.Locations));
            return _mapper.Map<IEnumerable<Country>, IEnumerable<CountryDto>>(list);
        }

        public PagedListDto<CountryDto> GetAllPaged(CountryFilterDto filteringDto, PagingSortingDto pagingSortingDto)
        {
            var predicate = Helper.GetPredicate<Country, CountryFilterDto>(filteringDto);
            int count;
            var list = _unitofWork.CountryRepository.GetPaggedList(predicate, pagingSortingDto, out count);
            return new PagedListDto<CountryDto>() { List = _mapper.Map<List<CountryDto>>(list), Count = count };
        }

        public CountryDto Get(Guid id)
        {
            var country = _unitofWork.CountryRepository.Get(id);
            return _mapper.Map<Country, CountryDto>(country);
        }

        public string Add(CountryDto countryDto)
        {
            if (_unitofWork.CountryRepository.IsExist(r=>r.Id == countryDto.Id && r.Name == countryDto.Name))
            {
                return "CountryService_IsExists";
            }
            else
            {
                var country = _mapper.Map<CountryDto, Country>(countryDto);
                _unitofWork.CountryRepository.Add(country);
                _unitofWork.SaveChanges();
                return null;
            }
        }

        public string Update(CountryDto countryDto)
        {
            if (_unitofWork.CountryRepository.IsExist(r=>r.Id == countryDto.Id && r.Name == countryDto.Name))
            {
                return "CountryService_IsExists";
            }
            else
            {
                var country = _unitofWork.CountryRepository.Get(countryDto.Id);
                _mapper.Map(countryDto, country);
                _unitofWork.SaveChanges();
                return null;
            }
        }

        public void Delete(Guid id)
        {
            var country = _unitofWork.CountryRepository.Get(id);
            if (country != null)
            {
                _unitofWork.CountryRepository.Remove(country);
                _unitofWork.SaveChanges();
            }

        }
    }
}
