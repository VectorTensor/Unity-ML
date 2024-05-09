using System;
using UnityEngine;

namespace Utils
{
    public class Vector
    {
        public float[] Arr;
        public int Length;

        public Vector(float[] a)
        {
            Arr = a;
            Length = a.Length;
        }
        
        
        private static bool VectorOperationAllow(float[] x, float[] y)
        {
            
            if (x.Length != y.Length)
            {
                Debug.LogError("Sorry the two vectors are of different lengths");
                return false ;
            }

            return true;
        }
        


        public float this[int index]
        {
            get
            {
                if (index >= 0 && index < Arr.Length)
                {
                    return Arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set
            {
                if (index >= 0 && index < Arr.Length)
                {
                    Arr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public static Vector operator +(Vector a, Vector b) =>  new Vector(AddVectors(a.Arr, b.Arr));
        
        public static float operator *(Vector a, Vector b) => Dot(a.Arr, b.Arr);
        
        public static Vector operator - (Vector a, Vector b) => new Vector(SubVectors(a.Arr, b.Arr));
        
        public static Vector operator * (Vector a, float b) => new Vector(MulVectByNumber(a.Arr, b));
        
        static float[] ConvertToFloat(int[] intVector)
        {
            int length = intVector.Length;

            float[] floatVector = new float[length];

            for (int i = 0; i < length; i++)
            {
                floatVector[i] = (float)intVector[i];
            }

            return floatVector;
        }
        public static float[] SubVectors(float[] x, float[] y)
        {
            if (!VectorOperationAllow(x, y))
            {
                return new float[0];
            }
            
            float[] sum = new float[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                sum[i] = x[i] - y[i];
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