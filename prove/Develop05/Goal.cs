using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public abstract class Goal
{

//MEMBER VARIABLES
    private string _typeOfGoal;
    private string _nameGoal;
    private string _descriptGoal;
    private int _points;


// CONSTRUCTORS
    public Goal (string type, string name, string descript, int points) {
        _typeOfGoal = type;
        _nameGoal = name;
        _descriptGoal = descript;
        _points = points;
    }

//SETTER-GETTER
    public void SetNameGoal(string name){
        _nameGoal = name;
    }
    public void SetDescriptGoal(string descript){
        _descriptGoal = descript;
    }
    public void SetPoints(int points){
        _points = points;
    }
    public string GetTypeOfGoal(){
        return _typeOfGoal;
    }
    public string GetName(){
        return _nameGoal;
    }
    public string GetDescript(){
        return _descriptGoal;
    }
    public int GetPoints(){
        return _points;
    }


//METHODS

    public void DisplayMessageEarnPoints(int earnPoints, int totalPoints){
        Console.WriteLine("");
        Console.WriteLine($"Congratulations! You have earned {earnPoints} points!");
        Console.WriteLine($"You now have {totalPoints} points.");
        Console.WriteLine("");
    }

    public abstract int RecordEvent();
    public abstract Boolean isDone();
    public abstract Boolean GetGoalDone();
    public virtual int[] GetTimesBonusAndTimesDone(){
        int[] test = {-1,-1};
        return test;
    }


}
