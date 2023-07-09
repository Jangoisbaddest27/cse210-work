
public class IntakeAirDensity : DataPoint
{
    public double _baroPressure;
    public double _IAT;

    public IntakeAirDensity(string PIDName, string PIDUnits, double baroPressure, double IAT) : base(PIDName, PIDUnits)
    {
        _baroPressure = baroPressure;
        _IAT = IAT;
    }

    public override double _NewPointCalculation()
    {
        //Convert barometric pressure from inHg to Pascals
        double baroPressureP = _baroPressure * 3386.39;
        //Convert IAT from °F to °K
        double IATK = (_IAT + 459.67) * (5.0 / 9.0);
        //Calculate and return intake air density
        double intakeAirDensity = baroPressureP / (287 * IATK);
        return Math.Round(intakeAirDensity, 3);
    }
}