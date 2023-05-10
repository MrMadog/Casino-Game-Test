namespace Casino_Game_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cardIndex;
            int points = 0;
            bool done = false;
            string suit, guess;
            int rank;
            Random generator = new Random();

            List<int> usedCards = new List<int>();
            List<string> usingCards = new List<string>();
            var cards = File.ReadAllLines("all_cards.txt");



            while (!done)
            {
                Console.Write("Guess a suit:  ");
                suit = Console.ReadLine();
                Console.Write("Guess a rank:  ");
                Int32.TryParse(Console.ReadLine(), out rank);


                guess = suit + " " + rank.ToString();

                Console.WriteLine(guess);
                Console.WriteLine();
                Console.WriteLine("Your cards:  ");
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

                for (int i = 0; i < 3; i++)
                {
                    if (usingCards[i].Contains($" {rank.ToString()}"))
                    {
                        points += 3;
                    }
                    if (usingCards[i].Contains(suit))
                    {
                        points += 1;
                    }
                    if (usingCards[i].Contains(guess))
                    {
                        points += 6;
                    }
                }

                Console.WriteLine(points);

                if (!cards.Contains(guess))
                    Console.WriteLine("Thats not an option");

                if (usingCards.Contains(guess))
                    Console.WriteLine("Congrats!");

                if (!usingCards.Contains(guess))
                    Console.WriteLine("Nope!");


                if (points == 0)
                    Console.WriteLine("You lose your bet!");
                if (points == 1)
                    Console.WriteLine("You get half your bet!");
                if (points == 2 || points == 3)
                    Console.WriteLine("You get your bet back!");
                if (points == 4)
                    Console.WriteLine("You get 1.5x your bet!");
                if (points == 5 || points == 6)
                    Console.WriteLine("You get 5x your bet!");
                if (points == 7 || points == 14)
                    Console.WriteLine("You get 50x your bet!");
                if (points == 9 || points == 16)
                    Console.WriteLine("You get 100x your bet!");
                if (points == 10 || points == 11)
                    Console.WriteLine("You get 2x your bet!");
                if (points == 12 || points == 13)
                    Console.WriteLine("You get 10x your bet");



                usedCards.Clear();
                usingCards.Clear();
                points = 0;

            }
        }
    }
}