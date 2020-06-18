using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lookups.Data.Entities.Base;

namespace Lookups.Data.Entities
{
    public class Country : BaseModel
    {
        [StringLength(10)]
        public string Name { get; set; }
        
        public virtual ICollection<Location> Locations { get; set; }
    }
}
