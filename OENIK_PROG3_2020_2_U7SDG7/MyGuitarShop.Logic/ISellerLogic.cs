namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyGuitarShop.Data;

    /// <summary>
    /// Functions that a Seller uses.
    /// </summary>
    public interface ISellerLogic
    {
        /// <summary>
        /// Gets all the Guitars.
        /// </summary>
        /// <returns>A list of Guitars.</returns>
        IList<Guitar> GetAllGuitars();

        /// <summary>
        /// Gets all the Amps.
        /// </summary>
        /// <returns>A list of Amps.</returns>
        IList<Amp> GetAllAmps();

        /// <summary>
        /// Gets all the Accessories.
        /// </summary>
        /// <returns>A list of Accessories.</returns>
        IList<Accessory> GetAllAccessories();

        /// <summary>
        /// Gets a specific Guitar by given id.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <returns>A Guitar.</returns>
        Guitar GetGuitarById(int id);

        /// <summary>
        /// Gets a specific Amp by given id.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <returns>An Amp.</returns>
        Amp GetAmpById(int id);

        /// <summary>
        /// Gets a specific Accessory by given id.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <returns>An Accessory.</returns>
        Accessory GetAccessoryById(int id);

        // Non-Crud

        /// <summary>
        /// Gets all the Guitar-Amp Combos.
        /// </summary>
        /// <returns>A list of GuitarAmps.</returns>
        IList<GuitarAmpCombos> GetGuitarAmpCombos();

        /// <summary>
        /// Gets all the Guitar-Accessory Combos.
        /// </summary>
        /// <returns>A list of GuitarAccessories.</returns>
        IList<GuitarAccessoryCombos> GetGuitarAccessoryCombos();
    }
}
