using NameSorter.Interfaces;
using NameSorter.Services;

namespace NameSorter.Tests
{
    public class NameReaderTests
    {
        private readonly string _testFilePath = "testNames.txt";
        private readonly INameReader _reader = new NameReader();

        [Fact]
        public void ReadNames_ShouldReturnCorrectNamesArray_WhenFileIsValid()
        {
            // Arrange
            var expected = new[] { "Janet Parsons", "Vaughn Lewis" };
            File.WriteAllLines(_testFilePath, expected);

            // Act
            var result = _reader.ReadNames(_testFilePath);

            // Assert
            Assert.Equal(expected, result);

            // Cleanup
            File.Delete(_testFilePath);
        }

        [Fact]
        public void ReadNames_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {
            // Act
            var exception = Assert.Throws<FileNotFoundException>(() => _reader.ReadNames(_testFilePath));

            // Assert
            Assert.StartsWith("Could not find file", exception.Message);
        }

        [Fact]
        public void ReadNames_ShouldReturnEmptyArray_WhenFileIsEmpty()
        {
            // Arrange
            File.WriteAllText(_testFilePath, string.Empty);

            // Act
            var result = _reader.ReadNames(_testFilePath);

            // Assert
            Assert.Empty(result);

            // Cleanup
            File.Delete(_testFilePath);
        }
    }
}