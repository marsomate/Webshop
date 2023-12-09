namespace CarStore.Models
{
    // This class represents an item in the shopping cart.
    public class Item
    {
        // Property to store the product (Car) associated with the item.
        public Car Product { get; set; }

        // Property to store the quantity of the product in the cart.
        public int Quantity { get; set; }
    }
}
