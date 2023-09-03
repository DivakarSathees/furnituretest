using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Furniture
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string Material { get; set; }

        public string Dimensions { get; set; }

        public decimal Price { get; set; }
    }
}
