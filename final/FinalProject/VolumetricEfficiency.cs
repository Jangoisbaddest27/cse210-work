
public class VolumetricEfficiency : DataPoint
{
    private double _Maf;
    private double _Rpm;
    private double _intakeAirDensity;
    private double _displacement;


    public VolumetricEfficiency(string PidName, string PidUnits, double Maf, double Rpm, double intakeAirDensity, double displacement) : base(PidName, PidUnits)
    {
        _Maf = Maf;
        _Rpm = Rpm;
        _intakeAirDensity = intakeAirDensity;
        _displacement = displacement;
    }

    //Calculate and return Volumetric Efficiency using Mass Air Flow, Engine Speed (RPM), Intake Air Density, and Engine Displacement (L)
    public override double _NewPointCalculation()
    {
        double Ve = 0;
        if (_Rpm > 0 && _intakeAirDensity > 0 && _displacement > 0)  //Keep VE at 0 if RPM, intakeAirDensity, or displacement are 0 or negative
        {
            Ve = 100.0 * _Maf / (_Rpm * _intakeAirDensity * (_displacement / 120.0));
        }
        return Math.Round(Ve, 3);
    }
}