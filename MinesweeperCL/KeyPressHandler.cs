using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

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
                    // toggle location flag
                    _board.Locations[_playerLocation.Y][_playerLocation.X].IsFlagged = !(_board.Locations[_playerLocation.Y][_playerLocation.X].IsFlagged);
                    break;
                case ConsoleKey.Z:
                    // reveal location
                    Reveal(_playerLocation.X, _playerLocation.Y);
                    break;
                default: break;
            }
        }

        private void Reveal(int x, int y)
        {
            _board.Locations[y][x].IsRevealed = true;
            if (_board.DisplayCharacters[y][x] == "-")
            {
                RevealNeighbors(x, y);
            }
        }

        private void RevealNeighbors(int x, int y)
        {
            //Thread.Sleep(50);

            int minXOffset = (x == 0) ? 0 : -1;
            int maxXOffset = (x == _board.Size - 1) ? 0 : 1;
            int minYOffset = (y == 0) ? 0 : -1;
            int maxYOffset = (y == _board.Size - 1) ? 0 : 1;

            // iterate over neighbors
            for (int i = minXOffset; i <= maxXOffset; i++)
            {
                for (int j = minYOffset; j <= maxYOffset; j++)
                {
                    // reveal neighbor if not already revealed
                    if (!_board.Locations[y + j][x + i].IsRevealed) Reveal(x + i, y + j);
                }
            }
        }
    }
}
