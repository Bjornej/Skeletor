namespace Skeletor
{
    /// <summary>
    ///     Factory for comand handlers
    /// </summary>
    public interface ICommandHandlerFactory
    {
        /// <summary>
        ///     Retruns the instantiated handler fro the specified command
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <returns>Instantiated command handler</returns>
        ICommandHandler GetHandlerFor(ICommand command);
    }
}
