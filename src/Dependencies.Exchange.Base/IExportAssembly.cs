using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dependencies.Exchange.Base.Models;

namespace Dependencies.Exchange.Base
{
    public interface IExportAssembly : IExchangeSevice
    {
        Task<bool> ExportAsync(AssemblyExchange assembly,
                               IList<AssemblyExchange> dependencies,
                               Func<UserControl, IExchangeViewModel<bool>, Task<bool>> showDialog);
    }
}
