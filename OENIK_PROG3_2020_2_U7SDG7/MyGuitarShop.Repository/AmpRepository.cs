namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyGuitarShop.Data;

    /// <summary>
    /// AmpRepository class /RepositoryClass layer.
    /// </summary>
    public class AmpRepository : RepositoryClass<Amp>, IAmpRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AmpRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type context.</param>
        public AmpRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes one Amp entity's brand.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newBrand">To what brand.</param>
        public void ChangeBrand(int id, string newBrand)
        {
            var amp = this.GetOne(id);
            amp.Brand = newBrand;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes one Amp entity's modell.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newModell">To what modell.</param>
        public void ChangeModell(int id, string newModell)
        {
            var amp = this.GetOne(id);
            amp.Modell = newModell;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Change one Guitar entity's price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newPrice">To what price.</param>
        public void ChangePrice(int id, int newPrice)
        {
            var amp = this.GetOne(id);
            amp.Price = newPrice;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Gets one Amp entity by given id.
        /// </summary>
        /// <param name="id">Id of the entity to get.</param>
        /// <returns>Amp entity.</returns>
        public override Amp GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.AmpId == id);
        }
    }
}
