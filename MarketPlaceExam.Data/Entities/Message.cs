using MarketPlaceExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketPlaceExam.Data.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        public string MessageContent { get; set; }

        public bool MarkAsRead { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public string? UserId { get; set; }
       
    }
}
