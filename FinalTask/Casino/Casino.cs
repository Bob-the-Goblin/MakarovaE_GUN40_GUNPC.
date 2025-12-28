
using FinalTask.Games;
using FinalTask.Games.Blackjack;
using FinalTask.Games.DiceGame;
using FinalTask.Service;
using System;
using System.ComponentModel;

namespace FinalTask.Casino
{
    internal class Casino : IGame
    {
        private int maxBank = 300;
        private int casinoBank = 200;
        private int playerBank;
        private int bet;
        private string data;
        public Casino() { }

        public void StartGame()
        {
            FileSystemLoadSaveService service = new(@"D:/Users");

            Console.WriteLine("Hello, player!");
            Console.WriteLine("what's your name?");

            string name;
            do
            { name = Console.ReadLine(); }
            while (name == null);

            service.LoadData(name, out data);
            playerBank = Convert.ToInt16(data);
            CheackBank();

            Console.WriteLine("What do you want to play?");
            Console.WriteLine($"Text {(int)Game.BlackJack} for {Game.BlackJack}");
            Console.WriteLine($" or {(int)Game.DiceGame} for {Game.DiceGame}");


            if (Int32.TryParse(Console.ReadLine(), out int choice)) 
            { 
                if (choice != 1 && choice != 2)
                {
                    Console.WriteLine("We don't play today?");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Uncorrect Input");
            }

            do  SetBet();  while (bet == 0);
            
            PlayGame(choice);
            CheackBank();

            
            data = Convert.ToString(playerBank);
            service.SaveData(data, name);
            Console.WriteLine($"Bye {name}!");
        }

        private void SetBet()
        {
            Console.WriteLine("What the bet?");
            if (Int32.TryParse(Console.ReadLine(), out bet))
            {
                if (bet < 0)
                {
                    Console.WriteLine("Uncorrect bet");
                    bet = 0;
                }
                if (bet > playerBank)
                {
                    Console.WriteLine("The bet is out of your limits");
                    bet = 0;
                }
                else
                {
                    Console.WriteLine($"Your bet is {bet}");  
                }
            }
            else
            { Console.WriteLine("Uncorrect line");
             bet = 0;
            }
            
        }
        private void PlayGame(int choice)
        { 
            if (choice  == 1)
            {
                Blackjack blackjack = new Blackjack();
                Sub(blackjack);
                blackjack.PlayGame();
            }
            if (choice == 2)
            {
                DiceGame diceGame = new DiceGame(6, 0, 6);
                Sub(diceGame);
                diceGame.PlayGame();
            }

        }
        private void Sub(CasinoGameBase casino)
        {
            casino.OnWin += ResultGameWin;
            casino.OnLoose += ResultGameLoose;
            casino.OnDraw += ResultGameDraw;
        }
        private void ResultGameDraw()
        {
            Console.WriteLine("There is no winners and looser");
        }
        private void ResultGameLoose()
        {   
            playerBank -= bet;
            Console.WriteLine($"You Loose. Your bank is {playerBank}");
        }
        private void ResultGameWin()
        {
            playerBank += bet;
            Console.WriteLine($"You win! Your bank is {playerBank}");
        }
        private void CheackBank()
        { if  (playerBank == 0)
            { 
                Console.WriteLine("No money? Kicked!");
                Environment.Exit(0);
            }
          if  (playerBank > maxBank)
            {
                Console.WriteLine($"You've ruined the casino with limited score! You've ruined the score {playerBank - maxBank}");
                playerBank = maxBank;
            }
          if (casinoBank > maxBank)
            {
                Console.WriteLine("You wasted half of your bank money in casino’s bar");
                casinoBank = casinoBank / 2;
            }
        }
    }
}
