using _03.Telephony.Models;
using _03.Telephony.Models.Interface;

namespace _03.Telephony;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


        foreach (var number in numbers)
        {
            ICall phone;

            if (number.Length == 10)
            {
                phone = new Smartphone();

                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            else if (number.Length == 7)
            {
                phone = new StationaryPhone();

                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
 
        }

        foreach (var url in urls)
        {
            IBrowse browse = new Smartphone();

            try
            {
                Console.WriteLine(browse.Url(url));
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }



    }
}