using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class CheckListGoal : Goal
{

//MEMBER VARIABLES
    private Boolean _goalDone = false;
    private  int _bonusPoints;
    private  int _TimesForBonus;
    private  int _TimesDone;

// CONSTRUCTORS
    public CheckListGoal(string type, string name, string descript, int points, int times, int bonus) : base (type, name, descript, points)
    {
        _TimesForBonus = times;
        _bonusPoints = bonus;

    }

// METHODS
    public override int[] GetTimesBonusAndTimesDone(){
        int[] result = {_bonusPoints,_TimesDone,_TimesForBonus};
        return result;
    }

    public override Boolean GetGoalDone(){
        return _goalDone;
    }
    public void SetTimesDone(int TimesDone){
        _TimesDone = TimesDone;
    }
    public override int RecordEvent(){
        _TimesDone += 1;
        int answer;
        if (isDone()){
            answer = base.GetPoints() + _bonusPoints;
            DislayMessageExtraBonus();
        } else {
            answer = base.GetPoints();
        }
        _goalDone = isDone(); 
        return answer;
    }
    public override Boolean isDone(){
        Boolean answer;
        if (_TimesForBonus == _TimesDone) {
            answer = true;
        } else {
            answer = false;
        }
        return answer;
    }

    public void DislayMessageExtraBonus(){
        Console.WriteLine($"Perfect! the goal is done, so you have the Bonus.");
        Console.WriteLine("");
    }


}