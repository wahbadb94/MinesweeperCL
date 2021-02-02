using System;
using System.Collections.Generic;
using System.Linq;
using MinesweeperCL.Models;
using static MinesweeperCL.Views.DisplayConstants;

namespace MinesweeperCL.Views
{
    public class BoardView
    {
        private readonly List<List<string>> _displayCharacterMatrix;
        private readonly Board _board;
        private int _messageLineCount;
        
        public BoardView(Board board)
        {
            _board = board;
            _displayCharacterMatrix = BoardParser.LocationsToCharacterMatrix(board);
            _messageLineCount = 0;
        }

        public void Display(Point playerPosition)
        {
            // display Board to Screen
            DisplayBoard();

            // place cursor at player's position
            PlaceCursor(playerPosition);
        }

        private void DisplayBoard()
        {
            ResetConsoleColors();

            // iterate over rows
            foreach (var row in _board.Locations)
            {
                // iterate over each row
                foreach (var location in row)
                {
                    // display appropriate character for location
                    DisplayLocation(location);
                }
            }

            // draw bottom border for entire board
            Console.SetCursorPosition(0, _board.Size * CellHeight);
            Console.Write(new string('\'', _board.Size * CellWidth + 1));
        }

        private void DisplayLocation(BoardLocation location)
        {
            var displayCharacter = GetDisplayCharacter(location);

            // translate to location, draw upper cell boarder and contents
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight);
            Console.Write($"|{new string('\'', CellWidth - 1)}|");
            Console.SetCursorPosition(location.X * CellWidth, location.Y * CellHeight + 1);
            Console.Write($"|{new string(' ', PaddingL)}");
            Console.ForegroundColor = ColorFromDisplayCharacter(displayCharacter);
            Console.Write($"{displayCharacter}");
            ResetConsoleColors();
            Console.Write($"{new string(' ', PaddingR)}|");

        }

        private static ConsoleColor ColorFromDisplayCharacter(string displayCharacter)
        {
            return displayCharacter switch
            {
                " " => ConsoleColor.White,
                "1" => ConsoleColor.DarkBlue,
                "2" => ConsoleColor.DarkGreen,
                "3" => ConsoleColor.DarkRed,
                "4" => ConsoleColor.DarkMagenta,
                "5" => ConsoleColor.DarkYellow,
                "6" => ConsoleColor.DarkGreen,
                "7" => ConsoleColor.DarkBlue,
                "8" => ConsoleColor.DarkRed,
                "o" => ConsoleColor.Black,
                "X" => ConsoleColor.DarkRed,
                _ => ConsoleColor.White,
            };
        }

        private static void PlaceCursor(Point currentLocation)
        {
            // place cursor in the middle of the cell
            Console.SetCursorPosition(
                currentLocation.X * CellWidth + CellWidth / 2,
                currentLocation.Y * CellHeight + CellHeight / 2
            );
        }

        private string GetDisplayCharacter(BoardLocation location)
        {
            if (location.IsRevealed)
            {
                return _displayCharacterMatrix[location.Y][location.X];
            }
            else
            {
                return location.IsFlagged ? "o" : " ";
            }
        }

        public void ResetConsoleColors()
        {
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
        }

        public void PrintMessage(string message)
        {
            ClearPreviousMessage();
            
            _messageLineCount = message.Split('\n').Length;
            
            BeginMessageOperations();
            Console.WriteLine(message);
        }

        private void ClearPreviousMessage()
        {
            if (_messageLineCount == 0) return;

            var prevX = Console.CursorLeft;
            var prevY = Console.CursorTop;
            BeginMessageOperations();

            for (var line = 0; line < _messageLineCount; line++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }

            Console.SetCursorPosition(prevX, prevY);

        }

        private void BeginMessageOperations()
        {
            Console.SetCursorPosition(0, (_board.Size + 1) * CellHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
