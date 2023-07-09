
public class FuelConsumption : DataPoint
{
    public double _FM;

    public FuelConsumption(string PIDName, string PIDUnits, double FM) : base(PIDName, PIDUnits)
    {
        _FM = FM;
    }

    public override double _NewPointCalculation()
    {
        double GPH = (_FM * 3600) / 2834.89;
        return Math.Round(GPH, 3);
    }
}