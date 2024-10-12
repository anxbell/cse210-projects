using System;

// exceed the requirements: I added a new option to the menu
// it deletes a specific entry from a specific file.
class Program
{
    static void Main(string[] args)
    {


//class
        Job job1 = new Job(); //Create a new job instance named job1 .

        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2020;
        job1._endYear = 2023;

        Job job2 = new Job(); //Create a new job instance named job1 .

        job2._jobTitle = "Front-end Developer";
        job2._company = "Microsoft";
        job2._startYear = 2010;
        job2._endYear = 2020;


        Resume myResume = new Resume();//new instance of the Resume class.
        myResume._name = "Valerie Sanchez";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.DisplayJobDetails();


    }
}