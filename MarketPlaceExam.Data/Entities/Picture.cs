using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Entities
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Uri { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, Uri: {Uri}";
        }
    }
}
