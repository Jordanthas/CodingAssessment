namespace NameSorter.Interfaces
{
    public interface INameWriter
    {
        void WriteNames(IEnumerable<string> names, string filePath);
        void PrintNamesToConsole(IEnumerable<string> names);
    }
}
