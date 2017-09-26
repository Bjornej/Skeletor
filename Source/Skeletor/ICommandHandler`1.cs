namespace Skeletor
{
    /// <summary>
    ///     Interface for a generic command handler
    /// </summary>
    /// <typeparam name="T">The type of command that we can handle</typeparam>
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        /// <summary>
        ///     Handles the command specified
        /// </summary>
        /// <param name="command">Command to handler</param>
        void Handle(T command);
    }
}