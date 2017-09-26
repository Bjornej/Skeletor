namespace Skeletor
{
    /// <summary>
    ///     Result of the execution of a command
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        ///     Successful execution of the command
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        ///     Errors during command execution
        /// </summary>
        public string[] Errors { get; set; }
    }
}