namespace Car_Webshop.Models
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public DateTime RegistrationDate { get; set; }
        public long ChassisNumber { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public string Issues { get; set; }
        public Car() {
            this.Manufacturer = "Unknown";
            this.Type = "Unknown";
            this.RegistrationDate = DateTime.Now;
            this.ChassisNumber = 0;
            this.Specification = "Unknown";
            this.Description = "Unknown";
            this.Issues = "Unknown";        
        }

        public Car(string Manufacturer, string Type, string Model, DateTime RegistrationDate, long ChassisNumber, string Specification, string Description, string Issues)
        {
            this.Manufacturer = Manufacturer;
            this.Type = Type;
            this.Model = Model;
            this.RegistrationDate = RegistrationDate;
            this.ChassisNumber = ChassisNumber;
            this.Specification = Specification;
            this.Description = Description;
            this.Issues = Issues;
        }
    }
}
