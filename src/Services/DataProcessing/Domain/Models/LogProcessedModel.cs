namespace DataProcessing.Domain.Models;
public class LogProcessedModel
{
    public int Id { get; private set; }
    public string MLType { get; private set; } // The type of dataset the log is processed into to be used for ML
    public DateTime Timestamp { get; private set; }
    public bool Error { get; private set; }

    public LogProcessedModel(string mlType, string content)
    {
        MLType = mlType;
        Timestamp = GetTimestamp(content);
        Error = GetError(content);
    }

    private bool GetError(string content)
    {
        if(content.ToUpper().Contains("ERROR"))
        {
            return true;
        }
        return false;
    }

    private DateTime GetTimestamp(string content)
    {
        DateTime timestamp = DateTime.Parse(content.Substring(0, 30));
        return timestamp;
    }

    internal LogProcessedModel()
    {
    }
}