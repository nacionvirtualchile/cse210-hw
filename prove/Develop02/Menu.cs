using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO; 


public class Menu
{

//Creativity and exceed: 
// In this class I also control if the user tries to LOAD a file that doesn't exist
// And also the program shows a message if the user tries to SAVE without any entries yet
// I add "-journal.txt" extension for LOAD and SAVE, so the user just put the first part of the file name 
// I add Welcome and Goodbye messages 
// I replace the comma delimiter for ; delimiter
// I add a first line in the Saved File with the names of the columns, and I avoid that line when the program Load the file 

    string _title = "Welcome to your Journal"; 
    string _description = "MENU - Please select one option:";
    string _answer = "";
    string[] _listOptions = new string[] {"1 - Write", "2 - Display", "3 - Load", "4 - Save", "5 - Quit"};
    int _optionInput = 1;

    RandomPrompt _prompt1 = new RandomPrompt();
    string _fileName = "";
    string[] _linesOfJournal;



    public void DisplayMenu() 
    {

        while (_optionInput >= 1 && _optionInput < 5 )
        {
            Console.WriteLine("_______________");
            Console.WriteLine("_______________");
            Console.WriteLine(_title);
            Console.WriteLine(_description);
            foreach (string option in _listOptions)
            {
                Console.WriteLine(option);
            }
            _answer = Console.ReadLine();
            _optionInput = int.Parse(_answer);
            ExecuteOption(_optionInput);
        } 
        Console.WriteLine("Have a nice day!");
        Console.WriteLine("______________________________________");
        Console.WriteLine("______________________________________");

    }

    public void ExecuteOption(int _optionInput)
    {

            if (_optionInput == 1) //Write
            {
                _prompt1.DisplayRandom();

            } else if (_optionInput == 2) //Display
            {
                //Console.WriteLine("ENTRÓ AL 2");
                String controlEmpty = "Empty"; 
                foreach (Response listOfResponse in _prompt1._listOfResponses)
                    {
                        Response response = new Response();
                        response.DisplayResponse(listOfResponse);
                        controlEmpty = "No Empty";
                    }
                if (controlEmpty == "Empty") 
                    {
                        Console.WriteLine("______________________________________");
                        Console.WriteLine("______________________________________");
                        Console.WriteLine("NO ENTRIES YET. Choose 1 to create one");
                        Console.WriteLine("______________________________________");
                        Console.WriteLine("______________________________________");
                    }
            } else if (_optionInput == 3) //Load
            {
                Console.WriteLine("Write the name of your file (**WITHOUT** '-journal.txt') to open it");
                _fileName = Console.ReadLine()+"-journal.txt";
                
                
                if (File.Exists(_fileName+"-journal.txt"))
                {
                    _linesOfJournal = System.IO.File.ReadAllLines(_fileName);
                    _prompt1._listOfResponses.Clear();
                    int Count = 0;
                    foreach (String lineOfResponse in _linesOfJournal)
                    {
                        if (Count == 0)
                        {
                            Count= 1;
                        } else
                        {
                            string[] parts = lineOfResponse.Split(";");
                            Response newTemporalResponse = new Response();
                            newTemporalResponse._date = parts[0];
                            newTemporalResponse._prompt = parts[1];
                            newTemporalResponse._answer = parts[2];
                            _prompt1._listOfResponses.Add(newTemporalResponse);
                        }

                        
                    }
                } else 
                {
                    Console.WriteLine("______________________________________");
                    Console.WriteLine("______________________________________");
                    Console.WriteLine("FILE DOESN'T EXIST");
                    Console.WriteLine("______________________________________");
                    Console.WriteLine("______________________________________");
                }




                    
            } else if (_optionInput == 4) //Save
            {
                Console.WriteLine("Write the name for your file (**WITHOUT** extension)");
                _fileName = Console.ReadLine()+"-journal.txt";
                using (StreamWriter outputFile = new StreamWriter(_fileName))
                    {
                        
                        String controlEmpty = "Empty"; 
                        outputFile.WriteLine("Date; Promt; Your answer");
                        foreach (Response listOfResponse in _prompt1._listOfResponses)
                        {
                            Response response = new Response();
                            response.WriteResponseFile(listOfResponse, outputFile);
                            controlEmpty = "No Empty";
                        }
                        if (controlEmpty == "Empty") 
                        {
                            Console.WriteLine("______________________________________");
                            Console.WriteLine("______________________________________");
                            Console.WriteLine("NO ENTRIES YET. Choose 1 to create one");
                            Console.WriteLine("______________________________________");
                            Console.WriteLine("______________________________________");
                        }

                    }
            }

        
    }

}
