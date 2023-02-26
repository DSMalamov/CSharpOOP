using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                string[] cmdArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (command)
                    {
                        case "Dog":
                            Console.WriteLine(command);
                            Dog dog = new(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                            Console.WriteLine(dog.ToString());
                            break;
                        case "Cat":
                            Console.WriteLine(command);
                            Cat cat = new(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                            Console.WriteLine(cat.ToString());
                            break;
                        case "Frog":
                            Console.WriteLine(command);
                            Frog frog = new(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                            Console.WriteLine(frog.ToString());
                            break;
                        case "Tomcat":
                            Console.WriteLine(command);
                            Tomcat tomcat = new(cmdArg[0], int.Parse(cmdArg[1]));
                            Console.WriteLine(tomcat.ToString());
                            break;
                        case "Kittens":
                            Console.WriteLine(command);
                            Kitten kitten = new(cmdArg[0], int.Parse(cmdArg[1]));
                            Console.WriteLine(kitten.ToString());
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                
            }
        }
    }
}
