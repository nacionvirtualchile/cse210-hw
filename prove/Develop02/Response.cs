using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO; 


public class Response
{
    public string _date = "";
    public string _prompt;
    public string _answer;


    public void DisplayResponse(Response response) 
    {
        Console.WriteLine("Date: " + response._date + " - Promt: " + response._prompt);
        Console.WriteLine("Your answer: " + response._answer);
    }

    public void WriteResponseFile(Response response, StreamWriter outputFile) 
    {
        outputFile.WriteLine(response._date + ";" + response._prompt+ ";" + response._answer);
    }

}
