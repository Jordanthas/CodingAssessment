using NameSorter.Interfaces;
using NameSorter.Services;
using System.IO.Pipelines;

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
        INameWriter nameWriter = new NameWriter();

        try
        {
            var names = nameReader.ReadNames(filename);
            var sortedNames = nameSorter.SortNames(names);
            nameWriter.WriteNames(sortedNames, _sortedFileName);
            nameWriter.PrintNamesToConsole(sortedNames);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}