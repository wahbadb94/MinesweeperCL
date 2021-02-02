using System;
using System.Collections.Generic;
using System.Linq;

namespace MinesweeperCL.Models
{
    public class Board
    {
        public int Size => Locations.Count; // returns height of board
        public List<List<BoardLocation>> Locations { get; set; }
        public List<List<string>> DisplayCharacters { get; }
        public bool MineHit;

        public Board(GameDifficulty difficulty)
        {
            Locations = GenerateBoardLocations(difficulty);
            DisplayCharacters = LocationsToCharacterMatrix();
            MineHit = false;
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

        public List<List<string>> LocationsToCharacterMatrix()
        {
            var output = new List<List<string>>();

            foreach (var y in Enumerable.Range(0, Size))
            {
                var matrixRow = new List<string>(Size);
                foreach (var x in Enumerable.Range(0, Size))
                {
                    // if mine then X
                    if (Locations[y][x].IsMine)
                    {
                        matrixRow.Add("X");
                    }
                    // display text is the neighoring mine count, hyphens for 0
                    else
                    {
                        int count = CountNeighbors(x, y);
                        string toAdd = (count == 0) ? "-" : count.ToString();
                        matrixRow.Add(toAdd);
                    }

                }
                output.Add(matrixRow);
            }

            return output;
        }

        private int CountNeighbors(int x, int y)
        {

            int minXOffset = (x == 0) ? 0 : -1;
            int maxXOffset = (x == Size - 1) ? 0 : 1;
            int minYOffset = (y == 0) ? 0 : -1;
            int maxYOffset = (y == Size - 1) ? 0 : 1;

            int count = 0;

            for (int i = minXOffset; i <= maxXOffset; i++)
            {
                for (int j = minYOffset; j <= maxYOffset; j++)
                {
                    if (Locations[y + j][x + i].IsMine) count++;
                }
            }

            return count;
        }

        public void Reveal(int x, int y)
        {
            Locations[y][x].IsRevealed = true;
            if (DisplayCharacters[y][x] == "-")
            {
                RevealNeighbors(x, y);
            }

            if (Locations[y][x].IsMine)
            {
                MineHit = true;
            }
        }

        private void RevealNeighbors(int x, int y)
        {
            //Thread.Sleep(50);

            var minXOffset = (x == 0) ? 0 : -1;
            var maxXOffset = (x == Size - 1) ? 0 : 1;
            var minYOffset = (y == 0) ? 0 : -1;
            var maxYOffset = (y == Size - 1) ? 0 : 1;

            // iterate over neighbors
            for (var i = minXOffset; i <= maxXOffset; i++)
            {
                for (var j = minYOffset; j <= maxYOffset; j++)
                {
                    // reveal neighbor if not already revealed
                    if (!Locations[y + j][x + i].IsRevealed) Reveal(x + i, y + j);
                }
            }
        }
    }
}
