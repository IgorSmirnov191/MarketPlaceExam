using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(50)]
        public string? Address { get; set; }
        
        [MaxLength(50)]
        public string? City { get; set; }
        
        [MaxLength(8)]
        public string? ZipCode { get; set; }
            
        [MaxLength(50)]
        public string? ShipAddress { get; set; }
        
        [MaxLength(50)]
        public string? ShipCity { get; set; }
        
        [MaxLength(8)]
        public string? ShipZipCode { get; set; }
       
        [MaxLength(50)]
        public string? ShipPhoneNumber { get; set; }
      
        [MaxLength(50)]
        public string? ShipEmail { get; set; }

        public override string ToString()
        {
            return $"Id{Id}, Name: {UserName}, " +
                $"Address: {Address}, City: {City}, ZipCode: {ZipCode}, " +
                $"Phone: {PhoneNumber}, Email: {Email}" +
                $"ShipAddress: {ShipAddress}, ShipCity: {ShipCity}, ShipZipCode: {ShipZipCode}," +
                $"ShipPhone: {ShipPhoneNumber}, Email: {ShipEmail}";
        }
    }
}
