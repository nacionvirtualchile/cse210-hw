using System;

class Program
{
 

    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("----------------------------");
        Console.WriteLine("----------------------------");
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("----------------------------");

        Scripture scripture = new Scripture();
        Console.WriteLine($"Reference: {scripture.GetNameScripture()}");
        Console.WriteLine($"Scripture: {scripture.GetTextScripture()}");

        Word newWords = new Word(scripture.GetTextScripture(), scripture.GetNameScripture());

        string _action = "";
        while (_action!= "quit"){
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            _action = Console.ReadLine();

            int count = 0;
            while (_action!= "quit" && count < 3) {
                Console.Clear();
                _action = newWords.HidenWord();
                newWords.DisplayWords();
                count += 1;
            }
            
            
        }
        
        Console.WriteLine("----------------------------");
        Console.WriteLine("That is all, have a nice day!!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("----------------------------");
        
    }




}