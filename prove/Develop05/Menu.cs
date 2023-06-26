using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Menu
{

//MEMBER VARIABLES
    private int _totalPoints = 0;
    private string[] _listOptions = new string[] {
    "1 - Create New Goal", 
    "2 - List Goals", 
    "3 - Save Goals", 
    "4 - Load Goals",
    "5 - Record Event",
    "6 - Quit" 
    };

    private string[] _listKindOfGoals = new string[] {
    "1 - Simple Goal", 
    "2 - Eternal Goal", 
    "3 - Checklist Goal"
    };

//SETTER-GETTER
    public int GetTotalPoints (){
        return _totalPoints;
    }
    public void SetTotalPoints (int totalPoints){
        _totalPoints = totalPoints;
    }

//METHODS
    public void DisplayMenu(){
        Console.WriteLine($"You have {_totalPoints} points.");
        Console.WriteLine("");
        Console.WriteLine("Menu Options");

        foreach (string option in _listOptions){
            Console.WriteLine(option);
        }
    }

    public void DisplayKinsOfGoals (){
        Console.WriteLine("The types of Goals are:");
        foreach (string option in _listKindOfGoals){
            Console.WriteLine(option);
        }
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

    public int GetChoiceFromUserRecordEvent (){
        int choiceNumber = 0;
        string choice = Console.ReadLine();
        if (choice != ""){
            if (choice.All(char.IsNumber)){
            choiceNumber = int.Parse(choice)-1;
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
