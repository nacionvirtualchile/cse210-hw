using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class EternalGoal : Goal
{
// CONSTRUCTORS
    public EternalGoal(string type, string name, string descript, int points) : base (type, name, descript, points)
    {
        
    }

// METHODS
    public override int RecordEvent(){
        return base.GetPoints();
    }
    public override Boolean isDone(){
        return false;
    }

    public override Boolean GetGoalDone(){
        return false;
    }

}