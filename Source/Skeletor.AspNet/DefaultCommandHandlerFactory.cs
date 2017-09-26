namespace Skeletor.AspNet
{
    using System;

    /// <summary>
    ///     Default command handler factory using the Asp.net dependency injection.
    ///     I know this is technically a service locator anti pattern but it's not easy to avoid
    /// </summary>
    public class DefaultCommandHandlerFactory : ICommandHandlerFactory
    {
        /// <summary>
        ///     Initializes the DefaultCommandHandlerFactory
        /// </summary>
        /// <param name="provider">Service provider</param>
        public DefaultCommandHandlerFactory(IServiceProvider provider)
        {
            ServiceProvider = provider;
        }

        /// <summary>
        ///     Service provider 
        /// </summary>
        private IServiceProvider ServiceProvider;

        /// <summary>
        ///     Resolves the handler for the command
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <returns></returns>
        public ICommandHandler GetHandlerFor(ICommand command)
        {
            return (ICommandHandler)ServiceProvider.GetService(typeof(ICommandHandler<>).MakeGenericType(new Type[] { command.GetType() }));
        }
    }
}
