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
        var logsSentSuccessfully = false;
        System.Console.WriteLine("");
        // Split logs by new line
        // Send each log to the API
        foreach(var log in logs.Split("\n"))
        {
            var response = await _client.PostAsync("http://localhost:5051/api/DataInput",
                                                    new StringContent($"{{\"content\": \"{log}\"}}",
                                                                        System.Text.Encoding.UTF8,
                                                                        "application/json"));
            if (response.IsSuccessStatusCode)
            {
                logsSentSuccessfully = true;
                System.Console.WriteLine($"*** {log} *** ");
            }
            else
            {

                System.Console.WriteLine("Error sending log");
                System.Console.WriteLine(response.StatusCode);
                System.Console.WriteLine(response.ReasonPhrase);
                System.Console.WriteLine(response.Content);
                System.Console.WriteLine(response.Headers);
                System.Console.WriteLine(response.RequestMessage);
                System.Console.WriteLine(response.Version);
            }
        }
        System.Console.WriteLine("");
        System.Console.WriteLine("");
        if(logsSentSuccessfully)
        {
            System.Console.WriteLine(" *** Logs sent successfully! ***");
        }
        else
        {
            System.Console.WriteLine(" *** Error sending logs! ***");
        }
        System.Console.WriteLine("");
        System.Console.ReadKey();
    }
}