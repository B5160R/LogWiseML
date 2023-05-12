namespace DataProcessing.Domain.Models;
public class LogProcessedModel
{
    public int Id { get; private set; }
    public string MLType { get; private set; } // The type of dataset the log is processed into to be used for ML
    public DateTime Timestamp { get; private set; }
    public string LogMessage { get; private set; }
    public string ExceptionType { get; private set; }
    public bool Error { get; private set; }
    public bool Warning { get; private set; }
    public string FaultyCodePlacement { get; private set; }

    // public string LogSeverity { get; private set; }
    // public string ErrorStatus { get; private set; }
    // public string ErrorType { get; private set; }
    
    public LogProcessedModel(int id, string mlType, string content)
    {
        Id = id;
        MLType = mlType;

        Timestamp = GetTimestamp(content);
        LogMessage = GetLogMessage(content);
        ExceptionType = GetExceptionType(content);
        Error = IsError(content);
        Warning = IsWarning(content);
        FaultyCodePlacement = GetCodePlacement(content);

        // LogSeverity = GetLogSeverity(content);
        // ErrorStatus = GetErrorStatus(content);
        // ErrorType = GetErrorType(content);
    }

    private DateTime GetTimestamp(string content)
    {
        //2023-05-10T09:01:57.785041915Z
        DateTime timestamp = DateTime.Parse(content.Substring(0, 30));
        return timestamp;
    }

    private string? GetLogMessage(string content)
    {
        return content.Substring(31);
    }

    private bool IsError(string content)
    {
        if(content.Contains("ERROR") || content.Contains("error"))
        {
            return true;
        }
        return false;
    }

    private bool IsWarning(string content)
    {
        if(content.Contains("WARNING") || content.Contains("warning"))
        {
            return true;
        }
        return false;
    }

    private string GetExceptionType(string content)
    {
        if(content.Contains("Exception"))
        {
            return content.Substring(31, content.IndexOf(":") - 31);
        }
        return "No Exception";
    }

    private string GetCodePlacement(string content)
    {
        if(content.Contains(".cs:line"))
        {
            return content.Substring(content.IndexOf(".cs:line") - 1);
        }
        return "No Code Placement";

    }

    private string? GetErrorType(string content)
    {
        throw new NotImplementedException();
    }

    private string? GetErrorStatus(string content)
    {
        throw new NotImplementedException();
    }


    private string? GetLogSeverity(string content)
    {
        throw new NotImplementedException();
    }

    internal LogProcessedModel()
    {
    }
}