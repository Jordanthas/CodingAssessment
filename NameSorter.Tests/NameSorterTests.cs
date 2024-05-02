using NameSorter.Interfaces;

namespace NameSorter.Tests
{
    public class NameSorterTests
    {
        private readonly INameSorter _sorter = new Services.NameSorter();

        [Fact]
        public void SortNames_ShouldCorrectlySortNamesByLastNameThenFirstName()
        {
            // Arrange
            var names = new[] { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer" };
            var expected = new[] { "Adonis Julius Archer", "Vaughn Lewis", "Janet Parsons" };
            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }

        [Fact]
        public void SortNames_ShouldHandleSingleName()
        {
            // Arrange
            var names = new[] { "Janet" };

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(names, sortedNames);
        }

        [Fact]
        public void SortNames_ShouldReturnEmptyArray_WhenNoNamesProvided()
        {
            // Arrange
            var names = new string[0];

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Empty(sortedNames);
        }

        [Fact]
        public void SortNames_ShouldIgnoreLeadingAndTrailingSpaces()
        {
            // Arrange
            var names = new[] { "  Janet Parsons  ", "Vaugn Lewis" };
            var expected = new[] { "Vaugn Lewis", "Janet Parsons" };

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }

        [Fact]
        public void SortNames_ShouldHandleNamesWithTitlesCorrectly()
        {
            // Arrange
            var names = new[] { "Mr. John Smith", "Dr. Jane Smith" };
            var expected = new[] { "Dr. Jane Smith", "Mr. John Smith" };

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }

        [Fact]
        public void SortNames_ShouldHandleEmptyRowsInFile()
        {
            // Arrange
            var names = new[] { "Janet Parsons", "", "Vaugn Lewis" };
            var expected = new[] { "Vaugn Lewis", "Janet Parsons" };

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }

        [Theory]
        [InlineData(100000)]
        public void SortNames_ShouldHandleLargeDatasetsEfficiently(int size)
        {
            // Arrange
            var names = Enumerable.Range(1, size).Select(n => $"Name {n}").ToArray();
            var expected = names.OrderBy(n => n).ToArray();

            // Act
            var sortedNames = _sorter.SortNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }
    }
}
