using System;

class Program
{

//Exceeding Requirements:
//        - I create the followin animations:
//                - spinner
//                - countdown
//                - loading for "Get Ready" part (shows a bar that increases and decreases)
//                - LoadBar for breathing activity (shows a bar that increases when people breathe IN)
//                - LoadBar for breathing activity (shows a bar that decreases when people breath OUT)
//        - The program controls the time of activity: 
//                - if the user input more than 35 seconds, the program sets it to 35 and shows a message saying that
//                - if the user input less than 10 seconds, the program sets it to 10 and shows a message saying that


    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop04 World!");
        string[] _listOptions = new string[] {
            "1 - Start breathing activity", 
            "2 - Start reflecting activity", 
            "3 - Start listing activity", 
            "4 - Quit" 
            };
        int _optionInput = 0;
        string _answer;
        


//MENU
        while (_optionInput != 4)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mindfulness Program");
            Console.WriteLine("_______________");
            Console.WriteLine("Menu Options:");

            foreach (string option in _listOptions)
            {
                Console.WriteLine(option);
            }
            _answer = Console.ReadLine();
            _optionInput = int.Parse(_answer);
            
            
            if (_optionInput == 1) //Breathing
            {
                BreathingActivity breathingActivity1 = new BreathingActivity();
                breathingActivity1.DisplayStartingMessage();
                Console.WriteLine("");

                AskTimeUser(breathingActivity1);
                GetReady(breathingActivity1);

                breathingActivity1.LoopBreathe();
                breathingActivity1.DisplayEndingMessage();

            } else if (_optionInput == 2) //Reflecting
            {
                ReflectingActivity reflectingActivity1 = new ReflectingActivity();
                reflectingActivity1.DisplayStartingMessage();
                Console.WriteLine("");

                AskTimeUser(reflectingActivity1);
                GetReady(reflectingActivity1);
                Console.WriteLine("Consider the following prompt:");
                Console.Write("--- ");
                Console.Write(reflectingActivity1.GetRandomPrompt());
                Console.Write(" ---");
                Console.WriteLine("");
                
                Console.WriteLine("When you have something in mind, press enter to coninue.");
                Console.ReadLine();
                Console.WriteLine("Now ponder 10 seconds on each of the following questions as they related to this experience.");
                reflectingActivity1.Pausing("countdown", 5);
                Console.Clear();
                
                DateTime startTime = DateTime.Now;
                DateTime futureTime = startTime.AddSeconds(reflectingActivity1.GetDuration());

                while (startTime < futureTime) {
                    Console.WriteLine(reflectingActivity1.GetRandomQuestion());
                    reflectingActivity1.Pausing("spinner", 10);
                    startTime = DateTime.Now;
                }
                
                reflectingActivity1.DisplayEndingMessage();

            } else if (_optionInput == 3) //Listing
            {
                ListingActivity listingActivity1 = new ListingActivity();
                listingActivity1.DisplayStartingMessage();
                Console.WriteLine("");
                AskTimeUser(listingActivity1);
                GetReady(listingActivity1);

                Console.WriteLine("List as many responses you can to the following prompt:");
                Console.Write("--- ");
                Console.Write(listingActivity1.GetRandomPrompt());
                Console.WriteLine(" ---");
                Console.Write("You may begin in:");
                listingActivity1.Pausing("countdown", 5);
                Console.WriteLine("");

                DateTime futureTime = DateTime.Now.AddSeconds(listingActivity1.GetDuration());
                int count = 0;
                while (DateTime.Now < futureTime) {
                    Console.Write(">");
                    Console.ReadLine();
                    count++;
                }         
                listingActivity1.SetCountItems(count);

                Console.Write("");
                Console.Write($"You listed {listingActivity1.GetCountItems()} items!");
                Console.WriteLine("");
                listingActivity1.DisplayEndingMessage();
                Console.WriteLine("");

            }

        } 

//OTHERS METHODS TO RE USE CODE
        void AskTimeUser (Activity obj1) {
            Console.WriteLine("How long, in seconds, would you like for your session? ");
            Console.Write("Enter a number between 10 to 35: ");
            string seconds = Console.ReadLine();

                if (int.Parse(seconds) > 35) {
                obj1.SetDuration(35);
                Console.WriteLine("YOU ENTER A TIME BIGGER THAN THE LIMIT, SO WE SET TIME TO 35");
                Console.WriteLine("ENTER TO CONTINUE");
                Console.ReadLine();
            } else if (int.Parse(seconds) < 10) {
                obj1.SetDuration(10);
                Console.WriteLine("YOU ENTER A TIME BIGGER THAN THE LIMIT, SO WE SET TIME TO 10");
                Console.WriteLine("ENTER TO CONTINUE");
                Console.ReadLine();
            } else {
                obj1.SetDuration(int.Parse(seconds));
            }
        
        }

        void GetReady (Activity obj1) {
                Console.Clear();
                Console.WriteLine("Get ready...");
                obj1.Pausing("loading", 5);
        }


    }
}