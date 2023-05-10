namespace DataInputSetup.Infrastructure;
public class SendLogsToApi
{
    private readonly System.Net.Http.HttpClient _client;

    public SendLogsToApi()
    {
        _client = new System.Net.Http.HttpClient();
    }

    public async Task SendLogs(string logs)
    {
        foreach(var log in logs.Split("/n"))
        {
            var response = await _client.PostAsync("http://localhost:5026/datacollection",
                                                new StringContent($"{{\"content\": \"{log}\"}}",
                                                                    System.Text.Encoding.UTF8,
                                                                    "application/json"));
            if (response.IsSuccessStatusCode)
            {
                System.Console.WriteLine("Log sent successfully");
            }
            else
            {
                System.Console.WriteLine("Error sending log");
            }
        }
    }
}