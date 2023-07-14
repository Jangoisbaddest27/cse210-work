using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine(@"This program is a simulated live display of vehicle data that is not commonly displayed to drivers.
These Parameter ID (PID) values are calculated using other common and uncommon vehicle values captured
from a vehicle and stored in a .csv file. The display of each PID is optional and can be chosen below.");
        Console.WriteLine("\nChoose PID values to display (Y/N)");

        //User choice of which PIDs to display
        Boolean AfrChoice = _AssignPidBoolean("Airfuel Ratio: ");
        Boolean FmChoice = _AssignPidBoolean("Fuel Mass: ");
        Boolean GphChoice = _AssignPidBoolean("Fuel Consumption: ");
        Boolean MpgChoice = _AssignPidBoolean("Fuel Economy: ");
        Boolean intakeAirDensityChoice = _AssignPidBoolean("Intake Air Density: ");
        Boolean VeChoice = _AssignPidBoolean("Volumetric Efficiency: ");

        //Assign display boolean to PID based on user choice
        Boolean _AssignPidBoolean(string PidName)
        {
            Boolean userChoice = true;
            int i = 0;
            string choice = "";
            while (i == 0)
            {
                Console.Write(PidName);
                choice = Console.ReadLine();
                if (choice.ToLower() == "n")
                {
                    userChoice = false;
                    i++;
                }
                else if (choice.ToLower() == "y")
                {
                    i++;
                }
                else
                {
                    Console.WriteLine("Invalid response, try again.\n");
                }
            }
            return userChoice;
        }

        //Create InputOutput object and run calculations
        InputOutput run = new InputOutput("Log_1.csv", AfrChoice, FmChoice, GphChoice, MpgChoice, intakeAirDensityChoice, VeChoice);
        run._RunCalculations();
    }
}