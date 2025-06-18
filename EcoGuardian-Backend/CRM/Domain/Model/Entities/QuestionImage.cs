using System;
using System.ComponentModel.DataAnnotations;

namespace EcoGuardian_Backend.CRM.Domain.Model.Entities
{
    public class QuestionImage
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int QuestionId { get; set; }
        
        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
                
   
        public QuestionImage(int questionId, string imageUrl)
        {
            QuestionId = questionId;
            ImageUrl = imageUrl;
            UploadedAt = DateTime.UtcNow;
        }
    }
}
