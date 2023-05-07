namespace DataProcessing.Application.Dtos;
public class LogCreateRequestDto
{
    public string ProcessedContent { get; private set; }
    public LogCreateRequestDto(string processedContent)
    {
        ProcessedContent = processedContent;
    }
}