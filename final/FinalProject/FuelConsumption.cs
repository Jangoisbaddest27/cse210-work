
public class FuelConsumption : DataPoint
{
    private double _Fm;

    public FuelConsumption(string PidName, string PidUnits, double Fm) : base(PidName, PidUnits)
    {
        _Fm = Fm;
    }

    //Calculate and return Fuel Consumption using Fuel Mass
    public override double _NewPointCalculation()
    {
        double Gph = (_Fm * 3600) / 2834.89;
        return Math.Round(Gph, 3);
    }
}