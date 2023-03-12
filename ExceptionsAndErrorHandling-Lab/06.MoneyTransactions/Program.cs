namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> acounts = new Dictionary<int, double>();
            string[] input = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                string[] currArr = item.Split("-", StringSplitOptions.RemoveEmptyEntries);

                acounts.Add(int.Parse(currArr[0]), double.Parse(currArr[1]));

            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int accauntNumber = int.Parse(cmdArg[1]);
                double sum = double.Parse(cmdArg[2]);

                try
                {
                    if (cmdArg[0] == "Deposit")
                    {
                        Deposit(acounts, accauntNumber);
                        acounts[accauntNumber] += sum;
                        Console.WriteLine($"Account {accauntNumber} has new balance: {acounts[accauntNumber]:f2}");
                        Console.WriteLine("Enter another command");
                    }
                    else if (cmdArg[0] == "Withdraw")
                    {
                        Windraw(acounts, accauntNumber, sum);
                        acounts[accauntNumber] -= sum;
                        Console.WriteLine($"Account {accauntNumber} has new balance: {acounts[accauntNumber]:f2}");
                        Console.WriteLine("Enter another command");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter another command");
                }
            }


        }

        private static void Windraw(Dictionary<int, double> acounts, int accauntNumber, double sum)
        {
            if (!acounts.ContainsKey(accauntNumber))
            {
                throw new ArgumentException("Invalid account!");
            }
            if (acounts[accauntNumber] < sum)
            {
                throw new ArgumentException("Insufficient balance!");
            }
        }

        private static void Deposit(Dictionary<int, double> acounts, int accNum)
        {
            if (!acounts.ContainsKey(accNum))
            {
                throw new ArgumentException("Invalid account!");
            }

        }
    }
}