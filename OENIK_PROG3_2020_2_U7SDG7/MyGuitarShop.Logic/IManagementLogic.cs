namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using MyGuitarShop.Data;

    /// <summary>
    /// Functions that a member of Management uses.
    /// </summary>
    public interface IManagementLogic
    {
        /// <summary>
        /// Removes a specific Guitar from Guitar table.
        /// </summary>
        /// <param name="guitar">The Guitar to be removed.</param>
        void RemoveFromGuitar(Guitar guitar);

        /// <summary>
        /// Removes a specific Amp from Amp table.
        /// </summary>
        /// <param name="amp">The Amp to be removed.</param>
        void RemoveFromAmp(Amp amp);

        /// <summary>
        /// Removes a specific Accessory from Accessory table.
        /// </summary>
        /// <param name="acc">The Accessory to be removed.</param>
        void RemoveFromAccessory(Accessory acc);

        // Non-Crud

        /// <summary>
        /// Gets the prices for Guitar-Amp combos.
        /// </summary>
        /// <returns>A list of GuitarAmpComboPrices.</returns>
        IList<GuitarAmpComboPrice> GetPriceForGuitarAmpCombos();

        /// <summary>
        /// Gets the prices for Guitar-Accessory combos.
        /// </summary>
        /// <returns>A list of GuitarAccessoryComboPrices.</returns>
        IList<GuitarAccessoryComboPrice> GetPriceForGuitarAccessoryCombos();

        /// <summary>
        /// Gives the count of how much Accessories are assigned to a specific Guitar.
        /// </summary>
        /// <returns>A list of GuitarAccessoryCount.</returns>
        IList<GuitarAccessoryCount> GuitarAccessoryCount();

        // Tasks.

        /// <summary>
        /// Gives the count of how much Accessories are assigned to a specific Guitar but with parallelism.
        /// </summary>
        /// <returns>A task out of lists out of GuitarAccessoryCount.</returns>
        Task<IList<GuitarAccessoryCount>> GuitarAccessoryCountAsync();

        /// <summary>
        /// Gives the price for a Guitar Amp Combo but with parallelism.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IList<GuitarAccessoryComboPrice>> GetPriceForGuitarAccessoryCombosAsync();

        /// <summary>
        /// Gives the price for a Guitar Amp Combo but with parallelism.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IList<GuitarAmpComboPrice>> GetPriceForGuitarAmpCombosAsync();
    }
}
