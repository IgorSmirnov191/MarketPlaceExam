using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
   public class Shipment
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        public DateTime? ShipmentDate { get; set; }
        

        public override string ToString()
        {
            return $"Id{Id}, OrderId: {OrderId}, ShipperId: {ShipperId}," +
                $"Date of Shipment: {ShipmentDate}";
        }
    }
}
