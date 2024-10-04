using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypticism.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        
        [Required]
        public bool IsVerified { get; set; }
        
        [ForeignKey("Company")]
        public int? CompanyId { get; set; }
        
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }

    }
}