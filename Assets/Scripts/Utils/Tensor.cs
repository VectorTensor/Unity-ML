using System;
using System.IO;
using System.Linq;

namespace Utils
{
    [Serializable]
    public class Tensor
    {


        public float[,] Arr;
        public int[]  Length;

        public Tensor(float[,] a)
        {
            Arr = a;

            Length = new int[2] { a.GetLength(0), a.GetLength(1) };

        }

        public Tensor(float[] a)
        {
            float[,] array2D = new float[1, a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                array2D[0, i] = a[i];
            }

            Arr = array2D;
            Length = new int[2] { array2D.GetLength(0), array2D.GetLength(1) };
        }

        public static Tensor operator *(Tensor a, Tensor b) => new Tensor(MultiplyMatrices(a.Arr, b.Arr));
        public static Tensor operator *(Tensor a, float b) => new Tensor(MultiplyMatrixByScalar(a.Arr, b));
        public static Tensor operator *( float b,Tensor a) => new Tensor(MultiplyMatrixByScalar(a.Arr, b));
        public static Tensor operator +(Tensor a, Tensor b) => new Tensor(AddMatrices(a.Arr, b.Arr));
        public static Tensor operator -(Tensor a, Tensor b) => new Tensor(SubMatrices(a.Arr, b.Arr));
        public static Tensor operator +(Tensor a, float b) => new Tensor(AddTensorByNumber(a.Arr, b));
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
        
        public static float[,] AddTensorByNumber(float [,] intMatrix, float n)
        {
            int rows = intMatrix.GetLength(0);
            int cols = intMatrix.GetLength(1);

            float[,] floatMatrix = new float[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    floatMatrix[i, j] = intMatrix[i, j] + n;
                }
            }

            return floatMatrix;
        }
        
        
        
        
        public float this[int i , int j]
        {
            get
            {
                if (i >= 0 &&  i < Arr.GetLength(0) && j >= 0 &&  j < Arr.GetLength(1))
                {
                    return Arr[i,j];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set
            {
                if (i >= 0 &&  i < Arr.Length && j >= 0 &&  j < Arr.Length)
                {
                    Arr[i,j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }
        
        public Vector this[int i ]
        {
            get
            {
                if (i >= 0 && i < Arr.GetLength(0))
                {
                    float[] result = new float[Arr.GetLength(1)];
                    for (int j = 0; j < Arr.GetLength(1); j++)
                    {
                        result[j] = Arr[i, j];
                    }

                    return new Vector(result);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

            }
        }
        
        
        public Vector this[ char x, int i]
        {
            get
            {
                if (i >= 0 && i < Arr.GetLength(1))
                {
                    float[] result = new float[Arr.GetLength(0)];
                    for (int j = 0; j < Arr.GetLength(0); j++)
                    {
                        result[j] = Arr[j, i];
                    }

                    return new Vector(result);
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

            }
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

        // public Tensor Mean(int axis)
        // {
        //
        //     int rows = Length[axis];
        //     int cols = Length[(axis+1)%2];
        //
        //     float[] means = new float[] { };
        //
        //     for (int i = 0; i < cols; i++)
        //     {
        //
        //         float sum = 0 ;
        //         for (int j = 0; j < rows ; j++)
        //         {
        //
        //             sum += Arr[j, i];
        //
        //
        //         }
        //
        //         means.Append(sum / rows);
        //     }
        //
        //     return new Tensor(means);
        //
        //
        // }
        
        public Tensor Mean(int axis)
        {

            int first = Length[axis];
            int second = Length[(axis+1)%2];

            float[] means = new float[second];

            for (int i = 0; i < second; i++)
            {
                float sum = 0 ;
                for (int j = 0; j < first ; j++)
                {

                    if (axis == 0)
                    {
                        
                        sum += Arr[j, i];
                    }
                    else
                    {
                        sum += Arr[i, j];
                    }
                

                }

                means[i] = sum;


            }

            return new Tensor(means);


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

        /// <summary>
        /// This function takes a condition and for every element of the tensor that statisfies the condition it returns a otherwise b
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Tensor Where(Func<float, bool> condition, float a, float b)
        {

            float[,] data = new float[Arr.GetLength(0),Arr.GetLength(1)];
            for (int i = 0; i < Arr.GetLength(0); i++)
            {

                for (int j = 0; j < Arr.GetLength(1); j++)
                {

                    data[i,j] = condition(Arr[i,j]) ? a : b;

                }
                
            }

            return new Tensor(data);

        }
        
        /// <summary>
        /// Overload for the where function where in one of the condition we just the leave the value as it is if default condition = true, we get the same value for true 
        /// and default condition = false we get the same value for false condition
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="a"></param>
        /// <param name="defaultCondtion"></param>
        /// <returns></returns>
        public Tensor Where(Func<float, bool> condition, float a, bool defaultCondtion = false)
        {

            float[,] data = new float[Arr.GetLength(0),Arr.GetLength(1)];
            for (int i = 0; i < Arr.GetLength(0); i++)
            {

                for (int j = 0; j < Arr.GetLength(1); j++)
                {

                    if (!defaultCondtion)
                    {
                        
                        data[i,j] = condition(Arr[i,j]) ? a : Arr[i,j];
                    }
                    else
                    {
                        
                        data[i,j] = condition(Arr[i,j]) ? Arr[i,j]:a;
                    }

                }
                
            }

            return new Tensor(data);

        }
        public static Tensor exp(Tensor t)
        {

            float[,] arr = t.Arr;
            float[,] expo = new float[arr.GetLength(0),arr.GetLength(1)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {

                for (int j = 0; j < arr.GetLength(1); j++)
                {

                    expo[i,j] = MathF.Exp(arr[i, j]);


                }
                
            }

            return new Tensor(arr);

        }

        
    }
    
}