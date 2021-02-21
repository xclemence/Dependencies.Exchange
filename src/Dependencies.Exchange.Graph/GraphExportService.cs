using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dependencies.Exchange.Base;
using Dependencies.Exchange.Base.Models;
using Dependencies.Exchange.Graph.Extensions;
using Dependencies.Exchange.Graph.Settings;
using Dependencies.Exchange.Graph.ViewModels;
using Dependencies.Exchange.Graph.Views;

namespace Dependencies.Exchange.Graph
{
    public class GraphExportService : IExportAssembly
    {
        private readonly ISettingServices<GraphSettings> settings;

        public string Name => "Graph";
        public bool IsReady => settings.GetSettings().IsValide();

        public string Version => typeof(GraphExportService).Assembly.GetName().Version?.ToString() ?? string.Empty;

        public GraphExportService(ISettingServices<GraphSettings> settings) => this.settings = settings;

        public async Task<bool> ExportAsync(AssemblyExchange assembly,
                                      IList<AssemblyExchange> dependencies,
                                      Func<UserControl, IExchangeViewModel<bool>, Task<bool>> showDialog)
        {
            if (showDialog is null)
                throw new ArgumentNullException(nameof(showDialog));

            var dataContext = new SaveAssemblyViewModel(settings, assembly, dependencies);
            var window = new SaveAssemblyView();

            return await showDialog(window, dataContext).ConfigureAwait(false);
        }
    }
}
