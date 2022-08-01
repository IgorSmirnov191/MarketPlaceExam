using MarketPlaceExam.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Business.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; } = 0;

        public string? StockKeepUnitId { get; set; }

        public int? QuantityPerUnit { get; set; }

        public string? UnitSize { get; set; }

        public decimal? UnitPrice { get; set; } = 0;
        public double? UnitWeight { get; set; } = 0;
        public int SuppplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
