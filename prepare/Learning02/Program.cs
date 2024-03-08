using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._company = "NuSkin Enterprises";
        job1._jobTitle = "Information Specialist";
        job1._startYear = 2017;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._company = "Elite Warranty";
        job2._jobTitle = "Accountant";
        job2._startYear = 2017;
        job2._endYear = 2018;

        Resume myResume = new Resume();
        myResume._name = "Nadine Lugo";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}