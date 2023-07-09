
public class VolumetricEfficiency : DataPoint
{
    public double _MAF;
    public double _RPM;
    public double _intakeAirDensity;
    public double _displacement;


    public VolumetricEfficiency(string PIDName, string PIDUnits, double MAF, double RPM, double intakeAirDensity, double displacement) : base(PIDName, PIDUnits)
    {
        _MAF = MAF;
        _RPM = RPM;
        _intakeAirDensity = intakeAirDensity;
        _displacement = displacement;
    }

    public override double _NewPointCalculation()
    {
        double VE = 0;
        if (_RPM > 0 && _intakeAirDensity > 0 && _displacement > 0)  //Keep VE at 0 if RPM, intakeAirDensity, or displacement are 0 or negative
        {
            VE = 100.0 * _MAF / (_RPM * _intakeAirDensity * (_displacement / 120.0));
        }
        return Math.Round(VE, 3);
    }
}