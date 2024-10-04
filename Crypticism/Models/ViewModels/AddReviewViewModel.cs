using System.ComponentModel.DataAnnotations;

namespace Crypticism.Models.ViewModels
{
    public class AddReviewViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Content")]
        public string Content { get; set; }
        
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
    }
}