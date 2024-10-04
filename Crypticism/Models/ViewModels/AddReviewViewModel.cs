using System.ComponentModel.DataAnnotations;

namespace Crypticism.Models.ViewModels
{
    public class AddReviewViewModel
    {
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}