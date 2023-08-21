using System.ComponentModel.DataAnnotations;

namespace gRPCwithDotnet.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsDelete { get; set; } = false
    }
}
