using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MinesweeperCL
{
    class Program
    {
        static void Main(string[] args)
        {
            // set up game loop so user can play as many times as they want
            var playAgain = true;

            do
            {
                // config and run game
                var Game = GameConfig.Config();
                Game.Run();

                // ask to play again
            } while (playAgain == true);
        }
    }
}
