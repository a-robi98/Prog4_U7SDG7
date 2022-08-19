namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyGuitarShop.Data;

    /// <summary>
    /// GuitarAccessoryRepository class /RepositoryClass layer.
    /// </summary>
    public class GuitarAccessoryRepository : RepositoryClass<GuitarAccessory>, IGuitarAccessoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuitarAccessoryRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type context.</param>
        public GuitarAccessoryRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Gets one GuitarAccessory entity by given id.
        /// </summary>
        /// <param name="id">Id of the entity to get.</param>
        /// <returns>GuitarAccessory entity.</returns>
        public override GuitarAccessory GetOne(int id)
        {
            return this.Ctx.Set<GuitarAccessory>().SingleOrDefault();
        }
    }
}
