namespace NameSorter.Interfaces
{
    public interface INameValidator
    {
        IEnumerable<string> ValidateAndCleanNames(string[] names);
    }
}
