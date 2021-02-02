using System;
using MinesweeperCL.Models;
using MinesweeperCL.Views;

namespace MinesweeperCL
{
    public class Game
    {
        private readonly KeyPressHandler _keyPressHandler;
        private readonly Point _playerLocation;
        private readonly BoardView _boardView;
        private MoveResult _previousMoveResult;

        public Game(Board board)
        {
            _playerLocation = new Point(0, 0);  // player starts at origin
            _keyPressHandler = new KeyPressHandler(board, _playerLocation);
            _boardView = new BoardView(board);
        }

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            do
            {
                // print rules
                _boardView.PrintMessage("Navigation: arrow keys\n" +
                                        "Select:     'Z' key\n" +
                                        "Mark:       'X' key");

                // display board
                _boardView.Display(_playerLocation);

                // handles keypress and manipulates model data
                // returns result of last move
                _previousMoveResult = _keyPressHandler.Handle(Console.ReadKey(true).Key);
 
            } while (_previousMoveResult == MoveResult.StillPlaying);

            _boardView.Display(_playerLocation);
        }

        public bool AskPlayAgain()
        {
            var message = (_previousMoveResult == MoveResult.Won)
                ? "Congratulations! You Won! :)"
                : "Sorry, you lost... :(";

            _boardView.PrintMessage(message + "\nDo You want to play again? (Y/n): ");

            var playAgain = Console.ReadLine()?.ToUpper() == "Y";
            
            _boardView.ResetConsoleColors();

            return playAgain;
        }
    }
}
