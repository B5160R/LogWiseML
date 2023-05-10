namespace DataInputSetup.UI;
public class UserInterface
{
    public void WelcomeScreen()
    {
        System.Console.Clear();
        System.Console.WriteLine(
    @"
            _____   ______ _  _  _ _____ _______ _______ _______       
    |      |     | |  ____ |  |  |   |   |______ |______ |  |  | |     
    |_____ |_____| |_____| |__|__| __|__ ______| |______ |  |  | |_____    

    Data Stream Setup // Version 1.0");
    }
    public string Menu()
    {
        System.Console.WriteLine(
        @"
        *********** MENU ************
        
        1) Setup Access
        2) Register Docker Container
        3) See Running Connections
        4) Stop Running Connections
        
        *****************************");                                     
        System.Console.Write(@"
        Enter your choice: ");
        var choice = System.Console.ReadLine();
        return choice;
    }

    public string DockerContainerSetup()
    {
        System.Console.WriteLine("Enter Docker Container ID: ");
        var dockerContainerId = System.Console.ReadLine();
        return dockerContainerId;
    }
}