namespace Dependencies.Exchange.Base
{
    public interface IExchangeServiceFactory
    {
        T Create<T>() where T : class;
    }
}
