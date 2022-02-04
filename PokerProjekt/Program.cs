using System;

namespace PokerProjekt
{
    public class Prise
    {
        private int amount;
        private int winningTarget;
        private bool isWinning;
        private bool isLosing;

        public Prise(int amount, int winningTarget)
        {
            this.amount = amount;
            this.winningTarget = winningTarget;
            isLosing = false;
            isWinning = false;
        }

        public void Winning(int amount)
        {
            if (this.amount <= winningTarget)
            {
                this.amount = this.amount + amount;
                if (this.amount >= winningTarget)
                    isWinning = true;
            }
        }

        public void Losing(int amount)
        {
            if (this.amount <= winningTarget)
                if (this.amount > 0)
                {
                    this.amount = this.amount - amount;
                    if (this.amount <= 0)
                        isLosing = true;

                }
        }

        public void ToConsole()
        {
            if (isWinning)
            {
                Console.WriteLine("A játékos elérte a játékban a " + winningTarget + " összeget és kiszált a játékból! Nyereménye " + amount + " Ft.");
            }
            else if (isLosing)
            {
                Console.WriteLine("A játékos vesztett! Vesztesége " + amount + " Ft.");
            }
            else
            {
                Console.WriteLine("A játékos jelenlegi bevétele: " + amount + " Ft");
                Console.WriteLine("A játékos célja " + winningTarget + " Ft elérése.");
            }
        }
    }

    public class Player
    {
        private string name;
        private Prise prise;

        public Player(string name, Prise prise)
        {
            this.name = name;
            this.prise = prise;
            ToConsoleName();
        }

        public void SumUpNextRound(int amount)
        {
            if (amount > 0)
                prise.Winning(amount);
            else if (amount < 0)
                prise.Losing(-amount);
            ToConsolRound();
        }


        private void ToConsoleName()
        {
            Console.WriteLine("A Játékos neve: "+name+".");
        }

        private void ToConsolRound()
        {
            Console.WriteLine("A forduló eredménye:");
            prise.ToConsole();
        }
    }
        

    class Program
    {
        static void Main(string[] args)
        {
            Prise priseStart = new Prise(100, 120);
            priseStart.ToConsole();

            Player playerWinner = new Player("Nyerő Jani", priseStart);
            playerWinner.SumUpNextRound(10);
            playerWinner.SumUpNextRound(-5);
            playerWinner.SumUpNextRound(20);
            playerWinner.SumUpNextRound(10);

            Console.WriteLine();

            Prise priseEnd = new Prise(20, 120);
            priseStart.ToConsole();

            Player playerLoser = new Player("Vesztő Vendel", priseEnd);
            playerLoser.SumUpNextRound(-10);
            playerLoser.SumUpNextRound(5);
            playerLoser.SumUpNextRound(-20);
            playerLoser.SumUpNextRound(-10);
       }
    }
}
