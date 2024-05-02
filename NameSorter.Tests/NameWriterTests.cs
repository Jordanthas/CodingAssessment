
using NameSorter.Interfaces;
using NameSorter.Services;

namespace NameSorter.Tests
{
    public class NameWriterTests
    {
        private readonly string _outputFilePath = "outputNames.txt";
        private readonly INameWriter _writer = new NameWriter();

        [Fact]
        public void WriteNames_ShouldWriteNamesToFile()
        {
            // Arrange
            var names = new[] { "Janet Parsons", "Vaughn Lewis" };

            // Act
            _writer.WriteNames(names, _outputFilePath);
            var fileContents = File.ReadAllLines(_outputFilePath);

            // Assert
            Assert.Equal(names, fileContents);

            // Cleanup
            File.Delete(_outputFilePath);
        }

        [Fact]
        public void PrintNamesToConsole_ShouldPrintNames()
        {
            // Arrange
            var names = new[] { "Janet Parsons", "Vaughn Lewis" };
            var stringWriter  = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            _writer.PrintNamesToConsole(names);

            // Assert
            var output = stringWriter.ToString().Trim();
            Assert.Contains("Janet Parsons", output);
            Assert.Contains("Vaughn Lewis", output);

            // Cleanup
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }
    }
}
