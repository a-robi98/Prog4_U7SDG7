namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyGuitarShop.Data;

    /// <summary>
    /// IAccessoryRepository interface.
    /// </summary>
    public interface IAccessoryRepository : IRepository<Accessory>
    {
        /// <summary>
        /// Changes one Accessory entity's determination.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newDetermination">To what determination.</param>
        void ChangeDetermination(int id, string newDetermination);

        /// <summary>
        /// Changes one Accessory entity's modell.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newModell">To what modell.</param>
        void ChangeModell(int id, string newModell);

        /// <summary>
        /// Changes one Accessory entity's quantity.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newQuantity">To what quantity.</param>
        void ChangeQuantity(int id, int newQuantity);

        /// <summary>
        /// Changes one Accessory entity's price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newPrice">To what price.</param>
        void ChangePrice(int id, int newPrice);

        /// <summary>
        /// Changes one Accessory entity's discount price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newDiscountPrice">To what discount price.</param>
        void ChangeDiscountPrice(int id, int newDiscountPrice);
    }
}
