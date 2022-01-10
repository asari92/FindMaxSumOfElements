using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FindMaxSumOfElementsNS
{
    public class Finder
    {
        private readonly List<int> _defectiveLines = new List<int>();
        private readonly List<int> _linesWithMaxSum = new List<int>();
        public List<int> DefectiveLines => _defectiveLines;
        public List<int> LinesWithMaxSum => _linesWithMaxSum;
        private double maxSum = Double.NegativeInfinity;

        public Finder(StreamReader sr)
        {
            int currentLineNum = 0;
            string currentLine;
            NumberFormatInfo provider = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ","
            };

            while ((currentLine = sr.ReadLine()) != null)
            {
                bool isDefectiveLine = false;
                double sumOfCurrentLine = 0;
                currentLineNum++;

                foreach (string number in currentLine.Split(','))
                {
                    try
                    {
                        sumOfCurrentLine += Convert.ToDouble(number, provider);
                    }
                    catch (FormatException)
                    {
                        _defectiveLines.Add(currentLineNum);
                        isDefectiveLine = true;
                        break;
                    }
                }

                if (!isDefectiveLine)
                {
                    AddLineWithMaxSum(sumOfCurrentLine, currentLineNum);
                }
            }
        }

        private void AddLineWithMaxSum(double sumOfCurrentLine, int currentLineNum)
        {
            if (sumOfCurrentLine > maxSum)
            {
                maxSum = sumOfCurrentLine;
                _linesWithMaxSum.Clear();
                _linesWithMaxSum.Add(currentLineNum);
            }
            else if (sumOfCurrentLine == maxSum)
            {
                _linesWithMaxSum.Add(currentLineNum);
            }
        }
    }
}
