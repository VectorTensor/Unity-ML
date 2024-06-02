using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor.VersionControl;
using Utils;

namespace Test.Tests_1
{
    [TestFixture]
    public class TensorMaths
    {

        private Tensor a;

        [SetUp]
        public void SetUpTensor()
        {

            a = new Tensor(new[] { -1, 2, 0, 1f });
            

        }

        [Test]
        public void TestExp()
        {

            var x  = Tensor.Exp(a);
            Tensor act = new Tensor(new[] { 0.36787944f, 7.3890561f, 1f, 2.71828183f });
            CollectionAssert.AreEqual(act.Arr, x.Arr,new FloatComparer(0.001f));


        }
        
    }
    public class FloatComparer : IComparer
    {
        private readonly float _tolerance;

        public FloatComparer(float tolerance)
        {
            _tolerance = tolerance;
        }

        public int Compare(object x, object y)
        {
            if (x is float fx && y is float fy)
            {
                return Math.Abs(fx - fy) <= _tolerance ? 0 : 1;
            }
            throw new ArgumentException("Objects are not floats");
        }
    }
}