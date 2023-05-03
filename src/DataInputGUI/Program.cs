bool run = true;
while(run)
{
    System.Console.WriteLine("*** DataInputGUI ***");
    System.Console.WriteLine("1. Create Log");
    System.Console.WriteLine("2. Get All Logs");
    System.Console.WriteLine("3. Exit");
    System.Console.Write("Enter your choice: ");
    var choice = Convert.ToInt32(System.Console.ReadLine());

    switch (choice)
    {
        case 1:
            System.Console.Write("Enter log content: ");
            var content = System.Console.ReadLine();
            var client = new System.Net.Http.HttpClient();

            foreach(var log in content.Split(" "))
            {
                var response = await client.PostAsync("http://localhost:5026/datacollection",
                                                    new StringContent($"{{\"content\": \"{log}\"}}",
                                                                        System.Text.Encoding.UTF8,
                                                                        "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    System.Console.WriteLine("Log created successfully");
                }
                else
                {
                    System.Console.WriteLine("Error creating log");
                }
            }
            break;

        case 2:
            var client2 = new System.Net.Http.HttpClient();
            var response2 = await client2.GetAsync("http://localhost:5026/datacollection");
            if (response2.IsSuccessStatusCode)
            {
                var content2 = await response2.Content.ReadAsStringAsync();
                var logs = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<LogQueryResultDto>>(content2);
                foreach (var log in logs)
                {
                    System.Console.WriteLine($"Id: {log.Id}, Content: {log.Content}");
                }
            }
            else
            {
                System.Console.WriteLine("Error getting logs");
            }
            break;

        case 3:
            System.Console.WriteLine("Exiting...");
            run = false;
            break;
    }
}
public class LogQueryResultDto
{
    public int Id { get; set; }
    public string Content { get; set; }
}