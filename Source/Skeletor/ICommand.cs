namespace Skeletor
{
    using System;

    /// <summary>
    ///     Interface of a generic command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        ///     Command identifier
        /// </summary>
        Guid CommandId { get; }

        /// <summary>
        ///     The command creation timestamp (in UTC)
        /// </summary>
        DateTime TimeStamp { get; set; }

        /// <summary>
        ///     Identifier of the user who executes the command
        /// </summary>
        object UserId { get; set; }

        /// <summary>
        ///     Correaltion identifier between commands in a workflow
        /// </summary>
        Guid CorrelationId { get; set; }
    }
}
