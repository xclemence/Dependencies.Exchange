using System;
using System.Collections.Generic;
using System.Linq;
using Dependencies.Exchange.Base.Models;
using Dependencies.Exchange.Graph.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dependencies.Exchange.Graph.UnitTests
{
    [TestClass]
    public class TestAssemblyExchangeExtensionsTests
    {
        [TestMethod]
        public void FilterReferenceTest()
        {
            var assembly = new AssemblyExchange();

            assembly.AssembliesReferenced.AddRange(new[]
            {
                "test1",
                "test2",
                "test3",
                "test4",
            });

            assembly.RemoveAssemblyReference(new List<string> { "test2", "test4" });

            Assert.AreEqual(2, assembly.AssembliesReferenced.Count);
            Assert.IsTrue(assembly.AssembliesReferenced.SequenceEqual(new[] { "test1", "test3" }));
        }

        [TestMethod]
        public void FilterGlobalAssembliesTest()
        {
            var assemblies = new[]
            {
                new AssemblyExchange { Name = "test1", IsLocal = true, AssembliesReferenced = new List<string> { "test2", "test3", "test4", } },
                new AssemblyExchange { Name = "test2", AssembliesReferenced = new List<string> { "test3" } },
                new AssemblyExchange { Name = "test3", IsLocal = true, AssembliesReferenced = new List<string> { "test2", "test4" } },
                new AssemblyExchange { Name = "test4", AssembliesReferenced = new List<string> { "test2", "test3" } }
            };

            var (filteredAssemblies, removedAssemblies) = assemblies.FilterGlobalAssembly();

            Assert.AreEqual(2, filteredAssemblies.Count, "Filtered assemblies count");
            Assert.AreEqual(2, removedAssemblies.Count, "Removed assemblies count");

            Assert.IsTrue(filteredAssemblies.All(x => x.IsLocal), "Is local check");
            Assert.IsTrue(removedAssemblies.SequenceEqual(new[] { "test2", "test4" }), "Is local check");

            Assert.AreEqual(1, filteredAssemblies[0].AssembliesReferenced.Count);
            Assert.IsTrue(filteredAssemblies[0].AssembliesReferenced.SequenceEqual(new[] { "test3" }));

            Assert.AreEqual(0, filteredAssemblies[1].AssembliesReferenced.Count);
        }
    }
}
