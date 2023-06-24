using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        SaveLoad file = new SaveLoad();
        int totalPoints = 0;
        int choice = 0;
        while (choice != 6)
        { 
            Console.WriteLine($"\nYou have {totalPoints} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create New Goal"); 
            Console.WriteLine(" 2. List Goals"); 
            Console.WriteLine(" 3. Save Goals"); 
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Report Progress");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            string userChoice = Console.ReadLine();
            choice = int.Parse(userChoice);

            if (choice == 1)    //New Goal
            {
                Console.WriteLine("\nThe types of Goals are:");
                Console.WriteLine(" 1. Single Goal");
                Console.WriteLine(" 2. Continuous Goal");
                Console.WriteLine(" 3. Checklist Goal");
                Console.Write("Which type of Goal would you like to create? ");
                userChoice = Console.ReadLine();
                int choice2 = int.Parse(userChoice);

                if (choice2 == 1)    //Single Goal
                {
                    SingleGoal singleGoal = new SingleGoal();
                    singleGoal.CreateGoal();
                    goals.Add(singleGoal);
                }

                else if (choice2 == 2)    //Continuous Goal
                {
                    ContinuousGoal contGoal = new ContinuousGoal();
                    contGoal.CreateGoal();
                    goals.Add(contGoal);
                }

                else if (choice2 == 3)   //Checklist Goal
                {
                    ChecklistGoal checkGoal = new ChecklistGoal();
                    checkGoal.CreateGoal();
                    goals.Add(checkGoal);
                }

                else    //Error
                {
                    Console.WriteLine("*Select a valid response*");
                }
            }

            else if (choice == 2)    //List Goals
            {
                Console.WriteLine("\nYour Goals are:");
                int count = 1;
                foreach (Goal g in goals)
                {
                    Console.Write($"{count}. ");
                    g.DisplayGoal();
                    ++count;
                }
            }

            else if (choice == 3)    //Save Goals
            {
                List<string> goalsToSave = new List<string>();
                goalsToSave.Add($"{totalPoints}");
                foreach (Goal g in goals)
                {
                    goalsToSave.Add(g.SaveGoal());
                }
                Console.Write("What is the filename for the Goal file? ");
                SaveLoad.SaveFile(Console.ReadLine(), goalsToSave);
            }

            else if (choice == 4)    //Load Goals
            {
                Console.Write("What is the filename for the Goal file? ");
                string fileName = Console.ReadLine();
                goals = SaveLoad.LoadGoals(fileName);
                totalPoints = SaveLoad.LoadPoints(fileName);
            }

            else if (choice == 5)    //Report Progress
            {
                Console.WriteLine("\nYour Goals are:");
                int count = 1;
                foreach (Goal g in goals)
                {
                    Console.Write($"{count}. ");
                    g.DisplayGoal();
                    ++count;
                }
                Console.Write("Which unmarked Goal did you accomplish? ");
                string number = Console.ReadLine();
                int listIndex = int.Parse(number);
                if (goals[listIndex - 1].GetIsCompleted() == false)
                {
                    totalPoints = totalPoints + goals[listIndex - 1].IsCompleted();
                }    

                else
                {
                    Console.WriteLine("*Select an incomplete Goal*");
                }
            }

            else    //Quit
            {
                Console.WriteLine("Have a good day!");
                choice = 6;
            }
        }    
    }
}