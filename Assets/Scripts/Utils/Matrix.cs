using UnityEngine;

namespace Scripts.Utils
{
    public class Matrix
    {
        /// <summary>
        /// Check if the vectors are of equal length
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static bool VectorOperationAllow(float[] x, float[] y)
        {
            
            if (x.Length != y.Length)
            {
                Debug.LogError("Sorry the two vectors are of different lengths");
                return false ;
            }

            return true;
        }
        public static float Dot(float[] x, float[] y)
        {

            if (!VectorOperationAllow(x, y))
            {
                return 0f;

            }
            float sum = 0;
            for (int i = 0; i < x.Length; i++)
            {

                sum += x[i] * y[i];

            }

            return sum;


        }

        public static float[] MulVectByNumber(float[] x , float a)
        {

            float[] vec = new float[x.Length];
            int index = 0;
            foreach (var x_i in x)
            {
                vec[index] = x_i * a;
                index++;
            }

            return vec;

        }

        public static float[] AddVectors(float[] x, float[] y)
        {
            if (!VectorOperationAllow(x, y))
            {
                return new float[0];
            }
            
            float[] sum = new float[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                sum[i] = x[i] + y[i];
            }

            return sum;
        }
    }
}