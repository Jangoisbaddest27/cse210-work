
public class FuelMass : DataPoint
{
    public double _MAF;
    public double _STFT;
    public double _LTFT;
    public double _AFR;

    public FuelMass(string PIDName, string PIDUnits, double MAF, double STFT, double LTFT, double AFR) : base(PIDName, PIDUnits)
    {
        _MAF = MAF;
        _STFT = STFT;
        _LTFT = LTFT;
        _AFR = AFR;
    }

    public override double _NewPointCalculation()
    {
        double FM = 0;
        if (_AFR > 0)   //Keep FM at 0 if AFR is 0 or negative
        {
            FM = (_MAF * (1 + (_STFT / 100)) * (1 + (_LTFT / 100))) / _AFR;
        }
        return Math.Round(FM, 3);
    }
}