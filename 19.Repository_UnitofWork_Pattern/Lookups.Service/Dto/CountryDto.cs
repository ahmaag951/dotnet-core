using System;
using Lookups.Service.Dto.Base;
using System.ComponentModel.DataAnnotations;

namespace Lookups.Service.Dto
{
    public class CountryDto: BaseDto
    {
        //[Required(ErrorMessageResourceName = "CountryDto_Code_Required", ErrorMessageResourceType = typeof(Resources.Lookups))]
        [StringLength(maximumLength: 10)]
        public string Code { get; set; }

        [StringLength(maximumLength: 200)]
        public string Name { get; set; }

    }
}
