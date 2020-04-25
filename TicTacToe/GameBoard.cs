using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// This class models the gameboard for the game.
    /// </summary>
    public class GameBoard
    {
        #region Class Members
        /// <summary>
        /// Represents the size of the board.
        /// </summary>
        public const int SIZE = 3;
        
        /// <summary>
        /// A 3x3 Array which represents the board. Each element in the Array is an object of class Cell.
        /// </summary>
        public static Cell[,] Board { get; private set; } = new Cell[SIZE, SIZE]
        {
            { new Cell(), new Cell(), new Cell() },
            { new Cell(), new Cell(), new Cell() },
            { new Cell(), new Cell(), new Cell() },
        };
        #endregion

        #region Class Methods

        #region PrintBoard Method
        /// <summary>
        /// Prints the gameboard to the console.
        /// </summary>
        public static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine($"   {(char)Board[0, 0].State}  |  {(char)Board[0, 1].State}  |  {(char)Board[0, 2].State}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"   {(char)Board[1, 0].State}  |  {(char)Board[1, 1].State}  |  {(char)Board[1, 2].State}   ");
            Console.WriteLine("-------------------");
            Console.WriteLine($"   {(char)Board[2, 0].State}  |  {(char)Board[2, 1].State}  |  {(char)Board[2, 2].State}   ");

        }
        #endregion

        #region MarkBoard Method
        /// <summary>
        /// Marks the board with the given player's sign, it also ensures only an empty field on the board is marked.
        /// A given field number is broken down into x and y coordinates to mark it on the board(a multi-dimensional Array).
        /// No check is made whether the given field number is valid or not. It is the caller's responsibility to ensure
        /// a valid number is passed.
        /// </summary>
        /// <param name="player">The sign associated with the player object is used to mark the board.</param>
        /// <param name="fieldNumber">The cell on the board which needs to be marked.</param>
        public static void MarkBoard(Player player, int fieldNumber)
        {
            int x = (fieldNumber - 1) / 3;
            int y = (fieldNumber - 1) % 3;

            if (Board[x, y].State == Field.Empty)
            {
                Board[x, y].State = player.Sign;
            }
            else
            {
                Console.WriteLine("This place is taken. Select some other field");
                MarkBoard(player, player.Turn());
            }
        }
        #endregion

        #endregion
    }
}