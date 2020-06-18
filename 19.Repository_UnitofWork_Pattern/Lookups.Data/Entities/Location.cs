using System;
using System.ComponentModel.DataAnnotations;
using Lookups.Data.Entities.Base;

namespace Lookups.Data.Entities
{
   public class Location :BaseModel
   {
        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

    }
}
