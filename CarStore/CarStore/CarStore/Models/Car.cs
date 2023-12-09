using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStore.Models
{
    public class Car
    {
        [Key]
        public long CarID { get; set; }
        


        public string? Make { get; set; }
        public string? Model { get; set; }
        //public int YearOfManufacture { get; set; }
        //public int HorsePower { get; set; }
        public string? Condition { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
