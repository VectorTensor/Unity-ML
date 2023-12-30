namespace Scripts.Regression 
{
    
    public class LinearRegression
    {
        private float[][] _features;
        private float[] _target;
        private float[] _weight;
        private float _bias;

        public LinearRegression()
        {
            
        }

        public void Fit(float[][] x, float[] y)
        {
            _features = x;
            _target = y;
            
            // 1. First we need to randomly initialize weights and bias
            // 2. Then take the first data xw+b = y
            // 3. Calc the error MSE with y cap i.e the real value
            // 4. Use gradient descent to calc new weights




        }
    }
    
}
