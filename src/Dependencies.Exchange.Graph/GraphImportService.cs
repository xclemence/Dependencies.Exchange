﻿using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dependencies.Exchange.Base;
using Dependencies.Exchange.Base.Models;
using Dependencies.Exchange.Graph.Settings;
using Dependencies.Exchange.Graph.ViewModels;
using Dependencies.Exchange.Graph.Views;

namespace Dependencies.Exchange.Graph
{
    public class GraphImportService : IImportAssembly
    {
        private readonly ISettingServices<GraphSettings> settings;

        public string Name => "Graph";
        public bool IsReady => true;

        public GraphImportService(ISettingServices<GraphSettings> settings) => this.settings = settings;

        public async Task<AssemblyExchangeContent?> ImportAsync(Func<UserControl, IExchangeViewModel<AssemblyExchangeContent>, Task<AssemblyExchangeContent>> showDialog)
        {
            if (showDialog is null)
                throw new ArgumentNullException(nameof(showDialog));

            var dataContext = new OpenAssemblyViewModel(settings);
            var window = new OpenAssemblyView();

            var result = await showDialog(window, dataContext).ConfigureAwait(false);

            return result;
        }
    }
}
