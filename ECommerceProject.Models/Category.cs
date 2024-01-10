using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models { 
    public class Category
    {
        [Key]
        public int Id { get; set; } //primary key, how to define this as PK? Data Annotations [Key]

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Display Order")] //to customize the name kapag ginamit somewhere like label for an input
        [Range(0,100,ErrorMessage ="Display Order myst be between 1-100.")] //ErrorMessage customizes the error message
        public int DisplayOrder { get; set; }
    }
}