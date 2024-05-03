using Moq;
using NameSorter.Interfaces;
using NameSorter.Services;

namespace NameSorter.Tests
{
    public class NameProcessorTests
    {
        [Fact]
        public void ProcessFile_ShouldProcessNamesCorrectly()
        {
            // Arrange
            var mockReader = new Mock<INameReader>();
            var mockSorter = new Mock<INameSorter>();
            var mockValidator = new Mock<INameValidator>();
            var mockWriter = new Mock<INameWriter>();
            var inputFileName = "unsorted-names-list.txt";
            var outputFileName = "sorted-names-list.txt";
            var names = new[] { "Jane Doe", "", "John Smith " };
            var cleanedNames = new List<string> { "Jane Doe", "John Smith" };
            var sortedNames = new List<string> { "John Smith", "Jane Doe" };

            mockReader.Setup(m => m.ReadNames(inputFileName)).Returns(names);
            mockValidator.Setup(m => m.ValidateAndCleanNames(names)).Returns(cleanedNames);
            mockSorter.Setup(m => m.SortNames(cleanedNames)).Returns(sortedNames);
            mockWriter.Setup(m => m.WriteNamesToFile(sortedNames, outputFileName));
            mockWriter.Setup(m => m.PrintNamesToConsole(sortedNames));

            var processor = new NameProcessor(mockReader.Object, mockSorter.Object, mockValidator.Object, mockWriter.Object, outputFileName);

            // Act
            processor.ProcessFile(inputFileName);

            // Assert
            mockReader.Verify(m => m.ReadNames(inputFileName), Times.Once);
            mockValidator.Verify(m => m.ValidateAndCleanNames(names), Times.Once);
            mockSorter.Verify(m => m.SortNames(cleanedNames), Times.Once);
            mockWriter.Verify(m => m.WriteNamesToFile(sortedNames, outputFileName), Times.Once);
            mockWriter.Verify(m => m.PrintNamesToConsole(sortedNames), Times.Once);
        }
    }
}
