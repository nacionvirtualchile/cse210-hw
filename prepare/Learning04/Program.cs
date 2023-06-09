using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning04 World!");
        Assignment assignment1 = new Assignment("Charles", "Us History");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment mathAssignment1  = new MathAssignment("Jaime B","Multiplication","Section 1.2","Problems 2-4");
        Console.WriteLine(mathAssignment1.GetSummary());
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Andrés V", "Chilean History", "Pacific War");
        Console.WriteLine(writingAssignment1.GetSummary());
        Console.WriteLine(writingAssignment1.GetWritingInformation());

    }



}