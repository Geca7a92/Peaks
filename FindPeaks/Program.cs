using System;
using System.Collections.Generic;
using System.Linq;

namespace FindPeaks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = DataReader();
            Dictionary<int, int> result = FindPeaks(inputArr);
            Print(result);
        }

        private static void Print(Dictionary<int, int> result)
        {
            if (result.Count == 0)
            {
                Console.WriteLine("Peaks not found");
            }
            else
            {
                Console.WriteLine(string.Join("; ", result.Select(x => x.Key + ", " + x.Value)));
            }
        }

        private static Dictionary<int, int> FindPeaks(int[] inputArr)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 1; i < inputArr.Length - 1; i++)
            {
                if (inputArr[i] > inputArr[i - 1] && inputArr[i] > inputArr[i + 1])
                {
                    result.Add(i, inputArr[i]);
                }
            }
            return result;
        }

        private static int[] DataReader()
        {
            int[] inputArr;

            while (true)
            {
                try
                {
                    inputArr = Console.ReadLine()
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    if (inputArr.Length < 3)
                    {
                        Console.WriteLine("At least 3 numbers");
                        throw new Exception();
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect format");
                }
            }
            return inputArr;
        }
    }
}
