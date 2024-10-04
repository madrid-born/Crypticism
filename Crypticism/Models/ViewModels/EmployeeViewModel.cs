using System.ComponentModel.DataAnnotations;

namespace Crypticism.Models.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "CompanyName")]
        public string CompanyName { get; set; }
        
        [Display(Name = "Personnel Code")]
        public string PersonnelCode { get; set; }
    }
}