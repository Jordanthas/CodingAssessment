using NameSorter.Interfaces;

namespace NameSorter.Services.Sorters
{
    public class NameSorterEfficient : INameSorter
    {
        public IEnumerable<string> SortNames(IEnumerable<string> names)
        {
            // Precompute last names and store them with the original name
            var nameEntries = names.Select(trimmedName => new NameEntry(trimmedName));

            // Parallel sort - Only really efficient in a multi-core environment
            var sortedEntries = nameEntries.AsParallel()
                                           .OrderBy(entry => entry.LastName)
                                           .ThenBy(entry => entry.OriginalName);

            return sortedEntries.Select(entry => entry.OriginalName).ToArray();
        }

        private class NameEntry
        {
            public string OriginalName { get; }
            public string LastName { get; }

            public NameEntry(string name)
            {
                OriginalName = name;
                LastName = name.Substring(name.LastIndexOf(' ') + 1);
            }
        }
    }
}
