
public class FuelMass : DataPoint
{
    private double _Maf;
    private double _Stft;
    private double _Ltft;
    private double _Afr;

    public FuelMass(string PidName, string PidUnits, double Maf, double Stft, double Ltft, double Afr) : base(PidName, PidUnits)
    {
        _Maf = Maf;
        _Stft = Stft;
        _Ltft = Ltft;
        _Afr = Afr;
    }

    //Calculate and return Fuel Mass using Mass Air Flow, Short Term Fuel Trim, Long Term Fuel Trim, and Airfuel Ratio
    public override double _NewPointCalculation()
    {
        double Fm = 0;
        if (_Afr > 0)   //Keep FM at 0 if AFR is 0 or negative
        {
            Fm = (_Maf * (1 + (_Stft / 100)) * (1 + (_Ltft / 100))) / _Afr;
        }
        return Math.Round(Fm, 3);
    }
}