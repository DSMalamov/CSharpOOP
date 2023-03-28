using _02.Composite.Models;

namespace _02.Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            SingleGift phone = new("Phone", 256);
            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootBox = new("RootBox", 0);
            SingleGift truckToy = new("Truck Toy", 289);
            SingleGift plainToy = new("Plain Toy", 587);

            rootBox.Add(truckToy);
            rootBox.Add(plainToy);

            CompositeGift childBox = new("ChildBox", 0);
            SingleGift soldierToy = new("Soldier Toy", 200);

            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}