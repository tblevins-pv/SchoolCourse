using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace SchoolCourse
{
    public class CsvParser
    {
        public List<(string, string)> CsvTuples { get; set; }
        public List<(string, string, string, string[])> CsvQuadruples { get; set; } 
        public List<(string, string, string, string, string, string)> CsvHextuples { get; set; } 
        
        public CsvParser()
        {
            CsvTuples = new List<(string, string)>();
            CsvQuadruples = new List<(string, string, string, string[])>();
            CsvHextuples = new List<(string, string, string, string, string, string)>();
        }

        public void ParseCsv(string csvFilePath, string type)
        {
            var parser = new TextFieldParser(csvFilePath) {TextFieldType = FieldType.Delimited};
            parser.SetDelimiters(",");
            
            switch (type) {
                case "tuple":
                    while (!parser.EndOfData)
                    {
                        var fields = parser.ReadFields();
                        CsvTuples.Add((fields[0], fields[1]));
                    }
                    break;
                case "quadruple":
                    while (!parser.EndOfData) {
                        var fields = parser.ReadFields();
                        CsvQuadruples.Add((fields[0], fields[1], fields[2], fields[3].Split(",")));
                    }      
                    break;
                case "hextuple":
                    while (!parser.EndOfData) {
                        var fields = parser.ReadFields();
                        CsvHextuples.Add((fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]));
                    }
                    break;
                default:
                    Console.WriteLine("you hit default dummy");
                    break;
            }
        }
    }
}