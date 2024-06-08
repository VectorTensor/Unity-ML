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
        private Tensor b;
        private Tensor c;

        [SetUp]
        public void SetUpTensor()
        {

            a = new Tensor(new[] { -1, 2, 0, 1f });
            b = new Tensor(new[] { -1, 2, 3, 1f });
            c = new Tensor(new[] { 4, 2, 3f, 1 });


        }

        [Test]
        public void TestExp()
        {

            var x  = Tensor.Exp(a);
            Tensor act = new Tensor(new[] { 0.36787944f, 7.3890561f, 1f, 2.71828183f });
            CollectionAssert.AreEqual(act.Arr, x.Arr,new FloatComparer(0.001f));


        }

        [Test]
        public void TestDivide()
        {

            var x = 1/b;
            Tensor act = new Tensor(new[] { -1f, 0.5f, 0.33333333f, 1 });
            CollectionAssert.AreEqual(act.Arr, x.Arr, new FloatComparer(0.001f));

        }

        [Test]
        public void TestAdd()
        {
            var x = 1 + b;
            Tensor add = new Tensor(new float[]{0, 3f, 4, 2});
            CollectionAssert.AreEqual(add.Arr, x.Arr, new FloatComparer(0.001f));
        }

        [Test]
        public void TestSubract()
        {
            var x = 1 - b;
            Tensor sub1= new Tensor(new float[] { 2, -1, -2, 0 });
            Tensor sub2= new Tensor(new float[] {-2,  1,  2,  0 });
            var y = b - 1;
            CollectionAssert.AreEqual(sub1.Arr,x.Arr,new FloatComparer(0.001f));
            CollectionAssert.AreEqual(sub2.Arr,y.Arr,new FloatComparer(0.001f));
        }

        [Test]
        public void TestNegation()
        {

            var x = -b;
            Tensor neg = new Tensor(new float[] { 1, -2, -3, -1 });
            CollectionAssert.AreEqual(neg.Arr, x.Arr,new FloatComparer(0.001f));

        }

        [Test]
        public void TestLog()
        {

            var x = Tensor.Log(c);
            Tensor ln = new Tensor(new float[] { 1.38629436f, 0.69314718f, 1.09861229f, 0 });
            CollectionAssert.AreEqual(ln.Arr,x.Arr,new FloatComparer(0.001f));

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