using Utils;
using Utils.Model;

namespace Neural_Networks
{
    public class LogisticRegression:Adaline
    {
        public LogisticRegression(float eta, int niter) : base(eta, niter)
        {
            
        }

        public LogisticRegression(AdalineModelDto data) : base(data)
        {
           
        }
        public new IModel Fit(Tensor X, Tensor y)
        {
            _weights = new Tensor(RandomGenerator.RandomFloatArray(X.Length[1]));
            _bias = 0;
            _losses = new float[_niter] ;

            for (int i = 0; i < _niter; i++)
            {
                Tensor net_input = NetInput(X);
                Tensor output = Activation(net_input);

                Tensor error = y - output; // Column matrix

                _weights += (_eta * 2.0f * X.T() * error *(1/ (float) X.Length[0])).T();

                //var gh = error.Mean(0);
                _bias += _eta * 2.0f * error.Mean(0)[0,0];

                _losses[i] = (error.Mean(0)[0, 0]);

            }

            return this;
        }

        new Tensor Activation(Tensor x)
        {

            return 1 / (1 + Tensor.Exp(-x));

        }
    }
}