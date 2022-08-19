namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyGuitarShop.Data;

    /// <summary>
    /// GuitarRepository class /RepositoryClass layer.
    /// </summary>
    public class GuitarRepository : RepositoryClass<Guitar>, IGuitarRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuitarRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type context.</param>
        public GuitarRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes one Guitar entity's brand.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newBrand">To what brand.</param>
        public void ChangeBrand(int id, string newBrand)
        {
            var guitar = this.GetOne(id);
            guitar.Brand = newBrand;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes one Guitar entity's modell.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newModell">To what modell.</param>
        public void ChangeModell(int id, string newModell)
        {
            var guitar = this.GetOne(id);
            guitar.Modell = newModell;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Change one Guitar entity's price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newPrice">To what price.</param>
        public void ChangePrice(int id, int newPrice)
        {
            var guitar = this.GetOne(id);
            guitar.Price = newPrice;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Gets one Guitar entity by given id.
        /// </summary>
        /// <param name="id">Id of the entity to get.</param>
        /// <returns>Guitar entity.</returns>
        public override Guitar GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.GuitarId == id);
        }
    }
}
