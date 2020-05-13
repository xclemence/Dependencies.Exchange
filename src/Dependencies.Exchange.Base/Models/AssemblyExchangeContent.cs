using System.Collections.Generic;

namespace Dependencies.Exchange.Base.Models
{
    public class AssemblyExchangeContent
    {
        public AssemblyExchange Assembly { get; set; } = null!;
        public IList<AssemblyExchange> Dependencies { get; set; } = null!;
    }
}
