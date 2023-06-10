using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Activity
{
//MEMBER VARIABLES
    private string _nameActivity;
    private string _description;
    private int _duration;
    string _loadingbar = "";


//CONSTRUCTORS
    public Activity() {}


//GETTER - SETTER
    public string GetNameActivity(){
        return _nameActivity;
    }
    public string GetDescription(){
        return _description;
    }
    public int GetDuration(){
        return _duration;
    }
    public void SetNameActivity(string name) {
        _nameActivity = name;
    }

    public void SetDescription(string description) {
        _description = description;
    }
    
    public void SetDuration(int seconds) {
        _duration = seconds;
    }


//METHODS
    public void DisplayStartingMessage(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_nameActivity}.");
        Console.WriteLine("");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("");
        Console.WriteLine("Well done!!");
        Pausing("spinner", 4);
        Console.WriteLine("");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_nameActivity}.");
        Pausing("spinner", 4);
    }

    public void Pausing(string type, int secondsToPuase){
        if (type == "countdown"){

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(secondsToPuase);

            int count = secondsToPuase;
            while (startTime < futureTime)
            {
                Console.Write(count);
                Thread.Sleep(1000);
                if (count < 10) {
                    Console.Write("\b \b");
                } else {
                    Console.Write("\b\b  \b\b");
                }
                

                startTime = DateTime.Now;
                count -= 1;
            }



        } 
        //I REPLACE SPINNER WITH THIS "LOADING BAR"  
        else if (type == "loading"){ 

            Console.WriteLine("");

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(secondsToPuase/2);
            double div1 = ((double)secondsToPuase*(double)1000)/(double)100;
            int div2 = Convert.ToInt32(div1);
            while (startTime < futureTime)
            {
                Console.Write("|");
                Thread.Sleep(div2);
                startTime = DateTime.Now;
                
            }

            DateTime startTime2 = DateTime.Now;
            DateTime futureTime2 = startTime2.AddSeconds(secondsToPuase/2);
            while (startTime2 < futureTime2)
            {
                Console.Write("\b \b");
                Thread.Sleep(div2);
                startTime2 = DateTime.Now;
                
            }

            Console.WriteLine("");


        }  else if (type == "loadBar") {

            DateTime startTime = DateTime.Now;
            DateTime futureTime = startTime.AddSeconds(secondsToPuase);
            double div1 = ((double)secondsToPuase*(double)1000)/(double)100;
            int div2 = Convert.ToInt32(div1);

            _loadingbar = "";
            while (startTime < futureTime)
            {
                _loadingbar += "|";
                Console.Write("|");
                Thread.Sleep(div2);
                startTime = DateTime.Now;
                
            }

        } else if (type == "removeBar") {
        

            DateTime startTime2 = DateTime.Now;
            DateTime futureTime2 = startTime2.AddSeconds(secondsToPuase);
            double div1 = ((double)secondsToPuase*(double)1000)/(double)100;
            int div2 = Convert.ToInt32(div1);

            Console.Write(_loadingbar);
            while (startTime2 < futureTime2)
            {
                Console.Write("\b \b");
                Thread.Sleep(div2);
                startTime2 = DateTime.Now;
                
            }


        } else if (type == "spinner") {

            List<string> symbolsToSpinner = new List<string>();
            symbolsToSpinner.Add("|");
            symbolsToSpinner.Add("/");
            symbolsToSpinner.Add("-");
            symbolsToSpinner.Add("\\");

            
            DateTime futureTime = DateTime.Now.AddSeconds(secondsToPuase);

            int count = 0;
            while (DateTime.Now < futureTime)
            {
                string symbol = symbolsToSpinner[count];
                Console.Write(symbol);
                Thread.Sleep(1000);
                Console.Write("\b\b  \b\b");
                
                count++;

                if (count >= symbolsToSpinner.Count) {
                    count = 0;
                }
                
            }

        }
    }

}
