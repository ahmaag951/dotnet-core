using AutoMapper;
using Lookups.Data.Entities;
using Lookups.Service.Dto;

namespace Lookups.Service.AutoMapper
{
    public class LookupsProfile : Profile
    {
        public LookupsProfile()
        {
            MapCountry();
           
        }

        private void MapCountry()
        {
            CreateMap<CountryDto, Country>().ReverseMap();
        }

    }
}
