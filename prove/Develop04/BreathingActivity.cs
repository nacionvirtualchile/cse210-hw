using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class BreathingActivity : Activity
{
//MEMBER VARIABLES
    private int _timeBreatheIN = 3;
    private int _timeBreatheOut = 3;


//CONSTRUCTORS
    public BreathingActivity() {
        base.SetNameActivity("Breathing Activity");
        base.SetDescription("This activity will help you relax by walking your through breathing IN and OUT slowly. Clear you mind and focus on your breathing.");
    }



//METHODS
    public void LoopBreathe(){

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(base.GetDuration());
        int sum = 0;


        while (startTime < futureTime) {
            Console.WriteLine("");
            Console.Write("Breathe IN and hold on...");
            base.Pausing("loadBar",_timeBreatheIN + sum);
            Console.WriteLine("");
            Console.Write("Now breathe OUT...");
            base.Pausing("removeBar",_timeBreatheOut + sum);
            sum += 1;
            startTime = DateTime.Now;
            Console.WriteLine("");
        }
  



    }


}
