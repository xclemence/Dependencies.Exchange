using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dependencies.Exchange.Base;
using Dependencies.Exchange.Base.Models;
using Dependencies.Exchange.Graph.Fwk;
using Dependencies.Exchange.Graph.Extensions;
using Dependencies.Exchange.Graph.Settings;

namespace Dependencies.Exchange.Graph.ViewModels
{
    public class SaveAssemblyViewModel : ObservableObject, IExchangeViewModel<bool>
    {
        private readonly ISettingServices<GraphSettings> settings;

        public SaveAssemblyViewModel(ISettingServices<GraphSettings> settings, AssemblyExchange assembly, IList<AssemblyExchange> dependencies)
        {
            this.settings = settings;
            Assembly = assembly;
            Dependencies = dependencies;
        }

        public bool CanValidate => true;

        public Func<Func<Task>, Task>? RunAsync { get; set; }

        public string Title => "Export assembly";

        public AssemblyExchange Assembly { get; }

        public IList<AssemblyExchange> Dependencies { get; }

        public bool SaveGlobalAssembly { get; set; }

        public async Task<bool> ValidateAsync()
        {
            var service = new AssemblyGraphService(settings.GetSettings());

            var dependencies = Dependencies;

            if (!SaveGlobalAssembly)
            {
                var (filteredAssemblies, removedAssemblies) = Dependencies.FilterGlobalAssembly();
                
                Assembly.RemoveAssemblyReference(removedAssemblies);
                dependencies = filteredAssemblies;
            }
            
            await service.AddAsync(Assembly, dependencies).ConfigureAwait(false);

            return true;
        }
    }
}
