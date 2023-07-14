
public class IntakeAirDensity : DataPoint
{
    private double _baroPressure;
    private double _Iat;

    public IntakeAirDensity(string PidName, string PidUnits, double baroPressure, double Iat) : base(PidName, PidUnits)
    {
        _baroPressure = baroPressure;
        _Iat = Iat;
    }

    //Calculate and return Intake Air Density using Barometric Pressure (inHg) and Intake Air Temperature (°F)
    public override double _NewPointCalculation()
    {
        //Convert barometric pressure from inHg to Pascals
        double baroPressureP = _baroPressure * 3386.39;
        //Convert IAT from °F to °K
        double IatK = (_Iat + 459.67) * (5.0 / 9.0);
        //Calculate and return intake air density
        double intakeAirDensity = baroPressureP / (287 * IatK);
        return Math.Round(intakeAirDensity, 3);
    }
}