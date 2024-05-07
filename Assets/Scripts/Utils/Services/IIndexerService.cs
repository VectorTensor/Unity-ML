using System.Collections.Generic;

namespace Utils.Services
{
    public interface IIndexerService<T>
    {

        public T[,] GetRequiredDataFromColumns(string[] columns);



    }
}