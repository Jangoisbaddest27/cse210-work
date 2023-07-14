
public class FuelEconomy : DataPoint
{
    private double _Mph;
    private double _Gph;

    public FuelEconomy(string PidName, string PidUnits, double Mph, double Gph) : base(PidName, PidUnits)
    {
        _Mph = Mph;
        _Gph = Gph;
    }

    //Calculate and return Fuel Economy using Vehicle Speed (MPG) and Fuel Consumption
    public override double _NewPointCalculation()
    {
        double Mpg = 0;
        if (_Gph > 0)   //Keep MPG at 0 if GPH is 0 or negative
        {
            Mpg = _Mph / _Gph;
        }
        return Math.Round(Mpg, 3);
    }
}