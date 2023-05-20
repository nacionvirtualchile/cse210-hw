using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class RandomPrompt
{

//Creativity and exceed: 
// I created a way to avoid the prompts repeat, so the program eliminate the used prompt, 
//and when the list of prompts is over, the program charge the list again  

    List<String> _randomPrompt1 = new List<String>()
    {
    "Just one line!, for example, How did you feel this morning?",
    "You can do it!, for example, Did you remember the Gospel or Christ today? Why?",
    "One more time!, for example, How part of your day did you like it?",
    "Welcome again!, something important or different to write about today?",
    "Just something short!, How do you feel now? Why"
    };

    public List<Response> _listOfResponses  = new List<Response>();

    Random _randomNumber = new Random();
    int range = 4;

    

    public void DisplayRandom()
    {
        
        int _randomNumber2 = _randomNumber.Next(range);
        Console.WriteLine(_randomPrompt1[_randomNumber2]);
        Console.Write("Your answer: ");
        string stringInput = Console.ReadLine();

        Response newResponse = new Response();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();

        newResponse._date = dateText;
        newResponse._prompt = _randomPrompt1[_randomNumber2];
        newResponse._answer = stringInput;

        _listOfResponses.Add(newResponse);

        _randomPrompt1.RemoveAt(_randomNumber2);
        range = range - 1;

        if (range < 0) 
        {
            range = 4;
            _randomPrompt1.Add("Just one line!, for example, How did you feel this morning?");
            _randomPrompt1.Add("You can do it!, for example, Did you remember the Gospel or Christ today? Why?");
            _randomPrompt1.Add("One more time!, for example, How part of your day did you like it?");
            _randomPrompt1.Add("Welcome again!, something important or different to write about today?");
            _randomPrompt1.Add("Just something short!, How do you feel now? Why");

        }
        
    }



    
}
