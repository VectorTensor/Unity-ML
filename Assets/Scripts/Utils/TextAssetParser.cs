using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Utils.Services;

namespace Utils
{
    public class TextAssetParser<T>:  Parser<T>
    {
        public string TextString;
        private IGetCSVService _getCsvService;
        private IIndexerService _indexerService;

        

        public override void GetCSV(IGetCSVService  csvService)
        {

            TextString = csvService.GetData();
        }

        public override void Parse(bool hasHeader = true, string[] header = null)
        {

            string[] lines = TextString.Split("\n");

            if (hasHeader)
            {
                var p = lines[0];
                p = p.Replace(" ", "");
                Header = Regex.Split(p, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                
            }
            else
            {
                if (header == null)
                {
                    
                    Debug.LogError("No Header passed");
                    return;
                }

                Header = header;
            }

            foreach (var line in lines)
            {
                
                
                string[] dataValues =  Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                if (Header.Length != dataValues.Length)
                {
                    Debug.LogError("Length of header mismatch with number of elements" +  lines);
                    return;
                }

                int index = 0;
                Dictionary<string, T > record = new();
                foreach (string dataValue in dataValues)
                {

                    if (typeof(T) == typeof(float ))
                    {
                        
                       record.Add(Header[index],(T) (object) float.Parse(dataValue)); 
                        
                        
                    }
                    else
                    {
                        record.Add(Header[index],(T)(object) dataValue);
                    }

                    index++;

                }
                
                Frame.Add(record);


            }

            _indexerService = new IndexerService<T>(Frame);



        }


        private float[,] this[string[] x] => _indexerService.GetRequiredDataFromColumns();
    }
}