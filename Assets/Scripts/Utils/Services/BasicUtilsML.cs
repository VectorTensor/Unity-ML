using System.Linq;

namespace Utils.Services
{
    public class BasicUtilsML
    {
        
        public static float[] GetRow(float[,] array, int rowIndex)
        {
            // Get the number of columns in the array
            int cols = array.GetLength(1);

            // Create a new array to hold the row
            float[] row = new float[cols];

            // Copy the elements from the specified row into the new array
            for (int i = 0; i < cols; i++)
            {
                row[i] = array[rowIndex, i];
            }

            return row;
        }

        public static int[] ConvertToInt(float[] x)
        {
            return x.Select(f => (int)f).ToArray();
        }
        
    }
}