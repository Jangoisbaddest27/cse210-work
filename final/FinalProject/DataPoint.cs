
public abstract class DataPoint
{
    protected string _PIDName;
    protected string _PIDUnits;

    public DataPoint(string PIDName, string PIDUnits)
    {
        _PIDName = PIDName;
        _PIDUnits = PIDUnits;
    }

    public string GetPIDName()
    {
        return _PIDName;
    }

    public string GetPIDUnits()
    {
        return _PIDUnits;
    }

    public abstract double _NewPointCalculation();
}