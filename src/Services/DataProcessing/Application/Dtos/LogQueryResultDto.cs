namespace DataProcessing.Application.Dtos;
public class LogQueryResultDto
{
    public int Id { get; set; }
    public string MLType { get; set; }
    public DateTime Timestamp { get; set; }
    public string LogMessage { get; set; }
    public string ExceptionType { get; set; }
    public bool Error { get; set; }
    public bool Warning { get; set; }
    public string FaultyCodePlacement { get; set; }

    public LogQueryResultDto(int id, string mlType, DateTime timestamp, string logMessage, string exceptionType, bool error, bool warning, string faultyCodePlacement)
    {
        Id = id;
        MLType = mlType;
        Timestamp = timestamp;
        LogMessage = logMessage;
        ExceptionType = exceptionType;
        Error = error;
        Warning = warning;
        FaultyCodePlacement = faultyCodePlacement;
    }
}