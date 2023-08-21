using System.ComponentModel.DataAnnotations;

namespace gRPCwithDotnet.Models
{
    public class Product : BaseEntity
    {
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Name field cannot be empty.")]
        public required string Name { get; set; }
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Description field cannot be empty.")]
        public required string Description { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public required decimal Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "StockQuantity must be greater than 0.")]
        public required int StockQuantity { get; set; }
    }
}
