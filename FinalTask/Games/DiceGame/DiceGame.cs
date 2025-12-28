using FinalTask.CardsAndDice;

namespace FinalTask.Games.DiceGame
{
    internal class DiceGame : CasinoGameBase
    {
        private int Amount { get; }
        private int Min {  get; }
        private int Max { get; }

        private List<Dice> playerDices = new List<Dice>();
        private List<Dice> computerDices = new List<Dice>();


        public DiceGame(int diceAmount, int min, int max) 
        {
            this.Amount = diceAmount;
            this.Min = min;
            this.Max = max;

            FactoryMethod();
        }

        protected override void FactoryMethod()
        {  
            for (int i = 0; i < Amount; i++)
            {   
                Dice dice = new (Min, Max);
                playerDices.Add(dice);
                Dice pcDice = new (Min, Max);
                computerDices.Add(pcDice);
            }

        }

       
        public override void PlayGame()
        {   int playerPoints = 0;
            int computerPoints = 0;

            foreach (Dice dice in playerDices)
            {    
                playerPoints += dice.TheValue();      
            }
            foreach (Dice dice in computerDices)
            {          
                computerPoints += dice.TheValue();
            }

            WritePoints(playerPoints, computerPoints);

            if (playerPoints > computerPoints)
            { OnWinInvoke(); }
            if (playerPoints < computerPoints)
            { OnLooseInvoke(); }
            if (playerPoints == computerPoints)
            { OnDrawInvoke(); }
        } 
        private static void WritePoints(int playerP, int computerP)
        {
            Console.WriteLine($"Playe's score is {playerP}");
            Console.WriteLine($"Computer's score is {computerP}");
        }

    }
}
