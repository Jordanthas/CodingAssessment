namespace NameSorter.Interfaces
{
    public interface INameSorter
    {
        IEnumerable<string> SortNames(IEnumerable<string> names);
    }
}
