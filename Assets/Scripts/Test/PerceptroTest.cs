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
        public void Start()
        {
            
            // txtParser = new TextAssetParser<float>(_csvSerivce,false, new []{"1","2","3","4","5","6","7","8","t"});
            // header = txtParser.Header;
            // float[,] features = txtParser[0, 701, 1][new[] { "1", "2", "3", "4", "5", "6", "7", "8" }];
            // float[,] y = txtParser[0, 701, 1][new[] { "t" }];
            // Tensor X_train = new Tensor(features);
            // Tensor Y_train = new Tensor(y);
            // Adaline model = new Adaline(0.01f, 10);
            // model.Fit(X_train, Y_train);
            // model.SaveModel("Assets/models/ad.json");

            var x = File.ReadAllText("Assets/models/ad.json");
            AdalineModelDto d = JsonUtility.FromJson<AdalineModelDto>(x);
            var p = new Adaline(d);
            
        }
    }
}
