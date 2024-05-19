using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;
using Utils;
using Utils.Model;

namespace Neural_Networks
{
    public class Adaline
    {
        private Tensor _weights;
        private float _bias;

        private float[] _losses;
        private float _eta;
        private int _niter;

        public Adaline(float eta, int niter)
        {

            _eta = eta;
            _niter = niter;
            
        }

        public Adaline(AdalineModelDto data)
        {
            _weights = data._weights.GetTensor();
            _bias = data._bias;
            _eta = data._eta;
            _niter = data._niter;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="y"> y must be column matrix </param>
        public Adaline Fit(Tensor X, Tensor y)
        {
            _weights = new Tensor(RandomGenerator.RandomFloatArray(X.Length[1]));
            _bias = 0;
            _losses = new float[] { };

            for (int i = 0; i < _niter; i++)
            {
                Tensor net_input = NetInput(X);
                Tensor output = Activation(net_input);

                Tensor error = y - output; // Column matrix

                _weights += (_eta * 2.0f * X.T() * error *(1/ (float) X.Length[0])).T();

                var gh = error.Mean(0);
                _bias += _eta * 2.0f * error.Mean(0)[0,0];

                _losses.Append(error.Mean(0)[0, 0]);

            }

            return this;
        }

        public Tensor NetInput(Tensor x)
        {

            return x * _weights.T() + _bias;

        }

        public Tensor Activation(Tensor x)
        {
            return x;
        }

        public Tensor Predict(Tensor x)
        {
            
            Tensor net_input = NetInput(x);
            Tensor output = Activation(net_input);
            return output;


        }

        public void SaveModel(string loc)
        {
            AdalineModelDto modelTrain= new();
            modelTrain._weights = SerializableTensor.BuildFromTensor(_weights);
            modelTrain._bias = _bias;
            modelTrain._eta = _eta;
            modelTrain._niter = _niter;
            
            
            string s;
            s = JsonUtility.ToJson(modelTrain);
            File.WriteAllText(loc, s);
        }
        

        
    }
}