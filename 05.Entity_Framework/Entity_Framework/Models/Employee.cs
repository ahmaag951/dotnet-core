using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Employee")]
        public string Name { get; set; }

        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public Department Department { get; set; }
        public int Test { get; set; }
    }
}
