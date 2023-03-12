using System.Numerics;

namespace _04.SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {

                try
                {

                    if (!long.TryParse(input[i], out _))
                    {
                        throw new FormatException($"The element '{input[i]}' is in wrong format!");
                    }

                    long currNum = long.Parse(input[i]);

                    if (currNum > int.MaxValue || currNum < int.MinValue)
                    {
                        throw new OverflowException($"The element '{input[i]}' is out of range!");
                    }

                    sum += (int)currNum;
                }
                catch (FormatException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }
                catch (OverflowException ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
                catch (Exception ex3)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }

                Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}