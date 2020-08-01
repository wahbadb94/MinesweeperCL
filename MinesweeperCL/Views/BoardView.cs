using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ResetConsoleColors();

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
            string displayCharacter = getDisplayCharacter(location);

            // translate to location, draw upper cell boarder and contents
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight);
            Console.Write($"|{new String('\'', CellWidth - 1)}|");
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight + 1);
            Console.Write($"|{new String(' ', PaddingL)}");
            Console.ForegroundColor = ColorFromDisplayCharacter(displayCharacter);
            Console.Write($"{displayCharacter}");
            ResetConsoleColors();
            Console.Write($"{new String(' ', PaddingR)}|");

        }

        private ConsoleColor ColorFromDisplayCharacter(string displayCharacter)
        {
            switch (displayCharacter)
            {
                case " ":
                    return ConsoleColor.White;
                case "1":
                    return ConsoleColor.DarkBlue;
                case "2":
                    return ConsoleColor.DarkGreen;
                case "3":
                    return ConsoleColor.DarkRed;
                case "4":
                    return ConsoleColor.DarkMagenta;
                case "5":
                    return ConsoleColor.DarkYellow;
                case "6":
                    return ConsoleColor.DarkGreen;
                case "7":
                    return ConsoleColor.DarkBlue;
                case "8":
                    return ConsoleColor.DarkRed;
                case "o":
                    return ConsoleColor.Black;
                default:
                    return ConsoleColor.White;
            }
        }

        private void PlaceCursor(Point currentLocation)
        {
            // place cursor in the middle of the consoles
            Console.SetCursorPosition(
                currentLocation.X * CellWidth + CellWidth / 2,
                currentLocation.Y * CellHeight + CellHeight / 2
            );
        }

        private string getDisplayCharacter(BoardLocation location)
        {
            if (location.IsRevealed)
            {
                return _displayCharacterMatrix[location.Y][location.X];
            }
            else
            {
                return (location.IsFlagged == true) ? "o" : " ";
            }
        }

        private void ResetConsoleColors()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
        }


    }
}
