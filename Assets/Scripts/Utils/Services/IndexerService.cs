using System.Collections.Generic;
using UnityEngine.Apple;

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

        public List<Dictionary<string, T>> GetRequiredIndex(int x, int y, int z)
        {
            // Check size exceptions
            List<Dictionary<string, T>> reqFrame= new();
            y = y == -1 ? _frame.Count : y;

            for (int i = x; i < y; i = i + z)
            {
                
                reqFrame.Add(_frame[i]);
                
            }

            return reqFrame;

        }

        public List<Dictionary<string, T>> GetRequiredIndex(int[] x)
        {

            List<Dictionary<string, T>> reqFrame = new();

            foreach (var i in x)
            {
                
                
                reqFrame.Add(_frame[i]);
                
            }

            return reqFrame;


        }
    }
}