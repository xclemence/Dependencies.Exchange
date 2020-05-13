using System;
using System.Threading.Tasks;

namespace Dependencies.Exchange.Base
{
    public interface IExchangeViewModel<T>
    {
        bool CanValidate { get; }

        Func<Func<Task>, Task> RunAsync { get; set; }

        string Title { get; }

        Task<T> ValidateAsync();
    }

}
