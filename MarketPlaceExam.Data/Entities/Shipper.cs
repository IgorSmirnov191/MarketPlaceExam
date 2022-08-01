using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class Shipper
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, Name: {Name}, Phone: {Phone} ";
        }
    }
}
