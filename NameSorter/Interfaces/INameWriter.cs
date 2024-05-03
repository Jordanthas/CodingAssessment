namespace NameSorter.Interfaces
{
    public interface INameWriter
    {
        void WriteNamesToFile(IEnumerable<string> names, string filePath);
        void PrintNamesToConsole(IEnumerable<string> names);
    }
}
