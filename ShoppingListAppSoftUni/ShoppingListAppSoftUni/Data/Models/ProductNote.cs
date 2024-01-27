using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListAppSoftUni.Data.Models
{
    public class ProductNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
