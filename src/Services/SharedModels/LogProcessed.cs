namespace SharedModels;
public class LogProcessed
{
    public int Id { get; set; }
    // The type of dataset the log is processed into to be used for ML
    public string MLType { get; set; }
    public string Content { get; set; }
}