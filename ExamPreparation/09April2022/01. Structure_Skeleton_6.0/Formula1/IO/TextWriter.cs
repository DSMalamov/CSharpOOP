using Formula1.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.IO
{
    public class TextWriter : IWriter
    {
        string path = "../../../result.txt";
        public void Write(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
