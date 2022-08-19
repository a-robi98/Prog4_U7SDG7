namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MyGuitarShop.Data;

    /// <summary>
    /// Functions that a member of Procurement uses.
    /// </summary>
    public interface IProcurementLogic
    {
        /// <summary>
        /// Changes a Guitar's brand.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <param name="newBrand">To what brand.</param>
        void ChangeGuitarBrand(int id, string newBrand);

        /// <summary>
        /// Changes a Guitar's modell.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <param name="newModell">To what modell.</param>
        void ChangeGuitarModell(int id, string newModell);

        /// <summary>
        /// Changes a Guitar's price.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <param name="newPrice">To what price.</param>
        void ChangeGuitarPrice(int id, int newPrice);

        /// <summary>
        /// Changes an Amp's brand.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <param name="newBrand">To what brand.</param>
        void ChangeAmpBrand(int id, string newBrand);

        /// <summary>
        /// Changes an Amp's brand.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <param name="newModell">To what modell.</param>
        void ChangeAmpModell(int id, string newModell);

        /// <summary>
        /// Changes an Amp's price.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <param name="newPrice">To what price.</param>
        void ChangeAmpPrice(int id, int newPrice);

        /// <summary>
        /// Changes an Accessory's determination.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newDetermination">To what determination.</param>
        void ChangeAccessoryDetermination(int id, string newDetermination);

        /// <summary>
        /// Changes an Accessory's modell.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newModell">To what modell.</param>
        void ChangeAccessoryModell(int id, string newModell);

        /// <summary>
        /// Changes an Accessory's quantity.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newQuantity">To what quantity.</param>
        void ChangeAccessoryQuantity(int id, int newQuantity);

        /// <summary>
        /// Changes an Accessory's price.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newPrice">To what price.</param>
        void ChangeAccessoryPrice(int id, int newPrice);

        /// <summary>
        /// Changes an Accessory's discount price.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newDiscountPrice">To what discount price.</param>
        void ChangeAccessoryDiscountPrice(int id, int newDiscountPrice);

        /// <summary>
        /// Inserts the given Guitar into the Guitar table.
        /// </summary>
        /// <param name="guitar">The Guitar to be inserted.</param>
        void InsertGuitar(Guitar guitar);

        /// <summary>
        /// Inserts the given Amp into the Amp table.
        /// </summary>
        /// <param name="amp">The Amp to be inserted.</param>
        void InsertAmp(Amp amp);

        /// <summary>
        /// Inserts the given Accessory into the Accessory table.
        /// </summary>
        /// <param name="accessory">The Accessory to be inserted.</param>
        void InsertAccessory(Accessory accessory);
    }
}
