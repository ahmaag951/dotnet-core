using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NBuilderAndFaker
{
    public class Customer
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime CustomerDate { get; set; }
        public TimeSpan CustomerTime { get; set; }
        public int CustomerNumber { get; set; }
    }

    
}
