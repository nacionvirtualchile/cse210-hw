using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Job
{
    // The C# convention is to start member variables with an underscore _
    public string _companyName = "";
    public string _jobTitle  = "";
    public int _startYear;
    public int _endYear;


    // A special method, called a constructor that is invoked using the  
    // new keyword followed by the class name and parentheses.
    public void DisplayJobDetails()
    {
        Console.WriteLine(_jobTitle+" ("+_companyName+") "+_startYear+"-"+_endYear);

    }

    // A method that displays the person's full name as used in eastern 
    // countries or <family name, given name>.


}