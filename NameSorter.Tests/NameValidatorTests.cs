using NameSorter.Interfaces;
using NameSorter.Services;

namespace NameSorter.Tests
{
    public class NameValidatorTests
    {
        private readonly INameValidator _validator = new NameValidator();

        [Fact]
        public void ValidateAndCleanNames_ShouldIgnoreLeadingAndTrailingSpaces()
        {
            // Arrange
            var names = new[] { "  Janet Parsons  ", "Vaugn Lewis" };
            var expected = new[] { "Janet Parsons", "Vaugn Lewis" };

            // Act
            var sortedNames = _validator.ValidateAndCleanNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }

        [Fact]
        public void ValidateAndCleanNames_ShouldHandleEmptyRowsInFile()
        {
            // Arrange
            var names = new[] { "Janet Parsons", "", "Vaugn Lewis" };
            var expected = new[] { "Janet Parsons", "Vaugn Lewis" };

            // Act
            var sortedNames = _validator.ValidateAndCleanNames(names);

            // Assert
            Assert.Equal(expected, sortedNames);
        }
    }
}
