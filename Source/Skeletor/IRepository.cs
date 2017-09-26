namespace Skeletor
{
    /// <summary>
    ///     Generic repository to load and save an aggregate
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        ///     Loads an aggregate by its key
        /// </summary>
        /// <typeparam name="T">Type of the aggregate</typeparam>
        /// <typeparam name="T2">Type of the key</typeparam>
        /// <param name="id">Identifier type</param>
        /// <returns>Aggregate loaderd</returns>
        T Load<T, T2>(T2 id);

        /// <summary>
        ///     Saves an agregate
        /// </summary>
        /// <typeparam name="T">Type of the aggregate</typeparam>
        /// <param name="aggregate">Aggreegate to save</param>
        void Save<T>(T aggregate);
    }
}
