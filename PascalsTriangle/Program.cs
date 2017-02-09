using System;

namespace PascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  I have not implemented the UI input into the function, 
                as i do not think that is the gist of the task,
                but invoking the function would follow something like this */

            //TODO: Get inputs and convert to integers if necessary, as opposed to hardcoding
            int inRow = 2,
                inColumn = 4;

            string retMessage = string.Empty;

            if (ValidateInputs(inRow, inColumn, ref retMessage))
                retMessage = string.Format("The pascal value at row {0} and column {1} is {2} ", inRow.ToString(), inColumn.ToString(), GetPascalValue(inRow, inColumn).ToString());

            //TODO: Implement output messaging
            Console.WriteLine(retMessage);
            Console.Read();
        }

        /// <summary>
        /// Validates inputs and returns messaging specifically for a console-style implementation
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="errorMessage"></param>
        /// <returns>bool</returns>
        public static bool ValidateInputs(int row, int column, ref string errorMessage)
        {
            if (IsPositive(row) && IsPositive(column))
            {
                if (IsValidRange(row, column))
                    return true;

                errorMessage = string.Format("The column value ({0}) cannot be greater than the row value ({1})", column.ToString(), row.ToString());
            }
            else
            {
                errorMessage = "Negative values are not permitted";
            }
            
            return false;
        }

        public static bool IsPositive(int value)
        {
            if (value < 0)
                return false;

            return true;
        }

        public static bool IsValidRange(int row, int column)
        {
            if (column > row)
                return false;

            return true;
        }

        public static int GetPascalValue(int row, int column)
        {
            if (column == 0 || column == row)
                return 1;

            return GetPascalValue(row - 1, column - 1) + GetPascalValue(row - 1, column);
        }
    }
}
