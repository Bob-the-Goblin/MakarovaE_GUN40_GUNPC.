using FinalTask.CardsAndDice;

namespace FinalTask.Games.Blackjack
{
    public class Blackjack : CasinoGameBase
    {
        private Queue<Card> deck = new Queue<Card>();
        private List<Card> cards = new List<Card>();

        protected override void FactoryMethod()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            { 
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    cards.Add(new Card(suit, value));     
                }
            }

        }

        private void Shuffle()
        { 
        Random rand = new();
        int a;
         for (int i = cards.Count; i > 0; i--)
            {  a = rand.Next(0, cards.Count);
                deck.Enqueue(cards[a]);
                cards.RemoveAt(a);
            }
        }

        public Blackjack()
        {
            FactoryMethod();
        }

        public override void PlayGame()
        {
            int playrPoints;
            int computerPoints;
            List<Card> playerCards = [];
            List<Card> computerCards = [];
            Shuffle();
            
            playerCards.Add(deck.Dequeue());
            playerCards.Add(deck.Dequeue());

            computerCards.Add(deck.Dequeue());
            computerCards.Add(deck.Dequeue());

            WritePoints(playrPoints = CountsPoints(playerCards), computerPoints = CountsPoints(computerCards));

            CountResult(playrPoints, computerPoints);
            if (playrPoints == computerPoints && playrPoints < 21)
            { 
                playerCards.Add(deck.Dequeue());
                computerCards.Add(deck.Dequeue());

                Console.WriteLine("Cards was added. Points now:");
                WritePoints(playrPoints = CountsPoints(playerCards), computerPoints = CountsPoints(computerCards));

                CountResult(playrPoints, computerPoints);
            }
            
        }
        private static int CountsPoints(List<Card> cards)
            { 
                int points= 0;
                foreach (Card card in cards)
                {
                    points += card.TheValue(card); 
                }
                return points;
            }        
        private static void WritePoints(int playerP, int computerP)
        {
            Console.WriteLine($"Sum of player's point is {playerP}");
            Console.WriteLine($"Sum of computer's points is {computerP}");
        }
        private void CountResult(int playerP, int computerP)
        {
            if (playerP <= 21 && (computerP > 21|| computerP < playerP))
            { OnWinInvoke(); }
            if (computerP <= 21 && (playerP > 21 || playerP < computerP))
            { OnLooseInvoke(); }
            if ((computerP == playerP && playerP == 21) || (playerP > 21 & computerP > 21))
            { OnDrawInvoke(); }
        }
    }
}

