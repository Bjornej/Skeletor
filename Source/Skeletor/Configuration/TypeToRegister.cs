using System;

namespace Skeletor
{
    /// <summary>
    ///     Describes a type to register in the DI service
    /// </summary>
    public class TypeToRegister
    {
        /// <summary>
        ///     Type to register
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        ///     Interface to be used to register the type
        /// </summary>
        public Type Interface { get; set; }
    }
}