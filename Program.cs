namespace Casino_Game_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cardIndex, x;
            bool done = false;
            x = 0;
            string guess;
            Random generator = new Random();

            List<int> usedCards = new List<int>();
            List<string> usingCards = new List<string>();
            var cards = File.ReadAllLines("all_cards.txt");



            while (!done)
            {
                Console.Write("Guess a card:  ");
                guess = Console.ReadLine();

                for (int i = 0; i < 3; i++)
                {
                    cardIndex = generator.Next(0, 52);
                    if (usedCards.Contains(cardIndex))
                    {
                        do
                        {
                            cardIndex = generator.Next(0, 52);
                        } while (usedCards.Contains(cardIndex));
                    }
                    usedCards.Add(cardIndex);
                    Console.WriteLine(cards[cardIndex]);
                    usingCards.Add(cards[cardIndex]);
                }

                if (!cards.Contains(guess))
                    Console.WriteLine("Thats not an option");

                if (usingCards.Contains(guess))
                    Console.WriteLine("Congrats!");

                if (!usingCards.Contains(guess))
                    Console.WriteLine("Nope!");

                usedCards.Clear();
                usingCards.Clear();
            }
        }
    }
}