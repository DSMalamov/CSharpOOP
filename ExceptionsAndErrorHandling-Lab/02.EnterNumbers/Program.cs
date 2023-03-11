namespace _02.EnterNumbers;

public class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int start = 1;
        int end = 100;

        while (numbers.Count < 10)
        {
            try
            {
                string n = Console.ReadLine();
                ReadNumber(start, end, numbers, n);
                int number = int.Parse(n);
                numbers.Add(number);
                start = number;
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        Console.WriteLine(string.Join(", ", numbers));
    }

    private static void ReadNumber(int start, int end, List<int> numbers,string n)
    {
        var isNumeric = int.TryParse(n, out _);

        if (!isNumeric)
        {
            throw new ArgumentException("Invalid Number!");
        }

        int number = int.Parse(n);

        if (number <= start || number >= end)
        {
            throw new ArgumentException($"Your number is not in range {start} - 100!");
        }

    }
}