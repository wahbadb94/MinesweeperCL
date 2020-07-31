using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public class BoardLocation
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }
        public int X { get; }
        public int Y { get; }

        public BoardLocation(int x, int y, bool isMine)
        {
            X = x;
            Y = y;
            IsMine = isMine;
            IsRevealed = false;
            IsFlagged = false;
        }
    }
}
