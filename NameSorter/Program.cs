using NameSorter.Interfaces;
using NameSorter.Services;

class Program
{
    private static string _sortedFileName = "sorted-names-list.txt";

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the filename as an arguement.");
            return;
        }

        var filename = args[0];
        INameReader nameReader = new NameReader();
        INameSorter nameSorter = new NameSorter.Services.NameSorter();
        INameValidator nameValidator = new NameValidator();
        INameWriter nameWriter = new NameWriter();

        try
        {
            var names = nameReader.ReadNames(filename);
            var cleanedNames = nameValidator.ValidateAndCleanNames(names);
            var cleanedAndSortedNames = nameSorter.SortNames(cleanedNames);
            nameWriter.WriteNames(cleanedAndSortedNames, _sortedFileName);
            nameWriter.PrintNamesToConsole(cleanedAndSortedNames);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}