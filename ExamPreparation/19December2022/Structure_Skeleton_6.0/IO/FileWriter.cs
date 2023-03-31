namespace UniversityCompetition.IO
{
    using System;
    using System.IO;
    using UniversityCompetition.IO.Contracts;

    public class FileWriter : IWriter
    {
        string path = "../../../result.txt";
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
