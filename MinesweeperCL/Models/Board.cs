using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public class Board
    {
        public int Size => Locations.Count; // returns height of board
        public List<List<BoardLocation>> Locations { get; set; }

        public Board(List<List<BoardLocation>> locations)
        {
            Locations = locations;
        }
    }
}
