using System;

namespace Utils
{
    public class RandomGenerator
    {

        public static float[] RandomFloatArray(int size )
        {

            float[] randomArray = new float[size];
            Random random = new Random();
            double min = -0.1;
            double max = 0.1;
            double range = max-min;
            for (int i = 0; i < randomArray.Length; i++)
            {
                double sample = random.NextDouble();
                double scaled = (sample * range) + min;
                randomArray[i] = (float) scaled ; 
                
            }

            return randomArray;

        }
        
    }
}