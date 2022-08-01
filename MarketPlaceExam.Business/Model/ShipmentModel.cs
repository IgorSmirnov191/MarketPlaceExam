using MarketPlaceExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Model
{
    public class ShipmentModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        public DateTime? ShipmentDate { get; set; }

    }
}
