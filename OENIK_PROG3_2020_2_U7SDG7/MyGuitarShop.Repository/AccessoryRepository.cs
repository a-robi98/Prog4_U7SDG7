namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using MyGuitarShop.Data;

    /// <summary>
    /// AccessoryRepository class /RepositoryClass layer.
    /// </summary>
    public class AccessoryRepository : RepositoryClass<Accessory>, IAccessoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessoryRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type context.</param>
        public AccessoryRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Changes one Accessory entity's determination.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newDetermination">To what determination.</param>
        public void ChangeDetermination(int id, string newDetermination)
        {
            var accessory = this.GetOne(id);
            accessory.Determination = newDetermination;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes one Accessory entity's discount price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newDiscountPrice">To what discount price.</param>
        public void ChangeDiscountPrice(int id, int newDiscountPrice)
        {
            var accessory = this.GetOne(id);
            accessory.DiscountPrice = newDiscountPrice;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes one Accessory entity's modell.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newModell">To what modell.</param>
        public void ChangeModell(int id, string newModell)
        {
            var accessory = this.GetOne(id);
            accessory.Modell = newModell;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes one Accessory entity's price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newPrice">To what price.</param>
        public void ChangePrice(int id, int newPrice)
        {
            var accessory = this.GetOne(id);
            accessory.Price = newPrice;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Changes one Accessory entity's quantity.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newQuantity">To what quantity.</param>
        public void ChangeQuantity(int id, int newQuantity)
        {
            var accessory = this.GetOne(id);
            accessory.Quantity = newQuantity;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Gets one Accessory entity by given id.
        /// </summary>
        /// <param name="id">Id of the entity to get.</param>
        /// <returns>Accessory entity.</returns>
        public override Accessory GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.AccessoryId == id);
        }
    }
}
