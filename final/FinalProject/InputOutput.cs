using System.IO;

public class InputOutput
{
    private string _fileName;
    private Boolean _AfrChoice;
    private Boolean _FmChoice;
    private Boolean _GphChoice;
    private Boolean _MpgChoice;
    private Boolean _intakeAirDensityChoice;
    private Boolean _VeChoice;
    

    public InputOutput(string fileName, Boolean AfrChoice, Boolean FmChoice, Boolean GphChoice, Boolean MpgChoice, Boolean intakeAirDensityChoice, Boolean VeChoice)
    {
        _fileName = fileName;
        _AfrChoice = AfrChoice;
        _FmChoice = FmChoice;
        _GphChoice = GphChoice;
        _MpgChoice = MpgChoice;
        _intakeAirDensityChoice = intakeAirDensityChoice;
        _VeChoice = VeChoice;
    }
    
    //Display of strings from list with equal spacing across Console window
    public void _DisplayCalculations(List<string> chosenPids)
    {
        //First string (No previous string spacing)
        Console.Write(String.Format("{0," + ((Console.WindowWidth / (chosenPids.Count() + 1)) + (chosenPids[0].Length / 2)) + "}", chosenPids[0]));
        //All other strings (Previous string spacing)
        for (int i = 0; i < chosenPids.Count() - 1; i++)
        {
            Console.Write(String.Format("{0," + ((Console.WindowWidth / (chosenPids.Count() + 1)) + (chosenPids[i + 1].Length / 2) - (chosenPids[i].Length / 2)) + "}", chosenPids[i + 1]));
        }
    }

    //Read, process, and display of data
    public void _RunCalculations()
    {
        //.csv line index
        int time = 0;
        int Rpm = 1;
        int Iat = 2;
        int Maf = 3;
        int B1Stft = 4;
        int B1Ltft = 5;
        int Mph = 6;
        int B1Lambda = 7;
        int baroPressure = 8;
        //Specific vehicle displacement
        double displacement = 1.8;
        //Set intial values
        double time1 = 0;
        double time2 = 0;
        double timeDiff = 0;

        //Read .csv into array of string lines
        string[] lines = System.IO.File.ReadAllLines(_fileName);

        //***Skip header line and read, calculate, and display to Console line by line***
        foreach (string line in lines.Skip(1)) 
        {
            Console.Clear();
            //Array of string values in line
            string[] items = line.Split(",");
            //Store elapsed time based on time column of .csv file
            time2 = double.Parse(items[time]);
            timeDiff = time2 - time1;
            time1 = double.Parse(items[time]);

            //Create lists of PID values, their names, and their units to be added to and displayed later
            List<string> userPids = new List<string>();
            List<string> userPidNames = new List<string>();
            List<string> userPidUnits = new List<string>();

            //Create AirfuelRatio object and calculate AFR for use in later PID calcaultions and potential display
            AirfuelRatio AfrPoint = new AirfuelRatio("Airfuel Ratio", "(x:1)", double.Parse(items[B1Lambda]));
            double Afr = AfrPoint._NewPointCalculation();
            if (_AfrChoice == true)   //If user chose to display, add PID value, name, and units to respective lists
            {
                userPids.Add(Afr.ToString());
                userPidNames.Add(AfrPoint.GetPIDName());
                userPidUnits.Add(AfrPoint.GetPIDUnits());
            }

            //Create FuelMass object and calculate FM for use in later PID calcaultions and potential display
            FuelMass FmPoint = new FuelMass("Fuel Mass", "(g/s)", double.Parse(items[Maf]), double.Parse(items[B1Stft]), double.Parse(items[B1Ltft]), Afr);
            double Fm = FmPoint._NewPointCalculation();
            if (_FmChoice == true)   //If user chose to display, add PID value, name, and units to respective lists
            {
                userPids.Add(Fm.ToString());
                userPidNames.Add(FmPoint.GetPIDName());
                userPidUnits.Add(FmPoint.GetPIDUnits());
            }

            //Create FuelConsumption object and calculate GPH for use in later PID calcaultions and potential display
            FuelConsumption GphPoint = new FuelConsumption("Fuel Consumption", "(GPH)", Fm);
            double Gph = GphPoint._NewPointCalculation();
            if (_GphChoice == true)   //If user chose to display, add PID value, name, and units to respective lists
            {
                userPids.Add(Gph.ToString());
                userPidNames.Add(GphPoint.GetPIDName());
                userPidUnits.Add(GphPoint.GetPIDUnits());
            }

            if (_MpgChoice == true)   //If user chose to display, create FuelEconomy object, calculate MPG, and add MPG value, name, and units to respective lists
            {
                FuelEconomy MpgPoint = new FuelEconomy("Fuel Economy", "(MPG)", double.Parse(items[Mph]), Gph);
                double Mpg = MpgPoint._NewPointCalculation();
                userPids.Add(Mpg.ToString());
                userPidNames.Add(MpgPoint.GetPIDName());
                userPidUnits.Add(MpgPoint.GetPIDUnits());
            }

            //Create IntakeAirDensity object and calculate Intake Air Density for use in later PID calcaultions and potential display
            IntakeAirDensity intakeAirDensityPoint = new IntakeAirDensity("Intake Air Density", "(kg/m^3)", double.Parse(items[baroPressure]), double.Parse(items[Iat]));
            double intakeAirDensity = intakeAirDensityPoint._NewPointCalculation();
            if (_intakeAirDensityChoice == true)   //If user chose to display, add PID value, name, and units to respective lists
            {
                userPids.Add(intakeAirDensity.ToString());
                userPidNames.Add(intakeAirDensityPoint.GetPIDName());
                userPidUnits.Add(intakeAirDensityPoint.GetPIDUnits());
            }

            if (_VeChoice == true)   //If user chose to display, create VolumetricEfficiency object, calculate VE, and add VE value, name, and units to respective lists
            {
                VolumetricEfficiency VePoint = new VolumetricEfficiency("Volumetric Efficiency", "(%)", double.Parse(items[Maf]), double.Parse(items[Rpm]), intakeAirDensity, displacement);
                double Ve = VePoint._NewPointCalculation();
                userPids.Add(Ve.ToString());
                userPidNames.Add(VePoint.GetPIDName());
                userPidUnits.Add(VePoint.GetPIDUnits());
            }
            
            //Display line of PID values
            _DisplayCalculations(userPids);

            Console.WriteLine();

            //Display line of PID names
            _DisplayCalculations(userPidNames);

            Console.WriteLine();

            //Display line of PID units
            _DisplayCalculations(userPidUnits);

            //Sleep for duration of time elapsed in .csv time column to simulate a live display of vehicle data
            double sleep = timeDiff * 1000;
            Thread.Sleep((int)sleep);
        }
    }
}