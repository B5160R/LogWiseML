namespace DataProcessing.Application.Dtos;
public class LogSendToAnalysisDto
{
    public string MLType { get; set; } // The type of dataset the log is processed into to be used for ML
    public DateTime Timestamp { get; set; }
}