using System;

namespace Skeletor
{
    /// <summary>
    ///     The base class form which all commands extend
    /// </summary>
    public abstract class Command : ICommand
    {
        /// <summary>
        ///     Backing field for command identifier
        /// </summary>
        private Guid id;

        /// <summary>
        ///     The command identifier
        /// </summary>
        public Guid CommandId
        {
            get
            {
                if(id == Guid.Empty)
                {
                    id = Guid.NewGuid();
                }

                return id;
            }
        }

        /// <summary>
        ///     The command correaltion identifier
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        ///     The command execution TimeStamp
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        ///     User identifier
        /// </summary>
        public object UserId { get; set; }
    }
}
