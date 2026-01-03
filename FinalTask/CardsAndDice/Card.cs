
namespace FinalTask.CardsAndDice
{
    struct Card
    {
        readonly CardSuit Suit { get; }
        readonly CardValue Value { get; }

        public Card(CardSuit suit, CardValue value)
        {
            Suit = suit;
            Value = value;
        }

        public void WritteCard(Card card)
        {
            Console.WriteLine(Convert.ToString(Suit), Value);

        }

        public int TheValue(Card card)
        {
            return (int)card.Value;
        }
    }
}
