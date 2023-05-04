namespace DataProcessing.Domain.Models;
public class LogProcessedModel
{
    public int Id { get; private set; }
    // The type of dataset the log is processed into to be used for ML
    public string MLType { get; private set; }
    public string Content { get; private set; }

    public LogProcessedModel(string mlType, string content)
    {
        MLType = mlType;
        Content = content;
    }
}