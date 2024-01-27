using System.ComponentModel.DataAnnotations;

namespace ShoppingListAppSoftUni.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public IList<ProductNote> ProductNotes { get; set; }
            = new List<ProductNote>();
    }
}
