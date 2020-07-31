using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperCL
{
    public static class GameConfig
    {


        public static Game Config()
        {
            var Player = GetPlayerName();
            var difficulty = GetDifficulty();
            var board = new Board(GenerateBoardLocations(difficulty));

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

        private static List<List<BoardLocation>> GenerateBoardLocations(GameDifficulty difficulty)
        {
            int size;
            List<List<BoardLocation>> locations = new List<List<BoardLocation>>();

            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    size = 5;
                    break;
                case GameDifficulty.Medium:
                    size = 8;
                    break;
                case GameDifficulty.Hard:
                    size = 12;
                    break;
                default:
                    size = 0;
                    break;
            }

            var random = new Random();

            // create size x size 2D array of BoardLocations
            // add 'size' amount of rows
            foreach (var j in Enumerable.Range(0, size))
            {
                locations.Add(new List<BoardLocation>());

                // add 'size' amount of locations per row
                foreach (var i in Enumerable.Range(0, size))
                {
                    // each newly generated location has a 10% chance of being a mine
                    bool isMine = (random.Next(0, 10) > 8) ? true : false;

                    locations[j].Add(new BoardLocation(i, j, isMine));
                }

            }

            return locations;
        }
    }
}
