namespace NASA.Mars.Contracts
{
    public interface IPositionParser
    {
        IPosition Parse(string representation);
    }
}
