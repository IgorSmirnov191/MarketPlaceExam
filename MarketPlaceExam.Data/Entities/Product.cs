using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceExam.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(2500)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; } = 0;

        [MaxLength(50)]
        public string? StockKeepUnitId { get; set; }

        public int? QuantityPerUnit { get; set; }

        [MaxLength(50)]
        public string? UnitSize { get; set; }

        public decimal? UnitPrice { get; set; } = 0;
        public double? UnitWeight { get; set; } = 0;
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PictureId { get; set; }
        public Picture Picture { get; set; }

       
        public override string ToString()
        {
            return $"Id{Id}, Name: {Name}, Description: {Description}, " +
                $"Price: {Price}, SKU: {StockKeepUnitId}, Quantity Per Unit: {QuantityPerUnit}, " +
                $"UnitSize: {UnitSize}, Price Per Unit: {UnitPrice}, UnitWeight: {UnitWeight}" +
                $"SupplierId: {SupplierId}, CategoryId: {CategoryId}" +
                $"PictureId: {PictureId}";
        }
    }
}
