namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyGuitarShop.Data;

    /// <summary>
    /// GuitarAmpRepository class /RepositoryClass layer.
    /// </summary>
    public class GuitarAmpRepository : RepositoryClass<GuitarAmp>, IGuitarAmpRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuitarAmpRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type context.</param>
        public GuitarAmpRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Gets one GuitarAmp entity by given id.
        /// </summary>
        /// <param name="id">Id of the entity to get.</param>
        /// <returns>GuitarAmp entity.</returns>
        public override GuitarAmp GetOne(int id)
        {
            return this.Ctx.Set<GuitarAmp>().SingleOrDefault();
        }
    }
}
