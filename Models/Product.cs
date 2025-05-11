using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Column("ProductID")]
        public int Id { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string Category { get; set; }
    }
}
