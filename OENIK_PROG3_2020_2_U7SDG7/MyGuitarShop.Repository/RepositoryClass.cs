namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyGuitarShop.Data;

    /// <summary>
    /// General RepositoryClass class.
    /// </summary>
    /// <typeparam name="T">Must be an entity.</typeparam>
    public abstract class RepositoryClass<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Stores the entity's context.
        /// </summary>
        private DbContext ctx; // here was a protected keyword

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryClass{T}"/> class.
        /// </summary>
        /// <param name="ctx">Some kind of context.</param>
        protected RepositoryClass(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets or sets ctx field to the inherited classes.
        /// </summary>
        protected DbContext Ctx
        {
            get { return this.ctx; }
            set { this.ctx = value; }
        }

        /// <summary>
        /// Gets all of T entities.
        /// </summary>
        /// <returns>A collection of T entities.</returns>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// Gets one T entity by given id.
        /// </summary>
        /// <param name="id">Id of the entity to get.</param>
        /// <returns>T entity.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Inserts one T entity into T entity class.
        /// </summary>
        /// <param name="entity">Entity to insert.</param>
        public void Insert(T entity)
        {
            this.ctx.Set<T>().Add(entity); // jó ez??? set<T>-el kell?
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Removes a T entity from T entity class.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        public void Remove(T entity)
        {
            // biztos, hogy nem Find és aztán Remove, hanem Linq
            // T removableEntity = ctx.Find<T>(id);
            // ctx.Remove(removableEntity);
            // this.ctx;
            this.ctx.Set<T>().Remove(entity);
            this.ctx.SaveChanges();
        }
    }
}
