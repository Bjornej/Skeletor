namespace Skeletor
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///     Helper methods for reflection
    /// </summary>
    public static class ReflectionHelpers
    {
        /// <summary>
        ///     Find the handle method for the command and invokes it
        /// </summary>
        /// <param name="handler">Handler to use</param>
        /// <param name="command">Command to execute</param>
        public static void Handle(this ICommandHandler handler, ICommand command)
        {
            var handle = handler.GetType()
                                .GetMethods()
                                .Single(x => x.Name == "Handle" &&
                                             x.ReturnParameter.ParameterType == typeof(void) &&
                                             x.GetParameters().Length == 1 &&
                                             x.GetParameters().First().ParameterType == command.GetType());

            handle.Invoke(handler, new object[] { command });
        }
    }
}
