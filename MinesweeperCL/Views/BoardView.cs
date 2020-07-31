using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using static MinesweeperCL.Views.DisplayConstants;

namespace MinesweeperCL
{
    public class BoardView
    {
        private readonly List<List<string>> _displayCharacterMatrix;
        
        public BoardView(Board board)
        {
            _displayCharacterMatrix = BoardParser.LocationsToCharacterMatrix(board);
        }

        public void Display(Board board, Point playerPosition)
        {
            // display Board to Screen
            DisplayBoard(board);

            // place cursor at player's position
            PlaceCursor(playerPosition);
        }

        private void DisplayBoard(Board board)
        {
            // iterate over rows
            foreach (var row in board.Locations)
            {
                // iterate over each row
                foreach (var location in row)
                {
                    // display appropriate character for location
                    DisplayLocation(location);
                }
            }

            // draw bottom border for entire board
            Console.SetCursorPosition(0, board.Size * CellHeight);
            Console.Write(new String('\'', board.Size * CellWidth + 1));
        }

        private void DisplayLocation(BoardLocation location)
        {
            string displayCharacter = (location.IsRevealed) ? _displayCharacterMatrix[location.Y][location.X] : " ";

            if (location.IsRevealed) displayCharacter = _displayCharacterMatrix[location.Y][location.X];
            else
            {
                displayCharacter = (location.IsFlagged == true) ? "o" : " ";
            }

            // translate to location
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight);

            // draw upper cell border
            Console.Write($"|{new String('\'', CellWidth - 1)}|");

            // draw contents
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight + 1);
            Console.Write($"|{new String(' ', PaddingL)}{displayCharacter}{new String(' ', PaddingR)}|");

        }

        private void PlaceCursor(Point currentLocation)
        {
            // place cursor in the middle of the consoles
            Console.SetCursorPosition(
                currentLocation.X * CellWidth + CellWidth / 2,
                currentLocation.Y * CellHeight + CellHeight / 2
            );
        }
    }
}
