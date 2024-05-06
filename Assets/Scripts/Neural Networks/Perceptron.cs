using System.Linq;
using Utils;

namespace Neural_Networks
{
    public class Perceptron
    {
        
        private float[][] _features;
        private int[] _target;
        private float[] _weights;
        private float _bias;
        private float _eta;
        private int _iter;
        private float[] _errors;

        public Perceptron(float eta ,int iter)
        {
            _eta = eta;
            _iter = iter;

        }

        public Perceptron Fit(float[][] x, int[] y)
        {
            _features = x;
            _target = y;
            
            //1. First we need to randomly initialize weights and bias
            // 2. Then take the first data xw+b = y
            // 3. Calc the error MSE with y cap i.e the real value
            // 4. Use gradient descent to calc new weights

            _weights = RandomGenerator.RandomFloatArray(_features.Length);
            _bias = 0;
            this._errors = new float[this._iter];

            for (int i = 0; i < this._iter; i++)
            {
                float error = 0;
                for (int j = 0; j < _target.Length; j++)
                {
                    float e = _target[j] - Predict(_features[j]);
                    float update = _eta * (e);
                    _weights = Matrix.AddVectors(_weights, Matrix.MulVectByNumber(_features[j], update));
                    _bias += update;
                    error += e;

                }

                this._errors.Append(error);
            }

            return this;

        }

        private float NetInput(float[] x)
        {
            
            // Perform matrix multiplication
            // x*features + bias
            return Matrix.Dot(x, _weights) + _bias;

        }

        public int Predict(float[] x)
        {

            if (NetInput(x) > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        } 
        
        
    }
}