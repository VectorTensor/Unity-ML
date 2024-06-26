﻿using System;
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
            float[,] features = txtParser[0, 65, 1][new[] {"Feature_1","Feature_2","Feature_3"}];
            float[,] y = txtParser[0, 65, 1][new[] { "Target" }];
            Tensor X_train = new Tensor(features);
            Tensor Y_train = new Tensor(y);
            LogisticRegression model = new LogisticRegression(0.001f, 100000);
            model.Fit(X_train, Y_train);
            model.SaveModel("Assets/models/log.json");
            Debug.Log($"Training completed on {model}");
            
        }
    }
}