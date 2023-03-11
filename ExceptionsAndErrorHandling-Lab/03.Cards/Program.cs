namespace _03.Cards;

public class Program
{

    static void Main(string[] args)
    {
        string[] input = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);

        List<Card> cards = new List<Card>();

        for (int i = 0; i < input.Length; i++)
        {
            try
            {
                string[] itemArg = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cards.Add(CreateCard(itemArg[0], itemArg[1]));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(" ", cards));
        
    }

    private static Card CreateCard(string face, string suit)
    {
        Card newCard = new Card(face, suit);
        return newCard;
    }
}


public class Card
{
    private string face;
    private string suit;
    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }
    public string Face
    {
        get => face;
        private set
        {
            if (value == "1" || value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" ||
                value == "8" || value == "9" || value == "10" || value == "J" || value == "Q" || value == "K" || value == "A")
            {
                face = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }
    public string Suit
    {
        get => suit;
        private set
        {
            if (value == "S" || value == "H" || value == "D" || value == "C")
            {
                switch (value)
                {
                    case "S":
                        value = "\u2660";
                        break;
                    case "H":
                        value = "\u2665";
                        break;
                    case "D":
                        value = "\u2666";
                        break;
                    case "C":
                        value = "\u2663";
                        break;
                    
                }
                suit = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }

}