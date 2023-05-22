using System.Diagnostics;
using System.Net.Http.Headers;
using DataInputSetup.AccessToken;

namespace DataInputSetup.Infrastructure;
public class SendLogsToApi
{
    private readonly System.Net.Http.HttpClient _client;

    public SendLogsToApi()
    {
        _client = new System.Net.Http.HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5051");
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken);
    }

    public async Task SendLogs(string logs)
    {
        var logsSentSuccessfully = false;
        System.Console.WriteLine("");
        // Split logs by new line
        // Send each log to the API
        foreach(var log in logs.Split("\n"))
        {
            var content = new StringContent($"{{\"content\": \"{log}\"}}", System.Text.Encoding.UTF8, "application/json");
            
            var response = await _client.PostAsync("/api/DataInput", content);

            if (response.IsSuccessStatusCode)
            {
                logsSentSuccessfully = true;
            }
            else
            {
                logsSentSuccessfully = false;
                System.Console.WriteLine("Error sending log");
                System.Console.WriteLine(response.StatusCode);
                System.Console.WriteLine(response.ReasonPhrase);
                System.Console.WriteLine(response.Content);
                System.Console.WriteLine(response.Headers);
                System.Console.WriteLine(response.RequestMessage);
                System.Console.WriteLine(response.Version);

                if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    System.Console.WriteLine("*** Unauthorized Access ***");
                    break;
                }
            }
        }
        if(logsSentSuccessfully)
        {
            System.Console.WriteLine(" *** Logs sent successfully! ***");
        }
        else
        {
            System.Console.WriteLine(" *** Error sending logs! ***");
        }
    }

    public async Task SendDockerLogs(object sender, DataReceivedEventArgs logs)
    {
        var logsSentSuccessfully = false;
        System.Console.WriteLine("");
        // Split logs by new line
        // Send each log to the API
        foreach(var log in logs.Data.Split("\n"))
        {
            var response = await _client.PostAsync("http://localhost:5051/api/DataInput",
                                                    new StringContent($"{{\"content\": \"{log}\"}}",
                                                                        System.Text.Encoding.UTF8,
                                                                        "application/json"));
            if (response.IsSuccessStatusCode)
            {
                logsSentSuccessfully = true;
            }
            else
            {
                logsSentSuccessfully = false;
                System.Console.WriteLine("Error sending log");
                System.Console.WriteLine(response.StatusCode);
                System.Console.WriteLine(response.ReasonPhrase);
                System.Console.WriteLine(response.Content);
                System.Console.WriteLine(response.Headers);
                System.Console.WriteLine(response.RequestMessage);
                System.Console.WriteLine(response.Version);
            }
        }
        if(logsSentSuccessfully)
        {
            System.Console.WriteLine(" *** Logs sent successfully! ***");
        }
        else
        {
            System.Console.WriteLine(" *** Error sending logs! ***");
        }
    }
}