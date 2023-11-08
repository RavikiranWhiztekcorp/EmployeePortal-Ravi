using EmployeePortal.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.UI.Models
{
    public class EmployeeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long PhoneNo { get; set; }
        [Required]
        public long AadharNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
