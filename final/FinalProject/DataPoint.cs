
public abstract class DataPoint
{
    protected string _PidName;
    protected string _PidUnits;

    public DataPoint(string PidName, string PidUnits)
    {
        _PidName = PidName;
        _PidUnits = PidUnits;
    }

    public string GetPIDName()
    {
        return _PidName;
    }

    public string GetPIDUnits()
    {
        return _PidUnits;
    }

    public abstract double _NewPointCalculation();
}