using System.IO;

public class InputOutput
{
    public string _fileName;

    public InputOutput(string fileName)
    {
        _fileName = fileName;
    }

    public void _DisplayCalculations(string dataPoint1, string dataPoint2, string dataPoint3, string dataPoint4, string dataPoint5, string dataPoint6)
    {
        Console.Write(String.Format("{0," + ((Console.WindowWidth / 7) + (dataPoint1.Length / 2)) + "}", dataPoint1));
        Console.Write(String.Format("{0," + ((Console.WindowWidth / 7) + (dataPoint2.Length / 2) - (dataPoint1.Length / 2)) + "}", dataPoint2));
        Console.Write(String.Format("{0," + ((Console.WindowWidth / 7) + (dataPoint3.Length / 2) - (dataPoint2.Length / 2)) + "}", dataPoint3));
        Console.Write(String.Format("{0," + ((Console.WindowWidth / 7) + (dataPoint4.Length / 2) - (dataPoint3.Length / 2)) + "}", dataPoint4));
        Console.Write(String.Format("{0," + ((Console.WindowWidth / 7) + (dataPoint5.Length / 2) - (dataPoint4.Length / 2)) + "}", dataPoint5));
        Console.Write(String.Format("{0," + ((Console.WindowWidth / 7) + (dataPoint6.Length / 2) - (dataPoint5.Length / 2)) + "}", dataPoint6));
    }

    public void _RunCalculations()
    {
        int time = 0;
        int RPM = 1;
        int IAT = 2;
        int MAF = 3;
        int B1STFT = 4;
        int B1LTFT = 5;
        int MPH = 6;
        int B1Lambda = 7;
        int baroPressure = 8;
        double displacement = 1.8;
        double time1 = 0;
        double time2 = 0;
        double timeDiff = 0;


        string[] lines = System.IO.File.ReadAllLines(_fileName);    //Array of lines in file

        foreach (string line in lines.Skip(1)) 
        {
            Console.Clear();
            string[] items = line.Split(","); //Array of strings in row
            time2 = double.Parse(items[time]);
            timeDiff = time2 - time1;
            time1 = double.Parse(items[time]);

            AirfuelRatio AFRPoint = new AirfuelRatio("Airfuel Ratio", "(x:1)", double.Parse(items[B1Lambda]));
            double AFR = AFRPoint._NewPointCalculation();

            FuelMass FMPoint = new FuelMass("Fuel Mass", "(g/s)", double.Parse(items[MAF]), double.Parse(items[B1STFT]), double.Parse(items[B1LTFT]), AFR);
            double FM = FMPoint._NewPointCalculation();

            FuelConsumption GPHPoint = new FuelConsumption("Fuel Consumption", "(GPH)", FM);
            double GPH = GPHPoint._NewPointCalculation();

            FuelEconomy MPGPoint = new FuelEconomy("Fuel Economy", "(MPG)", double.Parse(items[MPH]), GPH);
            double MPG = MPGPoint._NewPointCalculation();

            IntakeAirDensity intakeAirDensityPoint = new IntakeAirDensity("Intake Air Density", "(kg/m^3)", double.Parse(items[baroPressure]), double.Parse(items[IAT]));
            double intakeAirDensity = intakeAirDensityPoint._NewPointCalculation();

            VolumetricEfficiency VEPoint = new VolumetricEfficiency("Volumetric Efficiency", "(%)", double.Parse(items[MAF]), double.Parse(items[RPM]), intakeAirDensity, displacement);
            double VE = VEPoint._NewPointCalculation();

            //Data line
            _DisplayCalculations(AFR.ToString(), FM.ToString(), GPH.ToString(), MPG.ToString(), intakeAirDensity.ToString(), VE.ToString());

            Console.WriteLine();

            //PID name line
            _DisplayCalculations(AFRPoint.GetPIDName(), FMPoint.GetPIDName(), GPHPoint.GetPIDName(), MPGPoint.GetPIDName(), intakeAirDensityPoint.GetPIDName(), VEPoint.GetPIDName());

            Console.WriteLine();

            //PID units line
            _DisplayCalculations(AFRPoint.GetPIDUnits(), FMPoint.GetPIDUnits(), GPHPoint.GetPIDUnits(), MPGPoint.GetPIDUnits(), intakeAirDensityPoint.GetPIDUnits(), VEPoint.GetPIDUnits());

            double sleep = timeDiff * 1000;
            Thread.Sleep((int)sleep);
        }
    }
}