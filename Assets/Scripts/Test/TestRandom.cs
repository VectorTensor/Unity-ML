using UnityEngine;
using Utils;

namespace Test
{
    public class TestRandom : MonoBehaviour
    {
        private void Start()
        {
            int [,] x = { {1, 2 },{1,4}};
            float[,] z = { {-3, 2},{-2,1} };

            Tensor t1 = new Tensor(Tensor.ConvertToFloat(x));
            
            Tensor t2 = new Tensor(z);

            Tensor y = t1 + t2;


            Vector v = t2[0];





        }
    }
}