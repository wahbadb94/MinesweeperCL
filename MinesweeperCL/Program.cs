using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MinesweeperCL
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // user plays as many times as they want
            bool playAgain;
            do
            {
                // start a new game
                var game = GameConfig.Config();
                game.Run();

                playAgain = game.AskPlayAgain();
            } while (playAgain);
        }
    }
}
