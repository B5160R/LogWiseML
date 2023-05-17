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
    public void WelcomeScreenAltern()
    {
        
        System.Console.WriteLine(
    @"
    __               _       ___           __  _____ 
   / /   ____  ____ | |     / (_)_______  /  |/  / / 
  / /   / __ \/ __ `/ | /| / / / ___/ _ \/ /|_/ / /  
 / /___/ /_/ / /_/ /| |/ |/ / (__  )  __/ /  / / /___
/_____/\____/\__, / |__/|__/_/____/\___/_/  /_/_____/
            /____/                                   
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
        
        *****************************
        ");                                     
        System.Console.Write("Enter choice: ");
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