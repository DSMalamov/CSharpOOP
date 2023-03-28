using _03.TemplatePattern.Models;

namespace _03.TemplatePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sourdough sourdough= new Sourdough();
            sourdough.Make();

            TwelveGrain twelveGrain= new TwelveGrain();
            twelveGrain.Make();

            WholeWheat wholeWheat= new WholeWheat();
            wholeWheat.Make();
        }
    }
}