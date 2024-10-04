using System.ComponentModel.DataAnnotations;

namespace Crypticism.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "IsCompany")]
        public bool IsCompany { get; set; } = false;
    }

}