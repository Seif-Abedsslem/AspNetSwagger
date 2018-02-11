using System.ComponentModel.DataAnnotations;

namespace SwaggerDemo.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}