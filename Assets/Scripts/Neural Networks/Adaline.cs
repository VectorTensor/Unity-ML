using System.Linq;
using Scripts.Utils;

namespace Scripts.Neural_Networks
{
    public class Adaline
    {
        
        private float[][] _features;
        private float[] _target;
        private float[] _weights;
        private float _bias;
        private float _eta;
        private int _iter;
        private float[] _errors;

        public Adaline(float eta ,int iter)
        {
            _eta = eta;
            _iter = iter;

        }

        public Adaline Fit(float[][] x, int[] y)
        {
            _features = x;
            _target = y.Select(d => (float)d).ToArray();
            
            //1. First we need to randomly initialize weights and bias
            // 2. Then take the first data xw+b = y
            // 3. Calc the error MSE with y cap i.e the real value
            // 4. Use gradient descent to calc new weights

            _weights = RandomGenerator.RandomFloatArray(_features.Length);
            _bias = 0;
            this._errors = new float[this._iter];

            for (int i = 0; i < this._iter; i++)
            {
                for (int j = 0; j < _target.Length; j++)
                {
                    // float e = _target[j] - Predict(_features[j]);
                    // float update = _eta * (e);
                    // _weights = Matrix.AddVectors(_weights, Matrix.MulVectByNumber(_features[j], update));
                    // _bias += update;
                    // error += e;
                    
                    
                
                    //error = _target[]

                }

                float[] y_pred = NetInput(_features);
                
                float[] error = Matrix.SubVectors(_target, y_pred);

                float sum = 0;
                float index = 0;
             // foreach (var e in error)
             //    {
             //
             //        sum += e*_features[][];
             //        index++;
             //    }
             //
             //    _weights = _features[][].Select(d => d * sum * (2 / _target.Length));



            }

            return this;

        }

        private float[] NetInput(float[][] x)
        {
            
            // Perform matrix multiplication
            // x*features + bias
            float[] res = new float[x[0].Length];

            for(int i = 0 ; i<x[0].Length;i++)
            {

                res.Append(Matrix.Dot(x[i], _weights) + _bias);

            }

            return res;
        }

        private float[] Activation(float[] x)
        {
            return x;
        }

        public int Predict(float[] x)
        {

            // if (NetInput(x) > 0)
            // {
            //     return 1;
            // }
            // else
            // {
            //     return 0;
            // }
            return 0;

        } 
        
        
    }
}