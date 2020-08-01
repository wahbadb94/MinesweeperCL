using MinesweeperCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinesweeperCL
{
    public class Game
    {
        private readonly Board _board;
        public bool IsOver { get; private set; } = false;

        public Game(Board board)
        {
            _board = board;
        }

        public void Run()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            // player starts at origin
            Point playerLocation = new Point(0, 0);
            
            // give keypress handler access to playerLocation and board Models 
            KeyPressHandler keyPressHandler = new KeyPressHandler(_board, playerLocation);

            // create and init view
            BoardView view = new BoardView(_board);

            do
            {
                // display board
                view.Display(_board, playerLocation);

                // handles keypress and manipulates model data
                // returns true as long as mine hasn't been hit
                IsOver = !keyPressHandler.Handle(Console.ReadKey(true).Key);
 
            } while (IsOver == false);
        }
    }
}
