using System;
using System.IO;
using System.Linq;
using ModelEvaluation;
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
            var split = parser.CreateTrainTestSplit(0.2f);
            

            float[,] feat_test = parser[0, -1, 1][new[] {"Feature_1","Feature_2","Feature_3"}];
            float[,] y_test = parser[ 0, -1, 1 ][new[] { "Target"}];
            Tensor X_test = new Tensor(feat_test);
            Tensor Y_test = new Tensor(y_test);
            var y_prd = p.Predict(X_test);
            var m = y_prd.T()[0];
            var b = m.Arr;
            var y_act = BasicUtilsML.GetRow(Y_test.T().Arr, 0);
            ConfusionMatrix cm = new ConfusionMatrix(new[] { "0", "1" });
            var y_test_int = BasicUtilsML.ConvertToInt(y_act); 
            var y_pred_int = BasicUtilsML.ConvertToInt(b); 
            cm.CreateConfusionMatrix(y_pred_int,y_test_int);
            var output = cm.cm;
            ClassificationMetrics CM = ClassificationMetrics.CalculateMetrics(cm);
            var acc = CM.metrics;



        }
    }
}
