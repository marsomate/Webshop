using System.ComponentModel.DataAnnotations;

namespace CarStore.Models
{
    // This class represents the 'Car' entity in the application.
    public class Car
    {
        // Primary key for the 'Car' entity.
        [Key]
        public long CarID { get; set; }

        // Property for the make of the car.
        public string? Make { get; set; }

        // Property for the model of the car.
        public string? Model { get; set; }

        // Property for the condition of the car.
        public string? Condition { get; set; }

        // Property for the price of the car.
        public decimal Price { get; set; }

        // Property for the description of the car.
        public string? Description { get; set; }
    }
}
