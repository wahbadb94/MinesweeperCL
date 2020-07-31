using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public class KeyPressHandler
    {
        private Board _board;
        private Point _playerLocation;

        public KeyPressHandler(Board board, Point playerLocation)
        {
            _board = board;
            _playerLocation = playerLocation;
        }

        public void Handle(ConsoleKey pressed)
        {
            switch (pressed)
            {
                case ConsoleKey.LeftArrow:
                    if (_playerLocation.X > 0) _playerLocation.X--; 
                    break;
                case ConsoleKey.RightArrow:
                    if (_playerLocation.X < _board.Size-1) _playerLocation.X++;
                    break;
                case ConsoleKey.UpArrow:
                    if (_playerLocation.Y > 0) _playerLocation.Y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (_playerLocation.Y < _board.Size - 1) _playerLocation.Y++;
                    break;
                case ConsoleKey.X:
                    // mark board
                    break;
                case ConsoleKey.Z:
                    // reveal location
                default: break;
            }
        }
    }
}
