using System;
using System.ComponentModel.DataAnnotations;

namespace TextileApp.Data.Entities
{
    public class Material
    {
        [Key] public int MaterialId { get; set; }
        public string? Name { get; set; }
        public string? Composition { get; set; }
        public decimal Width { get; set; }
        public decimal PricePerMeter { get; set; }
        public string? Color { get; set; }
        public int StockQuantity { get; set; }
        public string? Supplier { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}

