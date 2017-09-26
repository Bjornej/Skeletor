using System.Collections.Generic;
using System.Reflection;

namespace Skeletor
{
    /// <summary>
    ///     Discovers assemblies where 
    /// </summary>
    public interface IAssemblyDiscoverer
    {
        /// <summary>
        ///     Finds all assemblies referencing Skeletor
        /// </summary>
        /// <param name="entryPointAssmeblyName">The entry point assembly name to search all assmeblies needed</param>
        /// <returns>A list of assemblies</returns>
        IEnumerable<Assembly> FindAssemblies(string entryPointAssmeblyName);
    }
}
