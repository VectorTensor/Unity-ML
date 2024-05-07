using System.Collections.Generic;

namespace Utils.Services
{
    /// <summary>
    /// This service is takes data frame and gets columns data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IndexerService<T>:IIndexerService<T>
    {
        private List<Dictionary<string, T>> _frame;


        public IndexerService(List<Dictionary<string, T>> x)
        {
            _frame = x;
        }
        public T[,] GetRequiredDataFromColumns(string[] columns)
        {
            T[,] arr = new T[_frame.Count,columns.Length];

            for (int i = 0; i < _frame.Count ; i++)
            {

                var record = _frame[i];
                int j = 0;
                foreach (var x in columns)
                {

                    arr[i, j] = record[x];

                    j++;
                }

            }

            return arr;


        }
    }
}