
public class AirfuelRatio : DataPoint
{
    public double _upstreamLambda;

    public AirfuelRatio(string PIDName, string PIDUnits, double upstreamLambda) : base(PIDName, PIDUnits)
    {
        _upstreamLambda = upstreamLambda;
    }

    public override double _NewPointCalculation()
    {
        double AFR = _upstreamLambda * 14.7;
        return Math.Round(AFR, 3); 
    }
}