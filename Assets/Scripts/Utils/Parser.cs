using System.Collections.Generic;
using Utils.Services;

namespace Utils
{
    public abstract class Parser<T> 
    {
        
        public List<Dictionary<string,T>> Frame = new();
        public string[] Header;

        public abstract void GetCSV(IGetCSVService csvService);
        public abstract void Parse(bool hasHeader = true, string[] header = null);
        
    }
}