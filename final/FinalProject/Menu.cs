using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Menu
{
//VARIABLES

    private string[] _listOfOptions = new string[] {
    "1 - Services Menu", 
    "2 - Clients Menu", 
    "3 - Subscriptions Menu", 
    "4 - Payment Menu",
    "5 - Display Subscriptions soon to collect",
    "6 - Display Expired Subscriptions:",
    "7 - Quit:" 
    };

    private string[] _listOfOptionsServices = new string[] {
    "1 - Create a service", 
    "2 - Change a service", 
    "3 - List services", 
    "4 - Return:" 
    };    

    private string[] _listOfOptionsClients = new string[] {
    "1 - Create a client", 
    "2 - Change a client", 
    "3 - List client", 
    "4 - Return:" 
    };    

    private string[] _listOfOptionsSubscriptions = new string[] {
    "1 - Create a Subscription", 
    "2 - Change a Subscription", 
    "3 - List Subscriptions", 
    "4 - Return:" 
    }; 

    private string[] _listOfOptionsPayments = new string[] {
    "1 - Record a Payment", 
    "2 - Change a Payment", 
    "3 - List Payment", 
    "4 - Return:" 
    }; 



//METHODS
    public void DisplayMainMenu() {
        foreach (string option in _listOfOptions){
            Console.WriteLine(option);
        }
    }
    public void DisplayServicesMenu() {
        foreach (string option in _listOfOptionsServices){
            Console.WriteLine(option);
        }
    }
    public void DisplayClientsMenu() {
        foreach (string option in _listOfOptionsClients){
            Console.WriteLine(option);
        }
    }
    public void DisplaySubscriptionsMenu() {
        foreach (string option in _listOfOptionsSubscriptions){
            Console.WriteLine(option);
        }   
    }
    public void DisplayPaymentsMenu() { 
        foreach (string option in _listOfOptionsPayments){
        Console.WriteLine(option);        
        }
    }



    public int GetChoiceFromUser (int min, int max)
    {
        int choiceNumber = 0;
        string choice = Console.ReadLine();
        Boolean Notfinish = true;

        while (Notfinish) 
        {
            if (choice != "")
            {
                if (choice.All(char.IsNumber))
                {
                    choiceNumber = int.Parse(choice);
                    if (choiceNumber >= min && choiceNumber <= max)
                    {
                        Notfinish = false;
                    }
                }
            }
            
            if (Notfinish == true) 
            {
                Console.WriteLine("__________");
                Console.WriteLine("YOUR ENTER IS NOT CORRECT");
                Console.Write("TRY AGAIN PLEASE: ");
                choice = Console.ReadLine();
            }

        }

        return choiceNumber;
    }


    public string GetTextFromUser(){
        string textFromUser = "";
        string input = Console.ReadLine();
        Boolean Notfinish = true;

        while (Notfinish) {
            if (input != ""){
                textFromUser = input;
                Notfinish = false;
            } else {
                Console.WriteLine("__________");
                Console.WriteLine("YOUR MUST ENTER A TEXT");
                Console.Write("TRY AGAIN, PLEASE:");
                input = Console.ReadLine();
            }
        }

        return textFromUser;
    }


    public int GeneralControlInputNumber()
    {
        int choiceNumber = 0;
        string choice = Console.ReadLine();
        Boolean NotFinish = true;

        while (NotFinish) 
        {
            if (choice != "" && choice != "0")
            {
                if (choice.All(char.IsNumber))
                {
                    choiceNumber = int.Parse(choice);
                    NotFinish = false;
                }
                if (NotFinish == true) 
                {
                    Console.WriteLine("__________");
                    Console.WriteLine("YOUR ENTER IS NOT CORRECT");
                    Console.Write("TRY AGAIN PLEASE: ");
                    choice = Console.ReadLine();
                }
            } else {
                choiceNumber = 0;
                NotFinish = false;
            }

        }

        return choiceNumber;
    }



}
