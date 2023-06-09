using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Assignment
{
    private string _studentName;
    private string _topic;


    public Assignment (string name, string topic) {
    _studentName = name;
    _topic = topic;
    }

    public string GetSummary(){
        return $"--- Student: {_studentName} --- Topic: {_topic}";
    }

    public string GetStudentName(){
        return _studentName;
    }

}


