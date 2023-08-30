using System;
using System.Collections.Generic;
using System.IO;

namespace CSVParser
{
    public class KeyValuePair
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of times to repet:");
            int Itterate = Console.ReadLine();
            Console.WriteLine("Enter the full path to your CSV file:");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            List<KeyValuePair> keyValuePairs = ParseCSVFile(filePath);
            foreach (var pair in keyValuePairs)
            {
                // Repeat each key-value pair 5 times
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
                }
            }
        }

        static List<KeyValuePair> ParseCSVFile(string filePath)
        {
            List<KeyValuePair> keyValuePairs = new List<KeyValuePair>();

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Trim().Split(',');
                if (parts.Length == 2)
                {
                    keyValuePairs.Add(new KeyValuePair { Key = parts[0].Trim(), Value = parts[1].Trim() });
                }
            }

            return keyValuePairs;
        }
    }
}
