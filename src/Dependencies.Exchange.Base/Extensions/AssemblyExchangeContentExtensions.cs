using System.Collections.Generic;
using Dependencies.Exchange.Base.Models;

namespace Dependencies.Exchange.Base.Extensions
{
    public static class AssemblyExchangeContentExtensions
    {
        public static void Deconstruct(this AssemblyExchangeContent assemblyContent,  out AssemblyExchange assembly, out IList<AssemblyExchange> dependencies)
        {
            assembly = assemblyContent.Assembly;
            dependencies = assemblyContent.Dependencies;
        }
    }
}
