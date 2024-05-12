using System.Collections.Generic;

namespace Utils.Services
{
    public interface IIndexerService<T>
    {

        public T[,] GetRequiredDataFromColumns(string[] columns);

        public List<Dictionary<string, T>> GetRequiredIndex(int x, int y, int z);



    }
}