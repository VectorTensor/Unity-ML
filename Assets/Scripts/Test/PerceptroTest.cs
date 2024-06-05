using System;
using System.IO;
using Neural_Networks;
using UnityEngine;
using Utils;
using Utils.Model;
using Utils.Services;

namespace Test
{
    public class PerceptroTest : MonoBehaviour
    {
        public GetCSVService _csvSerivce;
        private TextAssetParser<float> txtParser;
        public void Start()
        {
            

            var x = File.ReadAllText("Assets/models/log.json");
            AdalineModelDto d = JsonUtility.FromJson<AdalineModelDto>(x);
            var p = new LogisticRegression(d);
            var  parser = new TextAssetParser<float>(_csvSerivce,true);

            float[,] feat_test = parser[0, 4, 1][new[] { "A", "B"}];
            float[,] y_test = parser[ 0, 4, 1 ][new[] { "O" }];
            Tensor X_test = new Tensor(feat_test);
            Tensor Y_test = new Tensor(y_test);
            var y_prd = p.Predict(X_test);



        }
    }
}
