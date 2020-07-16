using UnityEngine;

public class Hacker : MonoBehaviour
{   // Game configuration data
    string[] level1Passwords = { "bow", "walls", "house", "wood", "fire", "naked"};
    string[] level2Passwords = {"sniper", "pistol", "granade", "terrorist", "assault"};
    string[] level3Passwords = {"objective", "payload", "widowmaker", "baptiste", "ultimate"};

    // "int level" = State of the Game, f.ex. lvl 1. Its a member variable because not declared in the Method itself, but above
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password; 

    void Start()
    { 
        ShowMainMenu("Hello Jake"); 
    }
    void Update()
    {
        int index1 = Random.Range (0, level1Passwords.Length);
        int index2 = Random.Range (0, level2Passwords.Length);
        int index3 = Random.Range (0, level3Passwords.Length);
    }
    void ShowMainMenu(string greeting)
    {   
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to Hack into?");
        Terminal.WriteLine("Press 1 for RUST");
        Terminal.WriteLine("Press 2 for CS GO");
        Terminal.WriteLine("Press 3 for OVERWATCH");
        Terminal.WriteLine("Enter your selection: ");
    }
    void OnUserInput(string input)
    {
        if (input == "Menu")
        {
        ShowMainMenu("Hello Jake");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input =="1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame ();
        }
        else if (input == "69") //Easter Egg
        {
            Terminal.WriteLine("haha, nice one, Daajake -.-");
        }
        else
        {
            Terminal.WriteLine("Select a valid Number or type 'Menu' to return to Menu");
        }
    }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
            int index1 = Random.Range (0, level1Passwords.Length);
            password = level1Passwords [index1]; 
            break;
            case 2:
            int index2 = Random.Range (0, level2Passwords.Length);
            password = level2Passwords [index2];
            break;
            case 3:
            int index3 = Random.Range (0, level3Passwords.Length);
            password = level3Passwords [index3];
            break;
            default: 
            Debug.LogError("No Schmeckles for you!");
            break;
        }
        Terminal.WriteLine("Please enter your password: "); 
    }
    void CheckPassword(string input)    
    {
        if (input == password)
            {
                Terminal.WriteLine("Welcome President Jake!");
                Terminal.WriteLine("Here are 5 Schmeckles!");
            }
        else if (input == "69")
            {
                Terminal.WriteLine("haha, very funny, Daajake -.-");
            }
        else 
            {
                Terminal.WriteLine("Nice one, loser... ");
                Terminal.WriteLine("No Schmeckles for you!");
            }
    }
 
}

