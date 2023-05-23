namespace DataProcessing.Application.Dtos.LogErrorTimeData;
public class LogQueryResultDto
{
    public int Id { get; set; }
    public string MLType { get; set; }
    public DateTime Timestamp { get; set; }
    public bool Error { get; set; }

    public LogQueryResultDto(int id, string mlType, DateTime timestamp, bool error)
    {
        Id = id;
        MLType = mlType;
        Timestamp = timestamp;
        Error = error;;
    }
}