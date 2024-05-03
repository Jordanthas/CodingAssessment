using NameSorter.Interfaces;

namespace NameSorter.Services
{
    public class NameValidator : INameValidator
    {
        public IEnumerable<string> ValidateAndCleanNames(string[] names)
        {
            return names.Where(name => !string.IsNullOrWhiteSpace(name))
                        .Select(name => name.Trim());
        }
    }
}
