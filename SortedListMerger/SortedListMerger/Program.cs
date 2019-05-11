using System;
using System.Collections.Generic;

namespace SortedListMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSortedList = new List<int> { 1, 2,3,4 };
            var secondSortedList = new List<int> { 0, 1, 5, 7, 7 };
            var result = MergeLists(firstSortedList, secondSortedList);
            PrintList<int>(result);
            Console.ReadLine();
        }

        private static List<int> MergeLists(List<int> firstSortedList, List<int> secondSortedList)
        {
            var outputList = new List<int>();
            var firstListIterator = 0;

            while (firstListIterator < firstSortedList.Count)
            {
                var listElement = firstSortedList[firstListIterator];
                if (secondSortedList.Count == 0)
                {
                    outputList.Add(listElement);
                    firstListIterator++;
                    continue;
                }

                var comparator = secondSortedList[0];

                if (comparator <= listElement)
                {
                    outputList.Add(comparator);
                    secondSortedList.Remove(comparator);
                    continue;
                }

                outputList.Add(listElement);
                firstListIterator++;
            }
            outputList.AddRange(secondSortedList);
            return outputList;
        }

        private static void PrintList<T>(List<T> inputList)
        {
            Console.Write("{");
            for (int i = 0; i < inputList.Count; i++)
            {
                if (i == inputList.Count - 1)
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
