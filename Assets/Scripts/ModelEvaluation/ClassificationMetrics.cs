using System.Collections.Generic;

namespace ModelEvaluation
{
    public class ClassificationMetrics
    {
        private ConfusionMatrix _cm;
        private float accuracy;
        private float Precision;
        private float recall;
        private float f1Score;

        public Dictionary<string, float> metrics
        {
            get
            {
                Dictionary<string, float> x = new Dictionary<string, float>()
                {
                    { "Accuracy", accuracy },
                    { "Precision", Precision },
                    { "Recall", recall },
                    { "F1Score", f1Score }
                };
                return x;

            }
        }
        

        private ClassificationMetrics(ConfusionMatrix cm)
        {
            _cm = cm;

        }

        public static ClassificationMetrics CalculateMetrics(ConfusionMatrix cm)
        {

            ClassificationMetrics c = new  ClassificationMetrics(cm);
            c.Calculate();
            return c;

        }

        private void Calculate()
        {
            int TP = _cm.cm[0, 0];
            int FP = _cm.cm[0, 1];
            int FN = _cm.cm[1, 0];
            int TN = _cm.cm[1, 1];

            accuracy = (TP + TN) /((float) (TP + TN + FP + FN));
            Precision = TP / ((float)(TP + FP));
            recall = TP / (float)(TP + FN);
            f1Score = 2 * (Precision * recall) /(recall + Precision);
            

        }
        

    }
}