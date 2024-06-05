namespace ModelEvaluation
{
    public class ConfusionMatrix
    {

        private int[,] matrix;

        public int[,] cm => matrix;


        private string[] _labels;
        public ConfusionMatrix(string[] labels = null)
        {
            // LABEL 0 , 1 
            if (labels == null)
            {
                labels = new[] { "0", "1" };

            }

            _labels = labels;
            
            

            matrix = new int[2, 2];

        }

        public void CreateConfusionMatrix(int[] pred, int[] actual)
        {
            int TP = 0;
            int FP = 0;
            int FN = 0;
            int TN = 0;

            for (int i = 0; i < pred.Length; i++)
            {
                if (pred[i] == 1)
                {
                    if (actual[i] == pred[i])
                    {
                        // TP 
                        TP++;

                    }
                    else
                    {
                        //FP
                        FP++;

                    }
                    
                }
                else
                {
                    
                    if (actual[i] == pred[i])
                    {
                        // TN 
                        TN++;

                    }
                    else
                    {
                        //FN
                        FN++;

                    }
                    
                }
                
            }

            matrix[0, 0] = TP;
            matrix[0, 1] = FP;
            matrix[1, 0] = FN;
            matrix[1, 1] = TN;

        }


    }
}