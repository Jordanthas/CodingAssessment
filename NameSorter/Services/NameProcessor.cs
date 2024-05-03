using NameSorter.Interfaces;

namespace NameSorter.Services
{
    public class NameProcessor : INameProcessor
    {
        private readonly INameReader _nameReader;
        private readonly INameSorter _nameSorter;
        private readonly INameValidator _nameValidator;
        private readonly INameWriter _nameWriter;

        private readonly string _sortedFileName;

        public NameProcessor(INameReader nameReader, INameSorter nameSorter, INameValidator nameValidator, INameWriter nameWriter, string sortedFileName)
        {
            _nameReader = nameReader;
            _nameSorter = nameSorter;
            _nameValidator = nameValidator;
            _nameWriter = nameWriter;
            _sortedFileName = sortedFileName;
        }

        public void ProcessFile(string fileName) 
        {
            var names = _nameReader.ReadNames(fileName);
            var cleanedNames = _nameValidator.ValidateAndCleanNames(names);
            var cleanedAndSortedNames = _nameSorter.SortNames(cleanedNames);
            _nameWriter.WriteNames(cleanedAndSortedNames, _sortedFileName);
            _nameWriter.PrintNamesToConsole(cleanedAndSortedNames);
        }
    }
}
