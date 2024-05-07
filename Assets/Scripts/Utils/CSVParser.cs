namespace Scripts.Utils
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEngine;

    
    
    
    public class CSVParser 
    {
        public List<Dictionary<string,string>> Frame = new();
        public string[] Header;

        public void parse(string filename, bool hasHeader = true, string[] header=null){


            Frame.Clear();


            StreamReader fs = new StreamReader(filename);

            string data;

            using(fs){

                if (hasHeader){
                    data = fs.ReadLine();
                    data = data.Replace(" ", "");

                    Header = Regex.Split(data, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                }
                else{
                    if (header == null){
                      //  Debug.LogError("No Header passed ");
                        return;
                    }
                    Header = header;
                }

                do{

                    data = fs.ReadLine();

                    string[] data_values = Regex.Split(data, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    if (Header.Length != data_values.Length){
                       // Debug.LogError("Length of the Header mismatch with number of elements");
                        return;
                    }
                    int index =0 ;
                    Dictionary<string, string> Record = new();
                    foreach (string data_value in data_values){

                        Record.Add(Header[index], data_value);
                        index ++;

                    }


                    Frame.Add(Record);


                }
                while(!fs.EndOfStream);
            }
            
            



        }

    }
}