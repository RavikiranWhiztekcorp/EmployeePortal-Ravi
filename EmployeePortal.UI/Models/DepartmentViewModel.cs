using EmployeePortal.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.UI.Models
{
    public class DepartmentViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
