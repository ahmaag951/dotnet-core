using AutoMapper;
using Lookups.DataAccess;

namespace Lookups.Service.Services.Base
{
    public class BaseServices
    {
        protected readonly IUnitofWork _unitofWork;
        protected readonly IMapper _mapper;

        public BaseServices(IMapper mapper, IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;

        }
    }
}
