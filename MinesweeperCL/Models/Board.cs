using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MinesweeperCL
{
    public class Board
    {
        public int Size => Locations.Count; // returns height of board
        public List<List<BoardLocation>> Locations { get; set; }
        public List<List<string>> DisplayCharacters { get; private set; }

        public Board(List<List<BoardLocation>> locations)
        {
            Locations = locations;
            DisplayCharacters = LocationsToCharacterMatrix();
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
    }
}
