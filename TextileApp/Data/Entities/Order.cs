using System;
using System.ComponentModel.DataAnnotations;

namespace TextileApp.Data.Entities
{
    public class Order
    {
        [Key] public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Deadline { get; set; }
        public string? Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Notes { get; set; }
    }
}
