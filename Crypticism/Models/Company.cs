using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypticism.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        public virtual User User { get; set; }

    }
}