namespace DataProcessing.Application.Dtos;
public class LogProcessRequestDto
{
    public int Id { get; private set; }
    public string Content { get; private set; }
    public LogProcessRequestDto(string content)
    {
        Content = content;
    }
}