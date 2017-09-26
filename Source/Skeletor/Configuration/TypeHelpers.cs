using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Skeletor
{
    /// <summary>
    ///     Helpers for type
    /// </summary>
    public static class TypeHelpers
    {
        /// <summary>
        ///     Returns true if type is a command handler
        /// </summary>
        /// <param name="type">Type to examine</param>
        /// <returns>Bollean indicating if type is a command handler</returns>
        public static bool IsCommandHandler(this TypeInfo type)
        {
            return type.GetInterfaces().Contains(typeof(ICommandHandler));
        }

        /// <summary>
        ///     Discovers all command handlers in the specified assemblies returing the informations to 
        ///     register them in the DI container
        /// </summary>
        /// <param name="assemblies">Assemblies to examine</param>
        /// <returns>Informations to register</returns>
        public static IEnumerable<TypeToRegister> GetCommandHandlers(IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(x => x.DefinedTypes.Where(z => z.IsCommandHandler()))
                             .SelectMany(x => x.GetCommandHandlerInterfaces());
        }

        /// <summary>
        ///     Examines a type and returns information about all ICommandHandler&lt;T&gt; interfaces
        ///     implemented
        /// </summary>
        /// <param name="type">Type to examine</param>
        /// <returns>Informations about implemented interfaces</returns>
        public static IEnumerable<TypeToRegister> GetCommandHandlerInterfaces(this TypeInfo type)
        {
            return type.GetInterfaces()
                       .Where(x => (typeof(ICommandHandler)).IsAssignableFrom(x) && x != (typeof(ICommandHandler)))
                       .Select(x => new TypeToRegister
                       {
                           Type = type.AsType(),
                           Interface = x
                       });
        }


    }
}
