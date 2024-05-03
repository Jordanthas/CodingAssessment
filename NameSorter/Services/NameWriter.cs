using NameSorter.Interfaces;

namespace NameSorter.Services
{
    public class NameWriter : INameWriter
    {
        public void WriteNamesToFile(IEnumerable<string> names, string filePath)
        {
            File.WriteAllLines(filePath, names);
        }

        public void PrintNamesToConsole(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
