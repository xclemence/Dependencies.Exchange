using System.Linq;
using Dependencies.Exchange.Base.Models;

namespace Dependencies.Exchange.Graph.Extensions
{
    internal static class AssemblyConverters
    {
        internal static GraphAssemblyDto ToDto(this AssemblyExchange assembly) => new GraphAssemblyDto
        {
            AssembliesReferenced = assembly.AssembliesReferenced.ToList(),
            CreationDate = assembly.CreationDate,
            Creator = assembly.Creator,
            IsNative = assembly.IsNative,
            IsPartial = assembly.IsPartial,
            Name = assembly.Name,
            ShortName = assembly.ShortName,
            Version = assembly.Version,
            IsDebug = assembly.IsDebug,
            IsILOnly = assembly.IsILOnly,
            TargetFramework = assembly.TargetFramework,
            TargetProcessor = assembly.TargetProcessor,
            HasEntryPoint = assembly.HasEntryPoint
        };

        internal static AssemblyExchange ToExchange(this GraphAssemblyDto assembly) => new AssemblyExchange
        {
            AssembliesReferenced = assembly.AssembliesReferenced.ToList(),
            CreationDate = assembly.CreationDate,
            Creator = assembly.Creator,
            IsNative = assembly.IsNative,
            IsPartial = assembly.IsPartial,
            Name = assembly.Name,
            ShortName = assembly.ShortName,
            Version = assembly.Version,
            IsDebug = assembly.IsDebug,
            IsILOnly = assembly.IsILOnly,
            TargetFramework = assembly.TargetFramework,
            TargetProcessor = assembly.TargetProcessor,
            HasEntryPoint = assembly.HasEntryPoint,
            IsLocal = true,
        };
    }
}
