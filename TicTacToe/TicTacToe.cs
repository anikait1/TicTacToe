using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// This class models the functioning of the game.
    /// </summary>
    class TicTacToe
    {
        #region Class Methods

        #region Play Method
        /// <summary>
        /// This method simulates the game. It initializes two player objects with their respective signs. A while loop
        /// continues to run, until a player has won the game or the game has been drawn.
        /// </summary>
        public static void Play()
        {
            // initialize the two players and give the first turn to playerX
            Player playerX = new Player(Field.X);
            Player playerO = new Player(Field.O);
            Player currentPlayer = playerX;

            int moveCounter = 0; // store the count of total number of moves so far

            while (true)
            {
                // indicate the turn of current player
                GameBoard.PrintBoard();
                Console.WriteLine($"Player: {currentPlayer.Sign}. Enter the field where you want to put your character");

                // mark the board with the user's input
                GameBoard.MarkBoard(currentPlayer, currentPlayer.Turn());
                moveCounter += 1;

                // check for the result and if the game is still in motion change the current player
                if (CheckForWin())
                {
                    GameBoard.PrintBoard();
                    Console.WriteLine($"Player: {currentPlayer.Sign} won!");
                    break;
                }
                else if (CheckDraw(moveCounter))
                {
                    GameBoard.PrintBoard();
                    Console.WriteLine("Draw");
                    break;
                }
                ChangeCurrentPlayer(ref currentPlayer, playerX, playerO);
            }
        }
        #endregion

        #region ChangeCurrentPlayer Method
        /// <summary>
        /// Rotates the turn between the two players 
        /// </summary>
        /// <param name="currentPlayer">The reference to which the player will be assigned.</param>
        /// <param name="playerX">The player who has Field.X associated with it.</param>
        /// <param name="playerO">The player who has Field.O associated with it.</param>
        private static void ChangeCurrentPlayer(ref Player currentPlayer, Player playerX, Player playerO)
        {
            if (currentPlayer == playerX)
            {
                currentPlayer = playerO;
            }
            else
            {
                currentPlayer = playerX;
            }
        }
        #endregion

        #region CheckDraw Method
        /// <summary>
        /// Checks whether more moves can be made or not, if maximum limit is reached, returns true to indicate a draw has
        /// occured. Maximum limit is set to 9.
        /// </summary>
        /// <param name="counter">The current number of moves</param>
        /// <returns>True if a draw has occured, otherwise a false</returns>
        private static bool CheckDraw(int counter)
        {
            if (counter == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CheckRowCol Method
        /// <summary>
        /// Helper method to check if three given fields on the board are equal. Empty fields are not considered equal,
        /// since this method is used to check if a player has won the game or not.
        /// </summary>
        /// <param name="cellOne">First Field</param>
        /// <param name="cellTwo">Second Field</param>
        /// <param name="cellThree">Third Field</param>
        /// <returns>True, if the given fields are equal, otherwise false.</returns>
        private static bool CheckRowCol(Field cellOne, Field cellTwo, Field cellThree)
        {
            return (cellOne != Field.Empty)
                && (cellOne == cellTwo)
                && (cellOne == cellThree);
        }
        #endregion

        #region CheckRowsForWin Method
        /// <summary>
        /// Loop through all the the possible rows, to check if all the fields in the row are equal(uses CheckRowCol 
        /// method to do this).
        /// </summary>
        /// <returns>True, if any three rows are equal, otherwise false.</returns>
        private static bool CheckRowsForWin()
        {
            for (int i = 0; i < GameBoard.SIZE; ++i)
            {
                if (CheckRowCol(
                    GameBoard.Board[i, 0].State,
                    GameBoard.Board[i, 1].State,
                    GameBoard.Board[i, 2].State)
                    )
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region CheckColsForWin Method
        /// <summary>
        /// Loop through all the the possible columns, to check if any three are equal(uses CheckRowCol method to do this).
        /// </summary>
        /// <returns>True, if any three columns are equal, otherwise false.</returns>
        private static bool CheckColsForWin()
        {
            for (int i = 0; i < GameBoard.SIZE; ++i)
            {
                if (CheckRowCol(
                    GameBoard.Board[0, i].State,
                    GameBoard.Board[1, i].State,
                    GameBoard.Board[2, i].State)
                    )
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region CheckDiagonalsForWin Method
        /// <summary>
        /// Checks the two diagonals of the gameboard to see if any three fields in the diagonal are equal(uses 
        /// CheckRowCol method to do this).
        /// </summary>
        /// <returns></returns>
        private static bool CheckDiagonalsForWin()
        {
            if (CheckRowCol(
                GameBoard.Board[0, 0].State,
                GameBoard.Board[1, 1].State,
                GameBoard.Board[2, 2].State)
                || CheckRowCol(GameBoard.Board[0, 2].State,
                GameBoard.Board[1, 1].State,
                GameBoard.Board[2, 0].State)
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region CheckForWin Method
        /// <summary>
        /// This method uses other helper methods (CheckRowsForWin, CheckColsForWin, CheckDiagonalsForWin) to find out
        /// if a user has won the game on the basis of result from any of the three methods.
        /// </summary>
        /// <returns>True, if a user has won the game, otherwise false</returns>
        private static bool CheckForWin()
        {
            return (CheckRowsForWin()
                || CheckColsForWin()
                || CheckDiagonalsForWin());
        }
        #endregion

        #endregion
    }
}
