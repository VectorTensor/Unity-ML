using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.TestTools;

public class TensorTest
{
    private Tensor _p = new(new float[] { 1, 2, 4, 5 });
    // A Test behaves as an ordinary method
    [Test]
    public void TensorScalerMultiplication2d()
    {
        Tensor a = new(new float[,]{{1,2,4,5},{1,2,4,5}});
        Assert.AreEqual((new float[,] {{2, 4, 8, 10 },{2, 4, 8, 10 } }), (a*2).Arr);
    }

    [Test]
    public void TensorScalarMultiplication1D()
    {
        // Scalar multiplication for vector
        //Tensor a = new(new float[]{1,2,4,5});
        Assert.AreEqual((new float[,] {{2, 4, 8, 10 }}), (_p*2).Arr);
    }

    [Test]
    public void TensorInit()
    {
        // 1d vec initialization test
        Tensor a = new(new float[] { 1, 2, 2, 3 });
        Assert.AreEqual(new float[,]{{1,2,2,3}},a.Arr);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
}
