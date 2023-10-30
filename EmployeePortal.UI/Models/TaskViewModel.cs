using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.UI.Models
{
    public class TaskViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }
        [Required]
        public string Description { get; set; } 
    }
}
