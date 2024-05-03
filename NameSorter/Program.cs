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

        INameProcessor nameProcessor = new NameProcessor(
            new NameReader(),
            new NameSorter.Services.NameSorter(),
            new NameValidator(), 
            new NameWriter(), 
            _sortedFileName);

        var fileName = args[0];

        try
        {
            nameProcessor.ProcessFile(fileName);  
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}