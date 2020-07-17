using UnityEngine;

public class Hacker : MonoBehaviour
{   // Game configuration data
    string[] level1Passwords = { "bow", "beach", "house", "rock", "fire", "naked"};
    string[] level2Passwords = {"sniper", "pistol", "granade", "terrorist", "assault"};
    string[] level3Passwords = {"objective", "payload", "widowmaker", "rocketbarrage", "ultimate"};

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
        Terminal.WriteLine("Where would you like to hack into?");
        Terminal.WriteLine("Press 1 for RUST");
        Terminal.WriteLine("Press 2 for COUNTERSTRIKE");
        Terminal.WriteLine("Press 3 for OVERWATCH");
    }
    void OnUserInput(string input)
    {
        if (input == "Menu")
        {
        ShowMainMenu("Hello Jake");
        }
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Application.Quit();
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
        Terminal.WriteLine("Enter your password or go back to 'Menu' if you're chicken...");
        Terminal.WriteLine("hint: " + password.Anagram()); 
    }
    void CheckPassword(string input)    
    {
        if (input == password)
            {
                DisplayWinScreen();           
            }
        else if (input == "69")
            {
                Terminal.WriteLine("haha, very funny, Daajake -.-");
            }
        else 
            {
                Terminal.WriteLine("Nice one, loser... No Schmeckles for you! Try again: ");

            }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
             Terminal.WriteLine("Wooow! Wake up naked Jake!");
             Terminal.WriteLine("Here are ");
             Terminal.WriteLine(@"

     :  *   10   *  :
    : ~ Schmeckles ~ :
           ...
    ~  and a hatchet ~
            .
            .
            .
    go back to Manu and try lvl 2!
           "
            );
            break;
            case 2:
             Terminal.WriteLine("Welcome Officer Jake!");
             Terminal.WriteLine("Here are ");
             Terminal.WriteLine(@"

        .-'''''-.
      .'  * * *  `.
     :  *  100  *  :
    : ~Schmecklezz~ :
    : ~  $$$$$$$  ~ :
     :  *  $$$  *  :
      `.  * * *  .'
        `-.....-'   
    ~  and some ammo! ~
            .
            .
            .
    go back to Manu and try lvl 3!
          "                        
            );
            break;
            case 3:
             Terminal.WriteLine("Welcome your Majesty, King Jake!");
             Terminal.WriteLine("Here is you grand Pri$e!");
             Terminal.WriteLine(@"
     _______________
    |$$$$|     |$$$$|
    |$$$$|     |$$$$|
    |$$$$|     |$$$$|
    \$$$$|     |$$$$/
     \$$$|     |$$$/
      `$$|_____|$$'
           (O)
        .-'''''-.
      .'  * * *  `.
     :  1.000.000  :
    : ~SCHMECKLES!~ :
    : ~  $$$$$$$  ~ :
     :  *  $$$  *  :
      `.  * * *  .'
        `-.....-'   
        
       ~ Victory! ~
             .
             .
             .
 Go back to 'Menu' or type 'exit' to leave the game!

        " 
         );
         break;
         default: 
         Debug.LogError("Invalid level reached!");
         break;
        }
       
    }
}

