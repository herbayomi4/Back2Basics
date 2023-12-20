using System.ComponentModel.DataAnnotations.Schema;

namespace Back2Basics.Core.Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
