using System;
using System.Runtime.CompilerServices;
using Codice.CM.Client.Gui;
using UnityEngine.Serialization;

namespace Utils.Model
{
    [Serializable]
    public class SerializableTensor
    {
        public float[] arr;
        public int[] length;

        private SerializableTensor(Tensor tensor)
        {

            arr = ConvertTo1D(tensor.Arr, tensor.Length);

            length = tensor.Length;



            
        }

        float[] ConvertTo1D(float[,] arr, int[] l)
        {
            int r = l[0];
            int c = l[1];

            int t = r * c;

            float[] a = new float[t];

            int i = 0;
            foreach (var e in arr)
            {
                a[i] = e;
                i++;

            }

            return a;

        }

        public float[,] ConvertTo2D(float[] arr, int[] l)
        {
            int r = l[0];
            int c = l[1];

            float[,] a = new float[r,c];
            int i = 0, j = 0;
            for (int p = 0; p < arr.Length; p++)
            {
                a[i, j] = arr[p];
                j++;
                if (j >= c )
                {
                    j = 0;
                    i++;
                }
            }

            return a;
        }

        public Tensor GetTensor()
        {

            return new Tensor(ConvertTo2D(arr, length));

        }
        
        

        public static SerializableTensor BuildFromTensor(Tensor t)
        {

            return new SerializableTensor(t);

        }


    }
}