
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
            int point;
            return card.Value switch
            {
                CardValue.six => point = 6,
                CardValue.seven => point = 7,
                CardValue.eight => point = 8,
                CardValue.nine => point = 9,
                CardValue.ten => point = 10,
                CardValue.ace => point = 11,
                _ => point = 10,
            };
        }
    }
}
