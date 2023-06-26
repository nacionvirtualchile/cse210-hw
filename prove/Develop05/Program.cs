using System;
using System.IO; 

/*
Exceeding Requirements: 
- If the user enters (input) a bad option in any menu, the program shows a message and returns to the main menu 
- the user can't SAVE if there is not a goal in memory. The program shows a message for that
- the user can't RECORD an EVENT if the goal is completed and the program shows a message for that
- The mark for eternal goal is not [ ], is {Forever]
- The program shows a message if the user completes a CheckListGoal
*/

class Program
{
    
    static void Main(string[] args)
    {

        Menu menu1 = new Menu();
        int option = 0;

        List<Goal> _listOfGoals = new List<Goal>();

        Console.Clear();
        Console.WriteLine("___________________");
        Console.WriteLine("___________________");
        Console.WriteLine("Welcome to Eternal Quest Program");
        Console.WriteLine("");

        while (option != 6){
        
            menu1.DisplayMenu();
            Console.Write("Select an option from the menu: ");
            //ASK AND CHECK A CORRECT INPUT
            option = menu1.GetChoiceFromUser();

            if (option == 1) //CREATE NEW GOAL
            {
                Console.WriteLine("");
                menu1.DisplayKinsOfGoals();
                Console.Write("Which type of Goal would you like to create?: ");
                

                //ASK AND CHECK A CORRECT INPUT
                int option2 = menu1.GetChoiceFromUser();
                if (option2==0){
                    continue;
                }


                Console.Write("What is the name of your Goal?: ");
                string name = Console.ReadLine();
                Console.Write("Enter a short description of this goal: ");
                string descript = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                

                if (option2 == 1) // SIMPLE GOAL
                {
                    SimpleGoal simpleGoal1 = new SimpleGoal("SimpleGoal", name, descript, points);
                    _listOfGoals.Add(simpleGoal1);
                } else if (option2 == 2) // ETERNAL GOAL
                {
                    EternalGoal eternalGoal1 = new EternalGoal("EternalGoal", name, descript, points);
                    _listOfGoals.Add(eternalGoal1);
                } else if (option2 == 3) // CHECKLITS GOAL
                {
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int times = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing all? ");
                    int bonus = int.Parse(Console.ReadLine());

                    CheckListGoal checkListGoal1 = new CheckListGoal("CheckListGoal", name, descript, points, times, bonus);
                    _listOfGoals.Add(checkListGoal1);
                }

                Console.WriteLine("___________________");
                Console.WriteLine("Thanks, goal created");
                Console.WriteLine("___________________");
                Console.WriteLine("");
                
            } else if (option == 2) //LIST GOALS
            {
                Console.WriteLine("___________________");
                Console.WriteLine("The goals are:");

                List<String> listOfGoalsNow = GenerateListOfGoalsToDisplay();
                foreach (String goal in listOfGoalsNow)
                {
                    Console.WriteLine(goal);
                }

                Console.WriteLine("___________________");
                Console.WriteLine("");
                Console.WriteLine("ENTER TO CONTINUE");
                Console.ReadLine();

            } else if (option == 3) //SAVE GOALS 
            {

                List<String> listOfGoalsNow = GenerateListOfGoalsToSAVE();

                int count = 0;
                foreach (String goal in listOfGoalsNow)
                {
                    count += 1;
                }
                if (count == 0){
                    Console.WriteLine("__________");
                    Console.WriteLine("__________");
                    Console.WriteLine("THERE IS NOT GOALS YET. CREATE A GOAL FIRST");
                    Console.WriteLine("__________");
                    Console.WriteLine("__________");
                    continue;
                }


                using (StreamWriter outputFile = new StreamWriter("EternalQuest.txt"))
                {
                    
                    //POINTS
                    outputFile.WriteLine(menu1.GetTotalPoints());

                    //GOALS
                    foreach (String goal in listOfGoalsNow)
                    {
                        outputFile.WriteLine(goal);
                    }     

                }

            } else if (option == 4) //LOAD GOALS 
            {

                string filename = "EternalQuest.txt";
                string[] lines = System.IO.File.ReadAllLines(filename);

                int count = 0;
                _listOfGoals.Clear();
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    if (count == 0){
                        menu1.SetTotalPoints(int.Parse(parts[0]));
                    } else {
                        
                        if (parts[0] == "SimpleGoal"){
                            SimpleGoal simpleGoal = new SimpleGoal(parts[0], parts[1], parts[2], int.Parse(parts[3]));
                            _listOfGoals.Add(simpleGoal);
                            simpleGoal.SetGoalDone(bool.Parse(parts[4]));
                        } else if (parts[0] == "EternalGoal"){
                            EternalGoal eternalGoal = new EternalGoal(parts[0], parts[1], parts[2], int.Parse(parts[3]));
                            _listOfGoals.Add(eternalGoal);
                        } else if (parts[0] == "CheckListGoal"){
                            CheckListGoal checkListGoal = new CheckListGoal(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[4]));
                            _listOfGoals.Add(checkListGoal);
                            checkListGoal.SetTimesDone(int.Parse(parts[6]));
                        }

                    }

                    count += 1;

                }

            } else if (option == 5) //RECORD EVENT 
            {

                Console.WriteLine("___________________");
                Console.WriteLine("The goals are:");

                List<String> listOfGoalsNow = GenerateListOfGoalsToDisplay();

                int count = 0;
                foreach (String goal in listOfGoalsNow)
                {
                    Console.WriteLine(goal);
                    count += 1;
                }
                if (count == 0){
                    Console.WriteLine("__________");
                    Console.WriteLine("__________");
                    Console.WriteLine("THERE IS NOT GOALS YET. CREATE A GOAL FIRST");
                    Console.WriteLine("__________");
                    Console.WriteLine("__________");
                    continue;
                }

                Console.WriteLine("");
                Console.WriteLine("Which goal did you accomplish? ");


                //ASK AND CHECK A CORRECT INPUT
                int answer = menu1.GetChoiceFromUserRecordEvent();;
                if (answer==0){
                    continue;
                }
 

                Goal goalToRecord = _listOfGoals[answer];

                if (goalToRecord.isDone()){
                    Console.WriteLine("This goal is already done, select another");
                } else {
                    int TotalPoints = menu1.GetTotalPoints();
                    int earnedPoints = goalToRecord.RecordEvent();
                    TotalPoints += earnedPoints;
                    menu1.SetTotalPoints(TotalPoints);

                    goalToRecord.DisplayMessageEarnPoints(earnedPoints, TotalPoints);
                }


            }




        }
        
        List<String> GenerateListOfGoalsToDisplay(){
            int count = 1;
            List<String> listOfGoalsNow = new List<String>();

            foreach (Goal goal in _listOfGoals)
            {
                string name = goal.GetName();
                string descript = goal.GetDescript();
                string doneGoal = "";
                string TimesCompleted = "";

                if (goal.GetTypeOfGoal() == "EternalGoal"){
                    doneGoal = "[Forever]";
                } else if (goal.GetTypeOfGoal() == "SimpleGoal") {
                    if (goal.GetGoalDone()){
                        doneGoal = "[X]";
                    } else {
                        doneGoal = "[ ]"; 
                    }
                } else if (goal.GetTypeOfGoal() == "CheckListGoal"){
                    if (goal.GetTimesBonusAndTimesDone()[1] == goal.GetTimesBonusAndTimesDone()[2]){
                        doneGoal = "[X]";
                    } else {
                        doneGoal = "[ ]"; 
                    } 
                    TimesCompleted = $"--- Currently completed: {goal.GetTimesBonusAndTimesDone()[1]} / {goal.GetTimesBonusAndTimesDone()[2]}";
                }

                listOfGoalsNow.Add($"{count}. {doneGoal} {name} ({descript}) {TimesCompleted}");

                count += 1;

            }
            return listOfGoalsNow;
        }


        List<String> GenerateListOfGoalsToSAVE(){

            List<String> listOfGoalsNow = new List<String>();

            foreach (Goal goal in _listOfGoals){
                string type = goal.GetTypeOfGoal();
                string name = goal.GetName();
                string descript = goal.GetDescript();
                int points = goal.GetPoints();
                string doneGoal = "";

                if (goal.GetTypeOfGoal() == "SimpleGoal") {
                    if (goal.GetGoalDone()){
                        doneGoal = "True";
                    } else {
                        doneGoal = "False"; 
                    }
                    listOfGoalsNow.Add($"{type},{name},{descript},{points},{doneGoal}");
                
                } else if (goal.GetTypeOfGoal() == "EternalGoal") {
                    listOfGoalsNow.Add($"{type},{name},{descript},{points}");

                } else if (goal.GetTypeOfGoal() == "CheckListGoal"){
                    int bonus = goal.GetTimesBonusAndTimesDone()[0];
                    int TimesDone = goal.GetTimesBonusAndTimesDone()[1];
                    int TimesForBonus = goal.GetTimesBonusAndTimesDone()[2];
                    listOfGoalsNow.Add($"{type},{name},{descript},{points},{bonus},{TimesForBonus},{TimesDone}");

                }


            }
            return listOfGoalsNow;
        }


    }
}