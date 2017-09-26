namespace Skeletor
{
    /// <summary>
    ///     Interface to resolve an handler for a specific command
    /// </summary>
    public interface IHandlerResolver
    {
        /// <summary>
        ///     Returns an handler for the command
        /// </summary>
        /// <param name="command">The command for which we need the handler</param>
        /// <returns>The command handler</returns>
        ICommandHandler ResolveHandlerFor(ICommand command);
    }
}
