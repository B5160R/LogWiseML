
namespace DataCollection.Application.Dtos;
public class LogCreateRequestDto
{
    public string Content { get; private set; }
    public LogCreateRequestDto(string content)
    {
        Content = content;
    }
}