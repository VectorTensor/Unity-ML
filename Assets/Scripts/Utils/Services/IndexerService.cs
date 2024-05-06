using System.Collections.Generic;

namespace Utils.Services
{
    /// <summary>
    /// This service is takes data frame and gets columns data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IndexerService<T>:IIndexerService
    {
        private List<Dictionary<string, T>> _frame;


        public IndexerService(List<Dictionary<string, T>> x)
        {
            _frame = x;
        }
        public float[,] GetRequiredDataFromColumns(string[] columns)
        {
            
            return new float[,] { { 1, 2 } };
            
        }
    }
}