
namespace FinalTask.CardsAndDice
{
    
    struct Dice
    {
        private int max;
        private int min;
        Random random = new();
        readonly int Number 
        {
            get { return random.Next(min, max);}
        }

        public Dice(int min, int max)
        {
            this.max = max;
            this.min = min;
            if (Number < 1 && Number > int.MaxValue)
            {
                throw new WrongDiceNumberException($"Your number is {Number}, when range is {min}-{max}.");
            }
        }

        public int TheValue()
            { return Number; }
    }
}
