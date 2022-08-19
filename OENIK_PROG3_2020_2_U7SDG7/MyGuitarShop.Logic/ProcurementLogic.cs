namespace MyGuitarShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MyGuitarShop.Data;
    using MyGuitarShop.Repository;

    /// <summary>
    /// Functions that a member of Procurement uses.
    /// </summary>
    public class ProcurementLogic : IProcurementLogic
    {
        private IGuitarRepository guitarRepo;
        private IAmpRepository ampRepo;
        private IAccessoryRepository accRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcurementLogic"/> class.
        /// </summary>
        /// <param name="gurepo">A RepositoryClass class, which implements IGuitarRepository interface.</param>
        /// <param name="amrepo">A RepositoryClass class, which implements IAmpRepository interface.</param>
        /// <param name="acrepo">A RepositoryClass class, which implements IAccessoryRepository interface.</param>
        public ProcurementLogic(IGuitarRepository gurepo, IAmpRepository amrepo, IAccessoryRepository acrepo)
        {
            this.guitarRepo = gurepo;
            this.ampRepo = amrepo;
            this.accRepo = acrepo;
        }

        /// <summary>
        /// Changes an Accessory's determination.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newDetermination">To what determination.</param>
        public void ChangeAccessoryDetermination(int id, string newDetermination)
        {
            this.accRepo.ChangeDetermination(id, newDetermination);
        }

        /// <summary>
        /// Changes an Accessory's discount price.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newDiscountPrice">To what discount price.</param>
        public void ChangeAccessoryDiscountPrice(int id, int newDiscountPrice)
        {
            this.accRepo.ChangeDiscountPrice(id, newDiscountPrice);
        }

        /// <summary>
        /// Changes an Accessory's modell.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newModell">To what modell.</param>
        public void ChangeAccessoryModell(int id, string newModell)
        {
            this.accRepo.ChangeModell(id, newModell);
        }

        /// <summary>
        /// Changes an Accessory's price.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newPrice">To what price.</param>
        public void ChangeAccessoryPrice(int id, int newPrice)
        {
            this.accRepo.ChangePrice(id, newPrice);
        }

        /// <summary>
        /// Changes an Accessory's quantity.
        /// </summary>
        /// <param name="id">Id of the desired Accessory.</param>
        /// <param name="newQuantity">To what quantity.</param>
        public void ChangeAccessoryQuantity(int id, int newQuantity)
        {
            this.accRepo.ChangeQuantity(id, newQuantity);
        }

        /// <summary>
        /// Changes an Amp's brand.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <param name="newBrand">To what brand.</param>
        public void ChangeAmpBrand(int id, string newBrand)
        {
            this.ampRepo.ChangeBrand(id, newBrand);
        }

        /// <summary>
        /// Changes an Amp's brand.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <param name="newModell">To what modell.</param>
        public void ChangeAmpModell(int id, string newModell)
        {
            this.ampRepo.ChangeModell(id, newModell);
        }

        /// <summary>
        /// Changes an Amp's price.
        /// </summary>
        /// <param name="id">Id of the desired Amp.</param>
        /// <param name="newPrice">To what price.</param>
        public void ChangeAmpPrice(int id, int newPrice)
        {
            this.ampRepo.ChangePrice(id, newPrice);
        }

        /// <summary>
        /// Changes a Guitar's brand.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <param name="newBrand">To what brand.</param>
        public void ChangeGuitarBrand(int id, string newBrand)
        {
            this.guitarRepo.ChangeBrand(id, newBrand);
        }

        /// <summary>
        /// Changes a Guitar's modell.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <param name="newModell">To what modell.</param>
        public void ChangeGuitarModell(int id, string newModell)
        {
            this.guitarRepo.ChangeModell(id, newModell);
        }

        /// <summary>
        /// Changes a Guitar's price.
        /// </summary>
        /// <param name="id">Id of the desired Guitar.</param>
        /// <param name="newPrice">To what price.</param>
        public void ChangeGuitarPrice(int id, int newPrice)
        {
            this.guitarRepo.ChangePrice(id, newPrice);
        }

        /// <summary>
        /// Inserts the given Accessory into the Accessory table.
        /// </summary>
        /// <param name="accessory">The Accessory to be inserted.</param>
        public void InsertAccessory(Accessory accessory)
        {
            this.accRepo.Insert(accessory);
        }

        /// <summary>
        /// Inserts the given Amp into the Amp table.
        /// </summary>
        /// <param name="amp">The Amp to be inserted.</param>
        public void InsertAmp(Amp amp)
        {
            this.ampRepo.Insert(amp);
        }

        /// <summary>
        /// Inserts the given Guitar into the Guitar table.
        /// </summary>
        /// <param name="guitar">The Guitar to be inserted.</param>
        public void InsertGuitar(Guitar guitar)
        {
            this.guitarRepo.Insert(guitar);
        }
    }
}
