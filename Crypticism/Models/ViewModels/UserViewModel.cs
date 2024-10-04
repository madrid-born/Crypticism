using System.ComponentModel.DataAnnotations;

namespace Crypticism.Models.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "IsCompany")]
        public bool IsCompany { get; set; } = false;
    }

}