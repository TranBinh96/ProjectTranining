using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NET.BOOK.MVC.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
