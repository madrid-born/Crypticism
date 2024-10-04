using System.ComponentModel.DataAnnotations;

namespace Crypticism.Models.ViewModels
{
    public class CompanyViewModel
    {
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}