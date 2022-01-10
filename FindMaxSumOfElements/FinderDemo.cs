using System;
using System.Collections.Generic;
using System.IO;

namespace FindMaxSumOfElementsNS
{
    public class FinderDemo
    {
        private const string EnterFilePath = "Enter file path: ";
        private const string ReportLines = "\nLine(s) with maximum sum of elements:";
        private const string ReportNoLines = "\nUnfortunately all lines are defective";
        private const string ReportDefectiveLines = "\n\nDefective line(s):";
        private const string ReportNoDefectiveLines = "\n\nThe file has no defective line(s)";
        public static void DemoPlay(string[] args)
        {
            try
            {
                Finder finder;

                if (args.Length != 0)
                {
                    finder = new Finder(new StreamReader(args[0]));
                }
                else
                {
                    Console.Write(EnterFilePath);
                    finder = new Finder(new StreamReader(Console.ReadLine()));
                }

                ConsoleShowRequestedLines(finder.LinesWithMaxSum, ReportLines, ReportNoLines);
                ConsoleShowRequestedLines(finder.DefectiveLines, ReportDefectiveLines, ReportNoDefectiveLines);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ConsoleShowRequestedLines(List<int> RequestedLines, string ReportHasLines, string ReportHasNoLines)
        {
            Console.Write(RequestedLines.Count != 0 ? ReportHasLines : ReportHasNoLines);

            foreach (int requestedLine in RequestedLines)
            {
                Console.Write($" {requestedLine}");
            }
        }
    }
}
