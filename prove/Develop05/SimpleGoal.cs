using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class SimpleGoal : Goal
{

//MEMBER VARIABLES    
    private Boolean _goalDone = false;

// CONSTRUCTORS
    public SimpleGoal(string type, string name, string descript, int points) : base (type, name, descript, points)
    {
        
    }

// METHODS
    public override Boolean GetGoalDone(){
        return _goalDone;
    }

    public void SetGoalDone(Boolean goalDone){
        _goalDone = goalDone;
    }

    public override int RecordEvent(){
        _goalDone = true; 
        return base.GetPoints();
    }
    public override Boolean isDone(){
        return _goalDone;
    }


}
