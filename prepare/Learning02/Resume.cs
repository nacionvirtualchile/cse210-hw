using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Resume
{
    // The C# convention is to start member variables with an underscore _
    public string _personName = "";
    public List<Job> _listOfJob  = new List<Job>();

    // A special method, called a constructor that is invoked using the  
    // new keyword followed by the class name and parentheses.
    public void DisplayResumeDetails()
    {
        
        Console.WriteLine("----------");
        Console.WriteLine("----------");
        Console.WriteLine("Person name: "+_personName);
        Console.WriteLine("His/Her jobs:");
        foreach (Job job in _listOfJob)
        {
            // Console.WriteLine("   "+job._companyName+" - "+job._jobTitle+" - "+job._startYear+" - "+job._endYear);
            job.DisplayJobDetails();
        }
        Console.WriteLine("----------");
        Console.WriteLine("----------");


    }



}