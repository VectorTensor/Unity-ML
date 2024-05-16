using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utils;
using Utils.Model;

public class SerializableTensorTest
{
    private SerializableTensor s;
    [SetUp]
    public void SetUpData()
    {
        s = SerializableTensor.BuildFromTensor(new Tensor(new[,] { { 1f, 2f }, { 3, 4 },{2,1} }));

    }
    // A Test behaves as an ordinary method
    [Test]
    public void SerializableTensorTestSimplePasses()
    {

        var y = s.arr;
        Assert.AreEqual(new float[]{1f,2f,3,4,2,1},y);
        // Use the Assert class to test conditions
    }

   
  
}
