using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL.Views
{
    public static class DisplayConstants
    {
        public const int CellWidth = 4;    // a location on the board is 4 characters wide on the console
        public const int CellHeight = 2;   // a location on the board is 2 lines tall on the console

        // padding to left and right of cell display text based on CellWidth
        public const int PaddingL = CellWidth / 2 - 1;
        public const int PaddingR = (CellWidth / 2 + CellWidth % 2) - 1;

        public const ConsoleColor ForegroundColor = ConsoleColor.White;
        public const ConsoleColor BackgroundColor = ConsoleColor.Black;
    }
}
