using _02.VehiclesExtension.IO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension.IO;

public class ConsoleReader : IReader
{
    public string ReadLine()
        => Console.ReadLine(); 
}
