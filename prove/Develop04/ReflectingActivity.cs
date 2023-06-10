using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class ReflectingActivity : Activity
{
//MEMBER VARIABLES
    private string[] _listOfPrompts = new string[]{
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."
    };
    private string[] _listOfQuestions= new string[]{
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    };
    //private string[] _listOfUsedQuestions;
    private Random _randomNumber = new Random();


//CONSTRUCTORS
    public ReflectingActivity() {
        base.SetNameActivity("Reflecting Activity");
        base.SetDescription("This activity will help you reflect on times in your life when you have shown stregth and resilience. This will help you recognize the power you have and how you can use it in othr aspect of your life.");
    }


//METHODS
    public string GetRandomPrompt(){
        int count = _listOfPrompts.Count();
        return _listOfPrompts[_randomNumber.Next(count-1)];
    } 

    public string GetRandomQuestion(){
        int count = _listOfQuestions.Count();
        return _listOfQuestions[_randomNumber.Next(count-1)];
    } 


}
