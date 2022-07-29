using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(6)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }
 
        [MaxLength(100)]
        public string? URL { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(50)]
        public string? TypeGoods { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, Name: {Name}, Description: {Description}, " +
                $"Address: {Address}, City: {City}, ZipCode: {ZipCode}, " +
                $"Phone: {Phone}, URL: {URL}, Email: {Email}, TypeGoods: {TypeGoods}";
        }
    }
}
