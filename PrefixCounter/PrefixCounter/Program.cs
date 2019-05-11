using System;
using System.Collections.Generic;
using System.Linq;

namespace PrefixCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "Steven", "Stevens", "Hulk", "Hulky" };
            var query = new List<string> { "Steve", "Hulk", "Tom" };
            var result = FindPrefix(names, query);
            PrintList<int>(result);
            Console.ReadLine();
        }
                

        private static List<int> FindPrefix(List<string> names, List<string> query)
        {
            var output = new List<int>();

            for(int j = 0; j < query.Count; j++)
            {
                var count = 0;

                for(int k=0; k < names.Count; k++)
                {
                    if (names[k].Length < query[j].Length || names[k] == query[j])
                    {
                        continue;
                    }
                    
                    if( names[k].Substring(0,query[j].Length) == query[j])
                    {
                        count++;
                    }
                }
                output.Add(count);
            }

            return output;
        }

        private static void PrintList<T>(List<T> inputList)
        {
            Console.Write("{");
            for (int i = 0; i < inputList.Count; i++)
            {
                if( i == inputList.Count -1)
                {
                    Console.Write($" {inputList[i]}");
                }
                else
                {
                    Console.Write($" {inputList[i]},");
                }
            }
            Console.Write("} \n");
        }
    }
}
