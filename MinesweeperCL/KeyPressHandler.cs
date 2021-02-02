using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using MinesweeperCL.Models;

namespace MinesweeperCL
{
    public class KeyPressHandler
    {
        private readonly Board _board;
        private readonly Point _playerLocation;

        public KeyPressHandler(Board board, Point playerLocation)
        {
            _board = board;
            _playerLocation = playerLocation;
        }

        // handles keypresses and translates into appropriate model manipulations
        // returns the result of the move
        public MoveResult Handle(ConsoleKey pressed)
        {
            switch (pressed)
            {
                case ConsoleKey.LeftArrow:
                    if (_playerLocation.X > 0) _playerLocation.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (_playerLocation.X < _board.Size - 1) _playerLocation.X++;
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
                    _board.Reveal(_playerLocation.X, _playerLocation.Y);
                    if (_board.MineHit) return MoveResult.Lost;
                    break;
                default:
                    break;
            }

            // game is won when all mines are marked
            var mines = _board.Locations.SelectMany(row => row).Where(l => l.IsMine).ToList();
            var allMinesMarked = mines.TrueForAll(m => m.IsFlagged);

            return (allMinesMarked) ? MoveResult.Won : MoveResult.StillPlaying;
        }
    }
}
