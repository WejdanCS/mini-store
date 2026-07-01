using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini_store.Models;

public class Product
{

    
    public int Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    [Display(Name = "Product Name")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    [Display(Name = "Price")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
//     public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;




        public int? CategoryId {get ; set ;}  // Foreign Key 
     
     

       [ForeignKey("CategoryId")]
       public virtual Category? Category{get;set;}

    //    public virtual ICollection<Image> Images {get;set;}=new List<Image>();
}