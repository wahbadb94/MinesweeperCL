using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperCL
{
    public static class BoardParser
    {
        public static List<List<string>> LocationsToCharacterMatrix(Board board)
        {
            var output = new List<List<string>>();

            foreach (var y in Enumerable.Range(0, board.Size))
            {
                var matrixRow = new List<string>(board.Size);
                foreach (var x in Enumerable.Range(0, board.Size))
                {
                    // if mine then X
                    if (board.Locations[y][x].IsMine)
                    {
                        matrixRow.Add("X");
                    }
                    // display text is the neighoring mine count, hyphens for 0
                    else
                    {
                        int count = CountNeighbors(board, x, y);
                        string toAdd = (count == 0) ? "-" : count.ToString();
                        matrixRow.Add(toAdd);
                    }

                }
                output.Add(matrixRow);
            }

            return output;
        }

        private static int CountNeighbors(Board board, int x, int y)
        {

            int minXOffset = (x == 0) ? 0 : -1;
            int maxXOffset = (x == board.Size - 1) ? 0 : 1;
            int minYOffset = (y == 0) ? 0 : -1;
            int maxYOffset = (y == board.Size - 1) ? 0 : 1;

            int count = 0;

            for (int i = minXOffset; i <= maxXOffset; i++)
            {
                for (int j = minYOffset; j <= maxYOffset; j++)
                {
                    if (board.Locations[y + j][x + i].IsMine) count++;
                }
            }

            return count;
        }
    }
}
