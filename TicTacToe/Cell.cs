namespace TicTacToe
{
    /// <summary>
    /// This class models an indiviual cell on the gameboard.
    /// </summary>
    public class Cell
    {
        #region Class Properties
        /// <summary>
        /// Represents the state of the cell on the gameboard
        /// </summary>
        public Field State { get; set; } = Field.Empty;
        #endregion
    }
}
