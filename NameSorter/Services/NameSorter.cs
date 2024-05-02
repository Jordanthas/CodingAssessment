using NameSorter.Interfaces;

namespace NameSorter.Services
{
    public class NameSorter : INameSorter
    {
        public IEnumerable<string> SortNames(string[] names)
        {
            return names.Select(n => n.Trim())
                        .Where(name => !string.IsNullOrWhiteSpace(name))
                        .OrderBy(name => name.Split(' ').Last())
                        .ThenBy(name => name)
                        .ToArray();
        }
    }
}
