
public class FuelEconomy : DataPoint
{
    public double _MPH;
    public double _GPH;

    public FuelEconomy(string PIDName, string PIDUnits, double MPH, double GPH) : base(PIDName, PIDUnits)
    {
        _MPH = MPH;
        _GPH = GPH;
    }

    public override double _NewPointCalculation()
    {
        double MPG = 0;
        if (_GPH > 0)   //Keep MPG at 0 if GPH is 0 or negative
        {
            MPG = _MPH / _GPH;
        }
        return Math.Round(MPG, 3);
    }
}