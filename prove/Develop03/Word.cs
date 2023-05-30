using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Word
{
    // This variable will recieve all the original words, and then I will eliminate words from here
    // so I will know how many words left 
    private string[] _WordsToEliminate;

    //This will recieve all the original words, and I will replace them with '_' 
    private string[] _WordsToDisplay;

    private string _reference;


// CONSTRUCTOR to create the member variables
    public Word(string scripture, string name) {
        _WordsToDisplay = scripture.Trim().Split(" ");
        _WordsToEliminate = scripture.Trim().Split(" ");
        _reference = name;
    
    }


    public string HidenWord(){
        
        string quit;

        //Here I create a random number between 0 and the quantity of words
        int _randomNumber = new Random().Next(_WordsToEliminate.Length-1);

        //I use the randomnumber to select a word of _WordsToEliminate, and I search the index o that word in _WordsToDisplay
        int indexToChange = Array.IndexOf(_WordsToDisplay, _WordsToEliminate[_randomNumber]);

        // I determine the lenght of the word
        int word_lenght = _WordsToDisplay[indexToChange].Length;

        // and I replace hat word with "" and then with "_" characters (the same lenght)
        int count = 0;
        _WordsToDisplay[indexToChange] = "";
        while (count < word_lenght){
            _WordsToDisplay[indexToChange] += "_";
            count += 1;
        }

// // string TESTvr = _WordsToEliminate[_randomNumber];
        // then I eliminate the word in _WordsToEliminate
        _WordsToEliminate = _WordsToEliminate.Where((e, i) => i != _randomNumber).ToArray();



        // here I control if the words are over.
        if (_WordsToEliminate.Length <= 0) {
            quit = "quit";
// // Console.WriteLine($"ENTRO A QUIT. _WordsToEliminate.Length: {_WordsToEliminate.Length} {indexToChange} {TESTvr} {_randomNumber}");
        } else {
            quit = "";
// // Console.WriteLine($"nooo entró a quit aún. _WordsToEliminate.Length: {_WordsToEliminate.Length} {indexToChange} {TESTvr} {_randomNumber}");
        }
        return quit;

    }


    public void DisplayWords(){
        
        Console.WriteLine("----------------------------");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("----------------------------");
        
        Console.WriteLine($"Reference: {_reference}");
        Console.Write("Scripture: ");

        // I show the entire modified verse
        foreach (string line in _WordsToDisplay) {
            Console.Write(line + " ");
        }
        
        Console.WriteLine();

    }


}