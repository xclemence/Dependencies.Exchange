using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Dependencies.Exchange.Base;
using Dependencies.Exchange.Base.Models;
using Dependencies.Exchange.Graph.Fwk;
using Dependencies.Exchange.Graph.Settings;

namespace Dependencies.Exchange.Graph.ViewModels
{
    public class OpenAssemblyViewModel : ObservableObject, IExchangeViewModel<AssemblyExchangeContent>
    {
        private string searchText = string.Empty;
        private IList<string> availableAssemblies;
        private string selectedAssembly;
        private readonly ISettingServices<GraphSettings> settings;

        public OpenAssemblyViewModel(ISettingServices<GraphSettings> settings)
        {
            this.settings = settings;
            availableAssemblies = new List<string>();
            selectedAssembly = string.Empty;


            SearchCommand = new Command(async () => await SearchAsync().ConfigureAwait(false), () => !string.IsNullOrEmpty(SearchText));
        }

        public ICommand SearchCommand { get; }

        public bool CanValidate => !string.IsNullOrEmpty(SelectedAssembly);

        public string SearchText
        {
            get => searchText;
            set => Set(ref searchText, value);
        }

        public string SelectedAssembly
        {
            get => selectedAssembly;
            set => Set(ref selectedAssembly, value);
        }

        public IList<string> AvailableAssemblies
        {
            get => availableAssemblies;
            set => Set(ref availableAssemblies, value);
        }

        public Func<Func<Task>, Task>? RunAsync { get; set; }

        public string Title => "Open assembly from Graph Services";

        private async Task SearchAsync()
        {
            if (RunAsync == null)
                return;

            await RunAsync.Invoke(async () =>
            {
                var services = new AssemblyGraphService(settings.GetSettings());
                AvailableAssemblies = await services.SearchAsync(SearchText).ConfigureAwait(false);
            }).ConfigureAwait(false);
        }

        public async Task<AssemblyExchangeContent> ValidateAsync()
        {
            var service = new AssemblyGraphService(settings.GetSettings());
            var (assembly, dependencies) = await service.GetAsync(SelectedAssembly).ConfigureAwait(false);

            return new AssemblyExchangeContent { Assembly = assembly, Dependencies = dependencies };
        }
    }
}
