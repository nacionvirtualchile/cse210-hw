using System;

class Program
{
 

    static void Main(string[] args)
    {

        //Code to display the menu with 3 options: 
        //Option 1: to display the scripture to memorize
        //Option 2: to store a new scripture in a FILE: Scriptures.txt
        //Option 3: to quit
        string input1 = "";
        while (input1 != "quit"){

            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Best Scripture Memorizer!");
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Type an option (example: 1)");
            Console.WriteLine("1 - Start to memorize a random scripture");
            Console.WriteLine("2 - Store a new escripture");
            Console.WriteLine("3 - to finish the program");
            input1 = Console.ReadLine();
            
            if (input1 == "1"){
                string input2 = "";

                //To instantiate the Scripture class to show the first one
                Scripture scripture = new Scripture();
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("----------------------------");
                Console.WriteLine($"Reference: {scripture.GetNameScripture()}");
                Console.WriteLine($"Scripture: {scripture.GetTextScripture()}");
                Console.WriteLine();
                Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
                input1 = Console.ReadLine();

                //To instantiate the Word class to hide words
                Word newWords = new Word(scripture.GetTextScripture(), scripture.GetNameScripture());
                while (input1 != "quit" && input2 != "quit"){
                    
                    //To eliminate 3 words
                    int count = 0;
                    while (input1 != "quit" && count < 3 && input2 != "quit") {
                        Console.Clear();
                        input2 = newWords.HidenWord();
                        newWords.DisplayWords();
                        count += 1;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
                    input1 = Console.ReadLine();

                }

            //To store a new scripture   
            } else if (input1 == "2") {
                //To instantiate the Scripture class to use the method SaveScripture 
                //To instantiate Reference class to format the name to save
                Scripture scripture = new Scripture();
                Reference reference = new Reference();

                Console.WriteLine("----------------------------");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Enter the follow info:");
                Console.Write("Enter the book:");
                reference.SetBook(Console.ReadLine());
                Console.Write("Enter the chapter:");
                reference.SetChapter(Console.ReadLine());
                Console.Write("Enter the verse:");
                reference.SetVerse(Console.ReadLine());
                Console.Write("Enter the text of the scripture:");
                
                string ReferenceName = reference.GetFormatNameToSave();
                string TextScripture = Console.ReadLine();
                

                scripture.SaveScripture(ReferenceName, TextScripture);
                

            } else {
                input1 = "quit";
            } 

        }




        
        Console.WriteLine("----------------------------");
        Console.WriteLine("That is all, have a nice day!!");
        Console.WriteLine("----------------------------");
        Console.WriteLine("----------------------------");
        
    }




}