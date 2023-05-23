using Monitor.UI;

var ui = new UserInterface();

System.Console.Clear();

bool run = true;
while(run)
{
    ui.WelcomeScreen();
    var choice = ui.Menu();
    switch (choice)
    {
        case "1":
            System.Console.WriteLine("Not implementeted yet!");
            break;
        case "2":
            System.Console.WriteLine("Not implementeted yet!");
            break;
        case "3":
            System.Console.WriteLine("Not implementeted yet!");
            break;
        case "4":
            System.Console.WriteLine("*** Exiting ***.");
            System.Console.WriteLine("Do you wish to continue? (y/n)");
            var exitChoice = System.Console.ReadLine();
            if(exitChoice == "y")
            {
                run = false;
            }
            break;
        default:
            System.Console.WriteLine("*** Invalid choice! ***");
            break;
    }
}