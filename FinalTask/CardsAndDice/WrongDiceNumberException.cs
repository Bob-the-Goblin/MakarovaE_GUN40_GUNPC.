
namespace FinalTask.CardsAndDice
{
    internal class WrongDiceNumberException : Exception
    {
        public WrongDiceNumberException(string mess) => Console.WriteLine(Message + mess);
    }
}
