using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


namespace Scripts.Utils
{
    public class TextAssetParser<T>:  Parser<T>
    {
        public string textString;
        private IGetCSVService _getCsvService;

        

        public override void GetCSV(IGetCSVService  csvService)
        {

            textString = csvService.GetData();
        }

        public override void Parse(bool hasHeader = true, string[] header = null)
        {

            string[] Lines = textString.Split("\n");

            if (hasHeader)
            {
                var p = Lines[0];
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

            foreach (var line in Lines)
            {
                
                
                string[] data_values =  Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                if (Header.Length != data_values.Length)
                {
                    Debug.LogError("Length of header mismatch with number of elements" +  Lines);
                    return;
                }

                int index = 0;
                Dictionary<string, T > Record = new();
                foreach (string data_value in data_values)
                {

                    if (typeof(T) == typeof(float ))
                    {
                        
                       Record.Add(Header[index],(T) (object) float.Parse(data_value)); 
                        
                        
                    }
                    else
                    {
                        Record.Add(Header[index],(T)(object) data_value);
                    }

                    index++;

                }
                
                Frame.Add(Record);

                
                




            }

        }
    }
}