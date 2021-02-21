namespace Dependencies.Exchange.Base
{
    public interface IExchangeSevice
    {
        bool IsReady { get; }
        string Name { get; }

        string Version { get; }
    }
}
