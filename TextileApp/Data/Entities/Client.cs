using System.ComponentModel.DataAnnotations;

namespace TextileApp.Data.Entities
{
    public class Client
    {
        [Key] public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
