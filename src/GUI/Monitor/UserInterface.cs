namespace Monitor.UI;
public class UserInterface
{
    public void WelcomeScreen()
    {
        
        System.Console.WriteLine(
    @"
    __               _       ___           __  _____ 
   / /   ____  ____ | |     / (_)_______  /  |/  / / 
  / /   / __ \/ __ `/ | /| / / / ___/ _ \/ /|_/ / /  
 / /___/ /_/ / /_/ /| |/ |/ / (__  )  __/ /  / / /___
/_____/\____/\__, / |__/|__/_/____/\___/_/  /_/_____/
            /____/                                   
    Monitor Application // Version 0.1");
    }


    public string Menu()
    {
        System.Console.WriteLine(
        @"
        *********** MENU ************
        
        1) Status
        2) Analysis Reports 
        3) See Data Streams 
        4) Exit
        
        *****************************
        ");                                     
        System.Console.Write("Enter choice: ");
        var choice = System.Console.ReadLine();
        return choice;
    }
}