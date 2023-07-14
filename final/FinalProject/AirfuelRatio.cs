
public class AirfuelRatio : DataPoint
{
    private double _upstreamLambda;

    public AirfuelRatio(string PidName, string PidUnits, double upstreamLambda) : base(PidName, PidUnits)
    {
        _upstreamLambda = upstreamLambda;
    }

    //Calculate and return Airfuel Ratio using Upstream Lambda
    public override double _NewPointCalculation()
    {
        double Afr = _upstreamLambda * 14.7;
        return Math.Round(Afr, 3); 
    }
}