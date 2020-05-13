using System.Collections.Generic;
using System.Linq;
using Dependencies.Exchange.Base.Models;

namespace Dependencies.Exchange.Graph.Extensions
{
    internal static class AssemblyExchangeExtensions
    {
        internal static void RemoveAssemblyReference(this AssemblyExchange assembly, IList<string> referenceToRemove) => 
            assembly.AssembliesReferenced.RemoveAll(x => referenceToRemove.Contains(x));

        internal static (IList<AssemblyExchange> filteredAssemblies, IList<string> removedAssemblies) FilterGlobalAssembly(this IEnumerable<AssemblyExchange> assemblies)
        {
            var globalAssemblies = assemblies.Where(x => !x.IsLocal).ToList();
            var globalAssemblyNames = globalAssemblies.Select(x => x.Name).ToList();

            var result = assemblies.Except(globalAssemblies).ToList();

            foreach (var item in result)
                item.RemoveAssemblyReference(globalAssemblyNames);

            return (result, globalAssemblyNames);
        }
    }
}
