using static Car_Webshop.Models.Cars;

namespace Car_Webshop.Models
{
    public class Cars
    {
        private static List<Car> list = new List<Car>()
            {
            //We should make a file read for this. And generate a big txt with the Chat GPT. 
            new Car("Ford", "Sedan", "Focus", new DateTime(1999, 02, 11), 12345678, "Gasoline", "In good shape", "Little scraches on the left side"),
            new Car("Suzuki", "Hatchback", "Swift", new DateTime(2000, 02, 12), 22345678, "Gasoline", "In good shape", "Nothing")
            };

            public static List<Car> List()
            { return list; }
    }
}
