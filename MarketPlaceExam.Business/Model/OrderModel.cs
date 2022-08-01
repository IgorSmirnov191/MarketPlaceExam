using MarketPlaceExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime OrderDate { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
