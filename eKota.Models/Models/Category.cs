using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eKota.Models.Models
{
    public class Category
    {
        [Key]
        [DisplayName("Category Code")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a value for Category name")]
        [DisplayName("Category Name"), MaxLength(50, ErrorMessage ="Category name should not exceed 50 characters")]
        public string Name { get; set; }
    }
}
