using System.Collections.Generic;

namespace Utils.Services
{
    public class IndexerService<T>:IIndexerService
    {
        private List<Dictionary<string, T>> _frame;


        public IndexerService(List<Dictionary<string, T>> x)
        {
            _frame = x;
        }
        public float[,] GetRequiredDataFromColumns()
        {
            
            return new float[,] { { 1, 2 } };
            
        }
    }
}