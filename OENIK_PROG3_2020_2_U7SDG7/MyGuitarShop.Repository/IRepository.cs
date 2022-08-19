namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyGuitarShop.Data;

    /// <summary>
    /// IRepository interface.
    /// </summary>
    /// <typeparam name="T">Must be an entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets one T entity by entity id.
        /// </summary>
        /// <param name="id">The id of the entity to return.</param>
        /// <returns>A T entity.</returns>
        T GetOne(int id);

        /// <summary>
        /// Gets all of the entities of the T entity.
        /// </summary>
        /// <returns>A collection of T entities.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Removes a T entity from T entity class.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Inserts a T entity to T entity class.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        void Insert(T entity);
    }
}
