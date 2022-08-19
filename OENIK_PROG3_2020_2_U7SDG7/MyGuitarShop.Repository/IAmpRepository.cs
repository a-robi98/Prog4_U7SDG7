namespace MyGuitarShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyGuitarShop.Data;

    /// <summary>
    /// IAmpRepository interface.
    /// </summary>
    public interface IAmpRepository : IRepository<Amp>
    {
        /// <summary>
        /// Changes one Amp entity's brand.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newBrand">To what brand.</param>
        void ChangeBrand(int id, string newBrand);

        /// <summary>
        /// Changes one Amp entity's modell.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newModell">To what modell.</param>
        void ChangeModell(int id, string newModell);

        /// <summary>
        /// Change one Guitar entity's price.
        /// </summary>
        /// <param name="id">Id of the entity.</param>
        /// <param name="newPrice">To what price.</param>
        void ChangePrice(int id, int newPrice);
    }
}
