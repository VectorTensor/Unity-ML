using System;
using Neural_Networks;
using UnityEngine;
using Utils;
using Utils.Services;

namespace Test
{
    public class PercepTrain : MonoBehaviour
    {
        
        public GetCSVService _csvSerivce;
        private TextAssetParser<float> txtParser;
        private string[] header;

        private void Start()
        {
            
            txtParser = new TextAssetParser<float>(_csvSerivce,true );
            header = txtParser.Header;
            float[,] features = txtParser[0, 4, 1][new[] {"A","B"}];
            float[,] y = txtParser[0, 4, 1][new[] { "O" }];
            Tensor X_train = new Tensor(features);
            Tensor Y_train = new Tensor(y);
            Adaline model = new Adaline(0.0001f, 10000);
            model.Fit(X_train, Y_train);
            model.SaveModel("Assets/models/ad1.json");
            Debug.Log($"Training completed on {model}");
            
        }
    }
}