using DataInputSetup.UI;
using DataInputSetup.Commands;
using DataInputSetup.Infrastructure;

var ui = new UserInterface();
var apiConn = new SendLogsToApi();
var connections = new List<string>();
IList<DockerContainerReg> dockerContainerRegs = new List<DockerContainerReg>();

System.Console.Clear();

bool run = true;
while(run)
{
    ui.WelcomeScreenAltern();
    var choice = ui.Menu();
    switch (choice)
    {
        case "1":
            System.Console.WriteLine("Not implementeted yet!");
            break;
        case "2":
            var dockerContainerId = ui.DockerContainerSetup();
            connections.Add(dockerContainerId);
            System.Console.WriteLine("*** Registering Docker Container... ***");
            dockerContainerRegs.Add(new DockerContainerReg(dockerContainerId));
            dockerContainerRegs.Last().GetLogsAsync();
            System.Console.WriteLine("*** Docker Container registered successfully! ***");
            System.Console.WriteLine("");
            System.Console.WriteLine("*** Press any key to continue... ***");
            System.Console.ReadKey();
            break;
        case "3":
            System.Console.WriteLine("Running connections:");
            foreach(var connection in connections)
            {
                System.Console.WriteLine(connection);
            }
            break;

        case "4":
            System.Console.WriteLine("This action will stop running connections.");
            System.Console.WriteLine("Do you wish to continue? (y/n)");
            var exitChoice = System.Console.ReadLine();
            if(exitChoice == "y")
            {
                run = false;
                System.Console.WriteLine("*** Stopping running connections... ***");
            }
            break;
        default:
            System.Console.WriteLine("*** Invalid choice! ***");
            break;
    }
}