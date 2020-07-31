using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public static class BoardView
    {
        private const int CellWidth = 4;    // a location on the board is 4 characters wide on the console
        private const int CellHeight = 2;   // a location on the board is 2 lines tall on the console
        
        // padding to left and right of cell display text based on CellWidth
        private const int PaddingL = CellWidth / 2 - 1;
        private const int  PaddingR = (CellWidth / 2 + CellWidth % 2) - 1;

        public static void View(Board board, Point playerPosition)
        {
            // display Board to Screen
            foreach (var row in board.Locations)
            {
                foreach (var location in row)
                {
                    DisplayLocation(location);
                }
            }

            // draw bottom boarder
            Console.SetCursorPosition(0, board.Size * CellHeight);
            Console.Write(new String('\'', board.Size * CellWidth + 1));

            // place cursor at player's position
            PlaceCursor(playerPosition);
        }

        public static void DisplayLocation(BoardLocation location)
        {
            string displayCharacter = "o";

            // translate to location
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight);

            // draw upper boarder
            Console.Write($"|{new String('\'', CellWidth - 1)}|");

            // draw contents
            Console.SetCursorPosition(location.X*CellWidth, location.Y*CellHeight+1);
            Console.Write($"|{new String(' ', PaddingL)}{displayCharacter}{new String(' ', PaddingR)}|");

        }

        private static void PlaceCursor(Point currentLocation)
        {
            // place cursor in the middle of the consoles
            Console.SetCursorPosition(
                currentLocation.X * CellWidth + CellWidth / 2,
                currentLocation.Y * CellHeight + CellHeight / 2
            );
        }
    }
}
