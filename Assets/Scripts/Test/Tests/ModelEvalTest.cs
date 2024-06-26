﻿using ModelEvaluation;
using NUnit.Framework;

namespace Test.Tests{


    [TestFixture]
    public class ModelEvalTest
    {
        private ConfusionMatrix Con;
        private ClassificationMetrics CM;

        private int[] pred;
        private int[] act;

        [SetUp]
        public void SetUpCM()
        {
            Con = new ConfusionMatrix();
            pred = new[] { 1, 1, 1, 1, 0, 0, 1, 0, 0, 0 };
            act = new[] { 0, 1, 1, 0, 1, 0, 1, 0, 0, 1 };
            


        } 
        
        [Test]
        public void TestCM()
        {
            
            Con.CreateConfusionMatrix(pred, act);
            int[,] exp = new int[,] { { 3, 2 }, { 2, 3 } };
            CollectionAssert.AreEqual(exp, Con.cm);
            
        }

        [Test]
        public void TestMetrics()
        {
            
            Con.CreateConfusionMatrix(pred, act);
            CM = ClassificationMetrics.CalculateMetrics(Con);
            float exp = 0.6f;
            Assert.AreEqual(exp,CM.metrics["Accuracy"],0.001f);
            Assert.AreEqual(exp,CM.metrics["Precision"],0.001f);
            Assert.AreEqual(exp,CM.metrics["Recall"],0.001f);
            Assert.AreEqual(exp,CM.metrics["F1Score"],0.001f);
            
            
            

        }
        
    }
}