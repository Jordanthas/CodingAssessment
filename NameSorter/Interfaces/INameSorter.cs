namespace NameSorter.Interfaces
{
    public interface INameSorter
    {
        IEnumerable<string> SortNames(string[] names);
    }
}
