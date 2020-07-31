using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public static class BoardView
    {
        private const int CellWidth = 4;    // a location on the board is 4 characters wide on the console
        private const int CellHeight = 2;   // a location on the board is 2 lines tall on the console

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

            // place cursor at player's position
            PlaceCursor(playerPosition);
        }

        public static void DisplayLocation(BoardLocation location)
        {
            Console.SetCursorPosition(location.X*CellWidth, location.Y*CellHeight);
            Console.Write($"|{new String('\'', CellWidth-1)}|");
            Console.SetCursorPosition(location.X*CellWidth, location.Y*CellHeight+1);
            Console.Write($"|{location.X}" + new string(' ', CellWidth - 3) + $"{location.Y}|");
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
