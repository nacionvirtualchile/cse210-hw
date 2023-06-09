using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class WritingAssignment: Assignment 
{
    private string _title;

    public WritingAssignment (string name, string topic, string title) : base (name, topic)
    {
        _title = title;
    }

    public string GetWritingInformation(){
        return $"--- Title: {_title} --- By: {GetStudentName()}";
    }

}