using System;
using System.ComponentModel.DataAnnotations;

namespace TextileApp.Data.Entities
{
    public class Material
    {
        [Key] public int material_id { get; set; }
        public string? name { get; set; }
        public string? composition { get; set; }
        public decimal width { get; set; }
        public decimal price_per_meter { get; set; }
        public string? color { get; set; }
        public int stock_quantity { get; set; }
        public string? supplier { get; set; }
        public DateTime arrival_date { get; set; }
    }
}

