using Microsoft.Extensions.DependencyModel;
using System.Linq;
using Xunit;

namespace Skeletor.Tests.Unit
{
    public class DefaultAssemblyDiscovererTests
    {
        public class FindAssemblies
        {
            //[Fact]
            
            public void DiscoversAssembliesDependingOnSkeletor()
            {
                var discoverer = new DefaultAssemblyDiscoverer();

                var res = discoverer.FindAssemblies("Skeletor.Tests.Unit");

                Assert.Equal(res.Count(), 1);
  
            }
        }

    }
}
