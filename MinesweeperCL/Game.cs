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
                keyPressHandler.Handle(Console.ReadKey(true).Key);
 
                // check if game over
            } while (IsOver == false);
        }
    }
}
