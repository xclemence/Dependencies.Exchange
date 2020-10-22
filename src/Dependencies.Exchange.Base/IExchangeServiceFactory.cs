namespace Dependencies.Exchange.Base
{
    public interface IExchangeServiceFactory<out T>
        where T : class
    {
        T Create();
    }
}
