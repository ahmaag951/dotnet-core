using System;


namespace Lookups.Service.FilterDto
{
    public class CountryFilterDto
    {
        public string Code { get; set; }
        public string NameFl { get; set; }
        public string NameSl { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
