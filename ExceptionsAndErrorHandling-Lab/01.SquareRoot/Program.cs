namespace _01.SquareRoot;

public class Program
{
    static void Main(string[] args)
    {
        
        double number = Math.Sqrt(double.Parse(Console.ReadLine()));
        try
        {
            if (number == double.NaN || number != ((int)number))
            {
                throw new ArgumentException("Invalid number.");
            }

            Console.WriteLine(number);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Goodbye.");
        

        
    }
}