namespace Shapes;

public class StartUp
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Rectangle rec = new Rectangle(5, 5);

        Console.WriteLine(rec.Draw());
        Console.WriteLine(rec.CalculatePerimeter());
        Console.WriteLine(rec.CalculateArea());
        Console.WriteLine(circle.Draw());
        Console.WriteLine(circle.CalculatePerimeter());
        Console.WriteLine(circle.CalculateArea());

    }
}