using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Skeletor
{
    /// <summary>
    ///     Assembly discoverer to search all assemblies where handlers may be present and register them
    /// </summary>
    public class DefaultAssemblyDiscoverer : IAssemblyDiscoverer
    {
        /// <summary>
        ///     FInds all assemblies referencing the Skeletor dll
        /// </summary>
        /// <param name="entryPointAssemblyName">The entry point form where to search the assemblies</param>
        /// <returns>The list of possibile assemblies found</returns>
        public IEnumerable<Assembly> FindAssemblies(string entryPointAssemblyName)
        {
            var context = DependencyContext.Load(Assembly.Load(new AssemblyName(entryPointAssemblyName)));

            return context.RuntimeLibraries
                          .Where(x => x.Dependencies.Any(z => z.Name=="Skeletor"))
                          .SelectMany(library => library.GetDefaultAssemblyNames(context))
                          .Select(Assembly.Load);
        }
    }
}