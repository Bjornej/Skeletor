namespace Skeletor
{
    /// <summary>
    ///     The main interface to executes commands. Iys responsabilities are:
    ///     - find the correct handler for the command
    ///     - execute it
    ///     - return informations about command execution
    /// </summary>
    public interface ICommandExecutor
    {
        /// <summary>
        ///     Executes a command returining informations about its execution
        /// </summary>
        /// <param name="command">The command to execute</param>
        /// <returns>The status of the command execution</returns>
        ExecutionResult Execute(ICommand command);
    }
}
