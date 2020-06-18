using Common.Infrastructure;
using Lookups.Service.Dto;
using Lookups.Service.FilterDto;
using Lookups.Service.Interfaces;
using Lookups.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lookups.WebAPI.Controllers
{
    /// <inheritdoc />
    public class CountriesController : BaseController
    {
        private readonly ICountryService _countryService;
        /// <inheritdoc />
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        /// <summary>
        /// Get data pagged 
        /// </summary>
        /// <param name="filteringDto"> Search filter</param>
        /// <param name="pagingSortingDto">Sort Parameters</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllPaged([FromBody] CountryFilterDto filteringDto, [FromQuery] PagingSortingDto pagingSortingDto)
        {
            var result = _countryService.GetAllPaged(filteringDto, pagingSortingDto);
            return Ok(result);
        }
        /// <summary>
        /// Get all data 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _countryService.GetAll();
            return Ok(list);
        }
        /// <summary>
        /// Get data by Id
        /// </summary>
        /// <param name="id">PK Column Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var country = _countryService.Get(id);

            return Ok(country);
        }
        /// <summary>
        /// Insert new
        /// </summary>
        /// <param name="countryDto">Inserted object</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CountryDto countryDto)
        {
            var message = _countryService.Add(countryDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="countryDto">Updated Object</param>
        /// <returns></returns>
        [HttpPut()]
        public IActionResult Update(CountryDto countryDto)
        {
            string message = _countryService.Update(countryDto);
            if (!string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(message);
            }
            return Ok();

        }
        /// <summary>
        /// Delete data by Id
        /// </summary>
        /// <param name="id">PK Column Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _countryService.Delete(id);
            return Ok();
        }

    }

}
