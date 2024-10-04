using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crypticism.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsAnonymous { get; set; }
        
        public int? UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        [ForeignKey("Review")]
        public int RepliedOnReviewId { get; set; }
        
        [ForeignKey("Comments")]
        public int? RepliedOnCommentId { get; set; }
        
        public virtual Review Review { get; set; }
        public virtual Comment Comments { get; set; }
    }
}