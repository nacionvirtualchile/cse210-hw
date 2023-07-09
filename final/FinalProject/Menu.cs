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
    "5 - Display Sucriptions soon to collect",
    "6 - Display Expired Sucriptions:",
    "7 - Quit:" 
    };
    
//METHODS
    public void DisplayMainMenu() {
            foreach (string option in _listOfOptions){
            Console.WriteLine(option);
        }
    }
    public void DisplayServicesMenu() {
        
    }
    public void DisplayClientsMenu() {
        
    }
    public void DisplaySubscriptionsMenu() {
        
    }
    public void DisplayPaymentsMenu() {
        
    }
    public void DisplaySubscriptionSoonToCollect() {
        
    }
    public void DisplayExpiredSubscriptions() {
        
    }


    public int GetChoiceFromUser (){
        int choiceNumber = 0;
        string choice = Console.ReadLine();
        if (choice != ""){
            if (choice.All(char.IsNumber)){
            choiceNumber = int.Parse(choice);
            } else {
            Console.WriteLine("__________");
            Console.WriteLine("__________");
            Console.WriteLine("YOUR CHOICE IS NOT CORRECT");
            Console.WriteLine("TRY AGAIN PLEASE");
            Console.WriteLine("__________");
            Console.WriteLine("__________");
            }
        } else {
            Console.WriteLine("__________");
            Console.WriteLine("__________");
            Console.WriteLine("YOUR CHOICE IS NOT CORRECT");
            Console.WriteLine("TRY AGAIN PLEASE");
            Console.WriteLine("__________");
            Console.WriteLine("__________");
        }
        return choiceNumber;
    }

}
