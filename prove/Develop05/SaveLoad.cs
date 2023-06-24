using System.IO; 

public class SaveLoad
{
    public static void SaveFile(string fileName, List<string> goals)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (string goal in goals)
            {
                outputFile.WriteLine(goal);
            }
        }
    }

    public static List<Goal> LoadGoals(string fileName)
    {
        List<Goal> loadedGoals = new List<Goal>();
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] type = line.Split(":");

            string goalType = type[0];
            if (goalType == "SingleGoal")
            {
                string[] parts = type[1].Split("|");
                int goalPoints = int.Parse(parts[2]);
                bool trueFalse;
                if (parts[3] == "False")
                {
                    trueFalse = false;
                }

                else
                {
                    trueFalse = true;
                }
                SingleGoal singleGoal = new SingleGoal(parts[0], parts[1], goalPoints, trueFalse);
                loadedGoals.Add(singleGoal);
            }

            else if (goalType == "ContinuousGoal")
            {
                string[] parts = type[1].Split("|");
                int goalPoints = int.Parse(parts[2]);
                ContinuousGoal contGoal = new ContinuousGoal(parts[0], parts[1], goalPoints, false);
                loadedGoals.Add(contGoal);
            }

            else if (goalType == "ChecklistGoal")
            {
                string[] parts = type[1].Split("|");
                int goalPoints = int.Parse(parts[2]);
                int goalCurrentCount = int.Parse(parts[3]);
                int goalFinalCount = int.Parse(parts[4]);
                int goalBonus = int.Parse(parts[5]);
                bool trueFalse;
                if (goalCurrentCount == goalFinalCount)
                {
                    trueFalse = true;
                }

                else
                {
                    trueFalse = true;
                }
                ChecklistGoal checkGoal = new ChecklistGoal(parts[0], parts[1], goalPoints, goalCurrentCount, goalFinalCount, goalBonus, trueFalse);
                loadedGoals.Add(checkGoal);
            }
        }
        return loadedGoals;
    }

    public static int LoadPoints(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int points = int.Parse(lines[0]);
        return points;
    }
}