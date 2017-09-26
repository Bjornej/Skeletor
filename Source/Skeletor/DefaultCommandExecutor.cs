namespace Skeletor
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    ///     Default command executor
    /// </summary>
    public class DefaultCommandExecutor : ICommandExecutor
    {
        /// <summary>
        ///     Initialized the default command executor
        /// </summary>
        /// <param name="factory">Command handler factory</param>
        public DefaultCommandExecutor(ICommandHandlerFactory factory)
        {
            HandlerFactory = factory;
        }

        /// <summary>
        ///     Factory to resolve command handlers
        /// </summary>
        private ICommandHandlerFactory HandlerFactory;

        /// <summary>
        ///     Executes the command and returns info about its result
        /// </summary>
        /// <param name="command">Command to execute</param>
        /// <returns>Command result</returns>
        public ExecutionResult Execute(ICommand command)
        {
            try
            {
                var handler = HandlerFactory.GetHandlerFor(command);

                handler.Handle(command);

                return new ExecutionResult()
                {
                    Success = true
                };
            }
            catch (System.Exception e)
            {
                return new ExecutionResult()
                {
                    Success = false,
                    Errors = new string[] { e.Message }
                };
            }
        }
    }
}
