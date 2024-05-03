using NameSorter.Interfaces;

namespace NameSorter.Services.Sorters
{
    public class NameSorter : INameSorter
    {
        public IEnumerable<string> SortNames(IEnumerable<string> names)
        {
            return names.OrderBy(name => name.Split(' ').Last())
                        .ThenBy(name => name)
                        .ToArray();
        }
    }
}
