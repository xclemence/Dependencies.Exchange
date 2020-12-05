using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dependencies.Exchange.Base.Models;
using Dependencies.Exchange.Graph.Extensions;
using Dependencies.Exchange.Graph.Settings;
using Newtonsoft.Json;

namespace Dependencies.Exchange.Graph
{
    public class AssemblyGraphService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly GraphSettings settings;

        internal AssemblyGraphService(GraphSettings settings) => this.settings = settings;

        public async Task AddAsync(AssemblyExchange assembly, IList<AssemblyExchange> dependencies)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            var assemblyDtos = dependencies.Select(x => x.ToDto()).ToList();

            assemblyDtos.Add(assembly.ToDto());

            var json = JsonConvert.SerializeObject(assemblyDtos);
            using var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(new Uri(@$"{settings.ServiceUri}/api/assembly/add"), data).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        public async Task<IList<string>> SearchAsync(string name)
        {
            var response = await client.GetAsync(new Uri(@$"{settings.ServiceUri}/api/assembly/search/{name}")).ConfigureAwait(false); ;
            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<List<GraphAssemblyDto>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            return result.Select(x => x.Name).ToList();
        }

        public async Task<(AssemblyExchange assembly, IList<AssemblyExchange> dependencies)> GetAsync(string name)
        {
            var response = await client.GetAsync(new Uri(@$"{settings.ServiceUri}/api/assembly/{name}")).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var restult = response.Content;

            var result = JsonConvert.DeserializeObject<List<GraphAssemblyDto>>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));

            var assemblies = result.Select(x => x.ToExchange()).ToList();

            var mainAssembly = assemblies.First(x => x.Name == name);

            assemblies.Remove(mainAssembly);

            return (mainAssembly, assemblies);
        }
    }
}
