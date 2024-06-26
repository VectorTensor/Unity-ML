using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utils;

public class TensorTest
{
    private Tensor _p ;
    private Tensor _a;

    [SetUp]
    public void Setup()
    {
        _p = new(new float[] { 1, 2, 4, 5 });
        
        _a = new Tensor(new float[,]{{1,2,4,5},{1,2,4,5}});
    }
    // A Test behaves as an ordinary method
    [Test]
    public void TensorScalerMultiplication2d()
    {
        // Tensor a = new(new float[,]{{1,2,4,5},{1,2,4,5}});
        Assert.AreEqual((new float[,] {{2, 4, 8, 10 },{2, 4, 8, 10 } }), (_a*2).Arr);
    }

    [Test]
    public void TensorScalarMultiplication1D()
    {
        // Scalar multiplication for vector
        Assert.AreEqual((new float[,] {{2, 4, 8, 10 }}), (_p*2).Arr);
    }

    [Test]
    public void TensorInit()
    {
        // 1d vec initialization test
        Assert.AreEqual(new float[,]{{1,2,4,5}},_p.Arr);
    }

    [Test]
    public void WhereFunctionTensor()
    {

        Tensor a = _a.Where((d) => d >4, 10,1);
        Assert.AreEqual(new float[,]{{1,1,1,10},{1,1,1,10}},a.Arr);
        
        Tensor b = _a.Where((d) => d >4, 10);
        Assert.AreEqual(new float[,]{{1,2,4,10},{1,2,4,10}},b.Arr);

        Tensor c = _a.Where((d) => d >4, 10,true);
        Assert.AreEqual(new float[,]{{10,10,10,5},{10,10,10,5}},c.Arr);
    }

}
