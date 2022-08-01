using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
       
        [MaxLength(50)]
        public string? Address { get; set; }
        
        [MaxLength(50)]
        public string? City { get; set; }
        
        [MaxLength(6)]
        public string? ZipCode { get; set; }
       
        [MaxLength(50)]
        public string? Phone { get; set; }
        
        [MaxLength(50)]
        public string? Email { get; set; }
        
        [MaxLength(50)]
        public string? ShipAddress { get; set; }
        
        [MaxLength(50)]
        public string? ShipCity { get; set; }
        
        [MaxLength(6)]
        public string? ShipZipCode { get; set; }
       
        [MaxLength(50)]
        public string? ShipPhone { get; set; }
      
        [MaxLength(50)]
        public string? ShipEmail { get; set; }
        public string? AuthToken { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, Name: {Name}, " +
                $"Address: {Address}, City: {City}, ZipCode: {ZipCode}, " +
                $"Phone: {Phone}, Email: {Email}" +
                $"ShipAddress: {ShipAddress}, ShipCity: {ShipCity}, ShipZipCode: {ShipZipCode}," +
                $"ShipPhone: {ShipPhone}, Email: {ShipEmail}";
        }
    }
}
