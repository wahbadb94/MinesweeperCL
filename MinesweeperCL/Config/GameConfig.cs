using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinesweeperCL.Models;

namespace MinesweeperCL
{
    public static class GameConfig
    {

        public static Game Config()
        {
            var difficulty = GetDifficulty();
            var board = new Board(difficulty);

            return new Game(board);
        }

        private static string GetPlayerName()
        {
            return "Dustin";
        }

        private static GameDifficulty GetDifficulty()
        {
            return GameDifficulty.Medium;
        }
    }
}
