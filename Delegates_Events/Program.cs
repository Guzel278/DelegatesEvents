// See https://aka.ms/new-console-template for more information
using Delegates_Events;

var numbers = new List<string> { "hellowWorld", "three", "ten", "HellowWorld11111" };
var maxString = numbers.GetMax(s => s.Length);
Console.WriteLine($"The longest string is {maxString}");

var fileSearcher = new FileSearcher();

fileSearcher.FileFound += (sender, e) =>
{
    Console.WriteLine($"File found: {e.FileName}");
    Console.WriteLine("Type 'stop' to cancel or press Enter to continue...");
    if (Console.ReadLine()?.ToLower() == "stop")
    {
        e.Cancel = true;
    }
};

fileSearcher.SearchCancelled += (sender, e) =>
{
    Console.WriteLine("Search has been cancelled.");
};

Console.WriteLine("Enter the directory to search:");
string directoryPath = Console.ReadLine();
if (!string.IsNullOrEmpty(directoryPath))
{
    try
    {
        fileSearcher.SearchFiles(directoryPath);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
else
{
    Console.WriteLine("Invalid directory.");
}

