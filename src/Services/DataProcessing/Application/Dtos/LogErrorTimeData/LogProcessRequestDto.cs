namespace DataProcessing.Application.Dtos.LogErrorTimeData;
public class LogProcessRequestDto
{
    public string Content { get; private set; }
    public LogProcessRequestDto(string content)
    {
        Content = content;
    }
}