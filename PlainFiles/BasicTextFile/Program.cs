using BasicTextFile;
using System.ComponentModel.Design;

var textFile = new SimpleTextFile("data.txt");
var lines = textFile.ReadLines();

using (var logger = new LogWriter("log.txt"))
{
    
    var opc = "0";
    logger.WriteLog("INFO", "Application started.");

    do
    {
        opc = Menu();
        Console.WriteLine($"=============================");
        switch (opc)
        {
            case "1":
                logger.WriteLog("INFO", "Showing content. ");
                if (lines.Length == 0)
                {
                    Console.WriteLine("Empty file.");
                    logger.WriteLog("ERROR", "File is empty.");
                    break;
                }
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                break;

            case "2":
                logger.WriteLog("INFO", "Adding a new line.");
                Console.WriteLine("Enter the line to add:");
                var newLine = Console.ReadLine();
                if (string.IsNullOrEmpty(newLine))
                {
                    lines = lines.Append(newLine).ToArray()!;
                }
                break;

            case "3":
                logger.WriteLog("INFO", "Updating a line.");
                Console.WriteLine("Enter the line to update:");
                var lineToUpdate = Console.ReadLine();
                if (string.IsNullOrEmpty(lineToUpdate))
                {
                    Console.WriteLine("Enter the new value for the line:");
                    var newValue = Console.ReadLine();
                    lines = lines.Select(line => line == lineToUpdate ? newValue : line).ToArray()!;//106
                }

                break;


            case "4":
                logger.WriteLog("INFO", "Removing a line.");
                Console.WriteLine("Enter the line to remove:");
                var lineToRemove = Console.ReadLine();
                if (string.IsNullOrEmpty(lineToRemove))
                {
                    lines = lines.Where(line => line != lineToRemove).ToArray()!;
                }
                break;

            case "5":
                logger.WriteLog("INFO", "Saving a line.");
                Console.WriteLine("Enter the line to save:");
                var lineToSave = Console.ReadLine();
                break;

            case "0":
                Console.WriteLine("Exiting the program.");
                break;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
       

    }
    while (opc != "0");
    logger.WriteLog("INFO", "Application finished.");
    SaveChanges();

    void SaveChanges()
    {
        Console.WriteLine("Saving changes...");
        textFile.WriteLines(lines);
        Console.WriteLine("Changes saved .");
    }
}
 
string Menu()
{
    Console.WriteLine("=========================");
    Console.WriteLine("1. Show conter");
    Console.WriteLine("2. Add line");
    Console.WriteLine("3. Update line");
    Console.WriteLine("4. Remove line");
    Console.WriteLine("5. Save line");
    Console.WriteLine("0. Exit");
    Console.WriteLine("Enter your option");
    var opc = Console.ReadLine()?? "0";
    return opc;
}