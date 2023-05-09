namespace DataProcessing.Application.Dtos;
public class LogProcessRequestDto
{
    public int Id { get; private set; }
    public string Content { get; private set; }
    public LogProcessRequestDto(int id, string content)
    {
        Id = id;
        Content = content;
    }
}