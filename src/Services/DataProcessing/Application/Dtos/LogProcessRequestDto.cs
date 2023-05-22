namespace DataProcessing.Application.Dtos;
public class LogProcessRequestDto
{
    public string Content { get; private set; }
    public LogProcessRequestDto(string content)
    {
        Content = content;
    }
}