using System;
using System.IO;
using System.Linq;
using Xunit;

namespace FindMaxSumOfElementsNS
{
    public class FindMaxSumOfElementsTests
    {
        [Theory]
        [InlineData("..\\..\\..\\WrongDots.txt", 2)]
        [InlineData("..\\..\\..\\NegativeNumbers.txt", 1)]
        [InlineData("..\\..\\..\\OneLine.txt", 1)]
        public void CheckLineWithMaxSumOfElements(string fileWay, int expected)
        {
            Finder finder = new Finder(new StreamReader(fileWay));

            int[] actual = finder.LinesWithMaxSum.ToArray();

            Assert.Equal(expected, actual[0]);
        }

        [Theory]
        [InlineData("..\\..\\..\\PositiveInfinity.txt", new[] {10, 11})]
        [InlineData("..\\..\\..\\NegativeInfinity.txt", new[] {1, 2})]
        [InlineData("..\\..\\..\\ManyEqualLines.txt", new[] {5, 7, 9})]
        public void CheckLinesWithMaxSumOfElements(string fileWay, int[] expected)
        {
            Finder finder = new Finder(new StreamReader(fileWay));

            int[] actual = finder.LinesWithMaxSum.ToArray();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("..\\..\\..\\WrongDots.txt",new[] {1})]
        [InlineData("..\\..\\..\\NegativeNumbers.txt",new[] {4, 5, 6})]
        [InlineData("..\\..\\..\\PositiveInfinity.txt", new[] {2, 7, 8, 9, 12})]
        public void CheckDefectiveLines(string fileWay, int[] expected)
        {
            Finder finder = new Finder(new StreamReader(fileWay));

            int[] actual = finder.DefectiveLines.ToArray();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("\\throw")]
        public void CheckWrongFileWay(string wrongFileWay)
        {
            Assert.Throws<FileNotFoundException>(() => new Finder(new StreamReader(wrongFileWay)));
        }
    }
}