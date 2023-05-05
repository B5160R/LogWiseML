namespace DataCollection.Application.Commands.Interfaces;
public interface ILogParserCommand
{
    IEnumerable<string> SeperateLogs(string content);
}