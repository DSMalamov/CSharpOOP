using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpaceStation.IO
{
    public class TextWriter : IWriter
    {
        private string path = "../../../result.txt";
        public void Write(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
