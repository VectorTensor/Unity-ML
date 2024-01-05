using System;

namespace Scripts.Utils
{
    public class Tensor
    {


        public float[,] Arr;

        public Tensor(float[,] a)
        {
            Arr = a;
        }

        public static Tensor operator *(Tensor a, Tensor b) => new Tensor(MultiplyMatrices(a.Arr, b.Arr));
        public static Tensor operator *(Tensor a, float b) => new Tensor(MultiplyMatrixByScalar(a.Arr, b));
        public static Tensor operator +(Tensor a, Tensor b) => new Tensor(AddMatrices(a.Arr, b.Arr));
        public static Tensor operator -(Tensor a, Tensor b) => new Tensor(SubMatrices(a.Arr, b.Arr));
        public Tensor T() => new Tensor(Transpose(Arr));
            
            
        public static float[,] ConvertToFloat(int[,] intMatrix)
        {
            int rows = intMatrix.GetLength(0);
            int cols = intMatrix.GetLength(1);

            float[,] floatMatrix = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    floatMatrix[i, j] = (float)intMatrix[i, j];
                }
            }

            return floatMatrix;
        }
        float[,] Transpose(float[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            float[,] transposeMatrix = new float[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposeMatrix[j, i] = matrix[i, j];
                }
            }

            return transposeMatrix;
        }
        
        
        static float[,] MultiplyMatrixByScalar(float[,] matrix, float scalar)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            float[,] result = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }
        
        
        
        static float[,] MultiplyMatrices(float[,] matrixA, float[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB)
            {
                throw new ArgumentException("Invalid matrix dimensions for multiplication");
            }

            float[,] result = new float[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }
        static float[,] AddMatrices(float[,] matrixA, float[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            if (rows != matrixB.GetLength(0) || cols != matrixB.GetLength(1))
            {
                throw new ArgumentException("Matrices must have the same dimensions for addition");
            }

            float[,] result = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return result;
        }
        static float[,] SubMatrices(float[,] matrixA, float[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            if (rows != matrixB.GetLength(0) || cols != matrixB.GetLength(1))
            {
                throw new ArgumentException("Matrices must have the same dimensions for addition");
            }

            float[,] result = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }

            return result;
        }

        
    }
}