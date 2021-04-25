namespace NASA.Mars.Contracts.Parsers
{
    public interface IPositionParser
    {
        IPosition Parse(string representation);
    }
}
