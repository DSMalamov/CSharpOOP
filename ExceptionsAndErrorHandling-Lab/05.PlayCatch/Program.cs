namespace _05.PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exeptionsCount = 0;

            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (exeptionsCount < 3)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (cmdArg[0])
                    {
                        case "Replace":
                            if (!int.TryParse(cmdArg[2], out _))
                            {
                                throw new ArgumentException("The variable is not in the correct format!");
                            }

                            CheckIndices(int.Parse(cmdArg[1]), input);

                            input[int.Parse(cmdArg[1])] = int.Parse(cmdArg[2]);

                            break;
                        case "Show":

                            if (!int.TryParse(cmdArg[1], out _))
                            {
                                throw new ArgumentException("The variable is not in the correct format!");
                            }

                            CheckIndices(int.Parse(cmdArg[1]), input);

                            Console.WriteLine(input[int.Parse(cmdArg[1])]);

                            break;
                        case "Print":
                            if (!int.TryParse(cmdArg[1], out _) || !int.TryParse(cmdArg[2], out _))
                            {
                                throw new ArgumentException("The variable is not in the correct format!");
                            }

                            CheckIndices(int.Parse(cmdArg[1]), input);
                            CheckIndices(int.Parse(cmdArg[2]), input);
                            int number = int.Parse(cmdArg[2]) - int.Parse(cmdArg[1]);
                            int[] currArr = input.Skip(int.Parse(cmdArg[1])).ToArray();
                            int[] secondArr = currArr.Take(number).ToArray();
                            Console.WriteLine(string.Join(", ", secondArr));

                            break;

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        

        private static void CheckIndices(int index, int[] input)
        {
            if (input[index] == null)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }
        }
    }
}