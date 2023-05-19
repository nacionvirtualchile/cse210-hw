using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._companyName = "Microsoft";
        job1._startYear = 2000;
        job1._endYear = 2010;
        //Console.WriteLine(job1._companyName);
        // job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._jobTitle = "Software Engineer";
        job2._companyName = "Apple";
        job2._startYear = 2000;
        job2._endYear = 2010;
        //Console.WriteLine(job2._companyName);
        // job2.DisplayJobDetails();
        
        Resume resume1 = new Resume();
        resume1._personName = "Andrés Rojas";
        resume1._listOfJob.Add(job1);
        resume1._listOfJob.Add(job2);

        // Console.WriteLine(resume1._listOfJob[0]._jobTitle);
        resume1.DisplayResumeDetails();

    }
}