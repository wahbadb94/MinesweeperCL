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
                // config game
                var Game = GameConfig();

                // start game
                Game.Run();

                // ask to play again
            } while (playAgain == true);
        }

        private static Game GameConfig()
        {
            // get difficulty
            var difficulty = GameDifficulty.Medium;

            // create board
            Board board = new Board(GenerateBoardLocations(difficulty));

            // create game
            return new Game(board);
            

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
                    // each newly generated location has a 20% chance of being a mine
                    bool isMine = ( random.Next(0, 10) > 7) ? true : false ;

                    locations[j].Add(new BoardLocation(i, j, isMine));
                }

            }

            return locations;
        }

    }
}
