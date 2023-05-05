using DataCollection.Application.Commands.Interfaces;

namespace DataCollection.Application.Commands;

public class LogParserCommand : ILogParserCommand
{
    public IEnumerable<string> SeperateLogs(string content)
    {
        var delimiter = new string[] { "\n " };
        
        var separatedLogs = content.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        
        return separatedLogs;
    }
}
