using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// This class models a player in the game.
    /// </summary>
    public class Player
    {
        #region Class Members
        /// <summary>
        /// Holds the value of the sign player has chosen, can be Field.X or Field.O.
        /// </summary>
        public Field Sign { get; private set; }
        #endregion

        #region Class Constructors
        /// <summary>
        /// Constructs the Player object and throws an error in case an invalid parameter is given.
        /// </summary>
        /// <param name="sign">The sign player chooses, can either be Field.X or Field.O.</param>
        public Player(Field sign)
        {
            if (sign != Field.X && sign != Field.O)
            {
                throw new System.ArgumentException("Parameter can only be Field.X or Field.O");
            }
            else
            {
                Sign = sign;
            }
        }
        #endregion

        #region Class Methods

        #region Turn Method
        /// <summary>
        /// Simulates a player's turn, giving the player the ability to choose which field on the gameboard needs to be
        /// marked. It ensures a valid field number is selected by the player, in case the field number is invalid,
        /// prompts the user to choose a valid field by displaying a message on the console window and calling itself again.
        /// </summary>
        /// <returns>The field number which the player wishes to mark.</returns>
        public int Turn()
        {
            // try to parse the user's input
            if (int.TryParse(Console.ReadLine(), out int fieldNumber))
            {
                // a valid field number is betwee 1 <= fieldNumber <= 9
                if (fieldNumber <= 0 || fieldNumber > 9)
                {
                    Console.WriteLine("Oops! Field Numbers can only be between 1-9. Enter again");
                    return Turn();
                }

                return fieldNumber;
            }
            // in case of an error(that is user did not entered a number), calls the function again
            else
            {
                Console.WriteLine("Oops! Field Numbers can only be between 1-9. Enter again");
                return Turn();
            }
        }
        #endregion

        #endregion
    }
}
