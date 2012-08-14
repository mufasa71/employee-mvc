using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EmployeesManagement.Domain.Entities
{
    public class Employee {
        [HiddenInput(DisplayValue=false)]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage="Please enter employee name")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Please enter employee salary")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive salary")]
        public double Salary { get; set; }
    }
}
