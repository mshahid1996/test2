using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Emp
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeePhone { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        [Required]
        public int EmployeeSalary { get; set; }
    }
}
