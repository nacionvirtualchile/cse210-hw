using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ListingActivity : Activity
{
    
//MEMBER VARIABLES
    private string[] _listOfPrompts = new string[]{
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?"
    };
    private int _countItems;
    private Random _randomNumber = new Random();


//CONSTRUCTORS
    public ListingActivity() {
        base.SetNameActivity("Listing Activity");
        base.SetDescription("This activity will help you reflect on the good things in your life by creating your own list of the following questions.");
    }

//GETTER - SETTER
    public void SetCountItems(int count){
        _countItems = count;
    }
    public int GetCountItems(){
        return _countItems;
    }


//METHODS
    public string GetRandomPrompt(){
        int count = _listOfPrompts.Count();
        return _listOfPrompts[_randomNumber.Next(count-1)];
    } 




}
