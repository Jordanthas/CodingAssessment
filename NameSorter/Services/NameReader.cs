using NameSorter.Interfaces;

namespace NameSorter.Services
{
    public class NameReader : INameReader
    {
        public string[] ReadNames(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
