using Utils;

namespace Neural_Networks
{
    public interface IModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="y"> y must be column matrix </param>
        IModel Fit(Tensor X, Tensor y);

        Tensor NetInput(Tensor x);
        Tensor Activation(Tensor x);
        Tensor Predict(Tensor x);
        void SaveModel(string loc);
    }
}