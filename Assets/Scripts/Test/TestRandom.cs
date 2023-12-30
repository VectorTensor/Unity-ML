using System;
using UnityEngine;
using Scripts.Utils;

namespace Scripts.Test
{
    public class TestRandom : MonoBehaviour
    {
        private void Start()
        {
            float[] x = { 1, 2, 3, 4 };
            float[] z = { 1, 2, 3, 4 };
            float[] y = (Matrix.AddVectors(x,z));
        }
    }
}