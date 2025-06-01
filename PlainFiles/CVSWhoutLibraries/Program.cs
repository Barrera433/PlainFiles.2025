using CVSWhoutLibraries;
using System.Xml.Linq;

var people = new List<string[]>
{
    new [] { "id", "name", "age" },
    new [] { "1", "Alice",   "30" },
    new [] { "2", "Bob",  "25" },
    new [] { "3", "Pedro", "45" },
    new [] { "4", "Maria", "35" },
    new [] { "5", "Edison", "18" }
};

var manualCVS = new ManualCsvHelper();
manualCVS.WriterCVS("people.csv", people);
var readPeople = manualCVS.ReadCVS("people.csv");
foreach (var person in readPeople)
{
    Console.WriteLine(string.Join(", ", person));
}