namespace DataProcessing.Domain.Models;
public class LogProcessedModel
{
    public int Id { get; private set; }
    // The type of dataset the log is processed into to be used for ML
    public string MLType { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string ExceptionType { get; private set; }
    public string LogSeverity { get; private set; }
    public string LogMessage { get; private set; }
    public string ErrorStatus { get; private set; }
    public string ErrorType { get; private set; }
    
    public LogProcessedModel(int id, string mlType, string content)
    {
        Id = id;
        MLType = mlType;
        Timestamp = DateTime.UtcNow;
        
        ExceptionType = GetExceptionType(content);
        LogSeverity = GetLogSeverity(content);
        LogMessage = GetLogMessage(content);
        ErrorStatus = GetErrorStatus(content);
        ErrorType = GetErrorType(content);
    }

    private string? GetErrorType(string content)
    {
        throw new NotImplementedException();
    }

    private string? GetErrorStatus(string content)
    {
        throw new NotImplementedException();
    }

    private string? GetLogMessage(string content)
    {
        throw new NotImplementedException();
    }

    private string? GetLogSeverity(string content)
    {
        throw new NotImplementedException();
    }

    private string GetExceptionType(string content)
    {
        throw new NotImplementedException();
    }

    internal LogProcessedModel()
    {
    }
}