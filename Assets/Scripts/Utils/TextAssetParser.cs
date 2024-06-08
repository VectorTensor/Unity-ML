using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unity.VisualScripting.YamlDotNet.Serialization.NodeDeserializers;
using UnityEngine;
using Utils.Services;

namespace Utils
{
    public class TextAssetParser<T>:  Parser<T>
    {
        public string TextString;
        private IGetCSVService _getCsvService;
        private IIndexerService<T> _indexerService;


        public TextAssetParser(IGetCSVService csvService, bool hasHeader = true, string[] header = null)
        {
            
            GetCSV(csvService);
            
            Parse(hasHeader,header);
            
        }

        public TextAssetParser()
        {
            
        }

        public TextAssetParser(List<Dictionary<string, T>> f)
        {

            Frame = f;

            _indexerService = new IndexerService<T>(Frame);
            Header = Frame[0].Keys.ToArray();
        }

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
                Header[Header.Length - 1] =Header[Header.Length - 1].Replace("\r", "");
                lines = lines.Skip(1).ToArray();
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
                    if (dataValues.Length == 0) continue;
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

        public T[,] GetValues()
        {

            T[,] values = new T[Frame.Count, Frame[0].Count];
            int i = 0;
            foreach (var x in Frame)
            {
                int j = 0;
                foreach (var y in x.Values)
                {
                    values[i, j] = y;
                    j++;
                }

                i++;


            }

            return values;

        }

        public T[,] this[string[] x] => _indexerService.GetRequiredDataFromColumns(x);
        
        //x -> start y-> end z -> increment
        public TextAssetParser<T> this[int x, int y, int z] => new TextAssetParser<T>(_indexerService.GetRequiredIndex(x, y, z));
        
        public TextAssetParser<T> this[int[] x] => new TextAssetParser<T>(_indexerService.GetRequiredIndex(x));

        public TextAssetParser<T>[]  CreateTrainTestSplit(float test = 0.3f)
        {
            int[] numbers = new int[Frame.Count];
            for (int i = 0; i < Frame.Count; i++)
            {
                numbers[i] = i ;
            }
            System.Random rand = new System.Random();
            for (int i = Frame.Count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                var temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
                
            }

            var x = _indexerService.GetRequiredIndex(numbers);
            int testCount =(int) (test * (float)x.Count);
            int trainCount = x.Count - testCount;
            var train_set = x.Skip(0).Take(trainCount).ToList();
            var test_set = x.Skip(trainCount - 1).Take(x.Count).ToList();
            TextAssetParser<T>[] o = new[] { new TextAssetParser<T>(train_set), new TextAssetParser<T>(test_set) };
            return o;

        }
        
    }
}